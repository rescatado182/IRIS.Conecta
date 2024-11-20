using IRIS.Conecta.Domain.Base;
using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Domain.Entities.Tickets
{
    public class Notifications : BaseEntity
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public bool SendEmail { get; set; } = false;
        public int TicketId { get; set; }
        public string? ManagerUserId { get; set; }
        public NotificationType NotificationType { get; set; }
        public virtual Ticket? Ticket { get; set; }
    }
}
