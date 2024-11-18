using IRIS.Conecta.Domain.Enums;
using MediatR;

namespace IRIS.Conecta.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommand : IRequest<int>
    {
        public string Message { get; set; }
        public bool SendEmail { get; set; } = false;
        public int TicketId { get; set; }
        public NotificationType NotificationType { get; set; }        
    }
}
