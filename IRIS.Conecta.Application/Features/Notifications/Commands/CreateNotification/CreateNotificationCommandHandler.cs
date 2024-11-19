using AutoMapper;
using IRIS.Conecta.Application.Contracts.Identity;
using IRIS.Conecta.Application.Contracts.Infrastructure;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Application.Models.Email;
using MediatR;

namespace IRIS.Conecta.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly INotificationsRepository _notificationsRepository;
        private readonly ITicketsRepository _ticketsRepository;
        private readonly IUserService _userService;

        public CreateNotificationCommandHandler(IMapper mapper, IEmailService emailService,
            INotificationsRepository notificationsRepository,
            ITicketsRepository ticketsRepository,
            IUserService userService)
        {
            _mapper         = mapper;
            _emailService   = emailService;
            _userService    = userService;

            _notificationsRepository    = notificationsRepository;
            _ticketsRepository          = ticketsRepository;
            
        }
        public async Task<int> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            // Validate incomming data
            var validator = new CreateNotificationValidation(_ticketsRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) {
                throw new BadRequestException("Invalid Notification", validationResult);
            }

            // Mapiing Data
            var notification = _mapper.Map<Domain.Entities.Tickets.Notifications>(request);

            // Saving data
            await _notificationsRepository.CreateAsync(notification);

            if (notification.SendEmail) { 
                this.SendNotificationEmailAsync(notification, notification.TicketId);
            }

            return notification.Id;
        }

        private async void SendNotificationEmailAsync(Domain.Entities.Tickets.Notifications notification, int ticketId)
        {
            try
            {
                // Get Ticket
                var ticket = await _ticketsRepository.GetByIdAsync(ticketId);

                // Get user
                var user = await _userService.GetUser(ticket.UserId);

                var email = new Email
                {
                    To = user.Email, // Get record from Application User - Student and Manager
                    Body = $"Tu Solicitud # {ticket.Id} ha cambiado a {ticket.Status}.\r\n " +
                    $"\r\n{notification.Message}\r\n" +
                    $"Por favor, mira los detalles adjuntos.",
                    Subject = "Novedad en Solicitud"
                };

                await _emailService.SendEmailAsync(email);
            }
            catch (Exception ex)
            {

                throw new Exception("Solicitud inválida por " + ex.Message);
            }
        }
    }
}
