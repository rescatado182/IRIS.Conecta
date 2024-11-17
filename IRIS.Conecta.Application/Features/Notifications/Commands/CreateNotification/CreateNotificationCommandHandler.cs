using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly INotificationsRepository _notificationsRepository;
        private readonly ITicketsRepository _ticketsRepository;

        public CreateNotificationCommandHandler(IMapper mapper, 
            INotificationsRepository notificationsRepository,
            ITicketsRepository ticketsRepository)
        {
            _mapper = mapper;
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

            return notification.Id;
        }
    }
}
