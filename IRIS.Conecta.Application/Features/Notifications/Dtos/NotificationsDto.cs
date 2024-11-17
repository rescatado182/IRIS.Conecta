using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.Notifications.Dtos
{
    public class NotificationsDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool SendEmail { get; set; } = false;
        public int TicketId { get; set; }
        public NotificationType NotificationType { get; set; }        
    }
}
