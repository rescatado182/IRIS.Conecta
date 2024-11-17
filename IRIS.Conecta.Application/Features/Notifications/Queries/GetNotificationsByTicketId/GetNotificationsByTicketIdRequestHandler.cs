using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Features.Notifications.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Notifications.Queries.GetNotificationsByTicketId
{
    public class GetNotificationsByTicketIdRequestHandler : 
        IRequestHandler<GetNotificationsByTicketIdRequest, List<NotificationsDto>>    
    {
        private readonly IMapper _mapper;
        private readonly INotificationsRepository _notificationsRepository;

        public GetNotificationsByTicketIdRequestHandler(IMapper mapper, 
            INotificationsRepository notificationsRepository)
        {
            _mapper = mapper;
            _notificationsRepository = notificationsRepository;
        }

        public async Task<List<NotificationsDto>> Handle(GetNotificationsByTicketIdRequest request, CancellationToken cancellationToken)
        {
            // Query DB
            var notifications = await _notificationsRepository.GetNotificationsByTicket(request.TicketId);

            // mapping data
            var data = _mapper.Map<List<NotificationsDto>>(notifications);

            return data;
        }
    }
}
