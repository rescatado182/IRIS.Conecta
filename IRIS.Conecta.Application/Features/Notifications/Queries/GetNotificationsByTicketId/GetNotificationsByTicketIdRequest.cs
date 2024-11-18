using IRIS.Conecta.Application.Features.Notifications.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Notifications.Queries.GetNotificationsByTicketId
{
    public class GetNotificationsByTicketIdRequest : IRequest<List<NotificationsDto>>
    {
        public int TicketId { get; set; }
    }
}
