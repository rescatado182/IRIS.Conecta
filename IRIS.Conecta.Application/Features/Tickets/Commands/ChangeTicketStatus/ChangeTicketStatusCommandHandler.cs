using AutoMapper;
using IRIS.Conecta.Application.Contracts.Identity;
using IRIS.Conecta.Application.Contracts.Infrastructure;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Application.Models.Email;
using IRIS.Conecta.Domain.Entities.Tickets;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.ChangeTicketStatus
{
    public class ChangeTicketStatusCommandHandler : IRequestHandler<ChangeTicketStatusCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly ITicketsRepository _ticketsRepository;

        public ChangeTicketStatusCommandHandler(IMapper mapper, IEmailService emailService,
            IUserService userService, ITicketsRepository ticketsRepository)
        {
            _mapper             = mapper;
            _emailService       = emailService;
            _userService        = userService;
            _ticketsRepository  = ticketsRepository;
        }

        public async Task<Unit> Handle(ChangeTicketStatusCommand request, CancellationToken cancellationToken)
        {
            // Check and get item by Id
            var ticket = await _ticketsRepository.GetByIdAsync(request.Id);

            if (ticket == null) {
                throw new NotFoundException(nameof(ticket), request.Id);
            }

            // Validate
            var validator = new ChangeTicketStatusValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) {
                throw new ValidationException(validationResult);
            }

            // Assign data
            ticket.Status = request.Status;
            _mapper.Map(request, ticket);

            await _ticketsRepository.UpdateAsync(ticket);

            //this.SendChangeTicketStatusEmail(ticket);

            return Unit.Value;
        }

        private async void SendChangeTicketStatusEmail(Ticket ticket)
        {
            try
            {
                // Get user
                var user = await _userService.GetUser(ticket.UserId);

                var email = new Email
                {
                    To = user.Email, // Get record from Application User - Student and Manager
                    Body = $"Tu Solicitud # {ticket.Id} ha cambiado a {ticket.Status}.\r\n " +
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
