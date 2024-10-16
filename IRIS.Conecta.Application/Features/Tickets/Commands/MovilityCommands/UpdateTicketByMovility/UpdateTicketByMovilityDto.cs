using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByMovility
{
    public class UpdateTicketByMovilityDto
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public TicketsStatus Status { get; set; }
        public int RequestTypeId { get; set; }

        public string MovilityType { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public string Phone { get; set; }

        public string ContactData { get; set; }

        public string ExternalInstitution { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public string Results { get; set; }
        public DateOnly DeliveryDate { get; set; }

        public double Total { get; set; }
    }
}
