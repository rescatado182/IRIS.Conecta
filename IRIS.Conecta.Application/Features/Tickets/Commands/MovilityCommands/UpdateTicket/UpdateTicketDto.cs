using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicket
{
    public class UpdateTicketDto
    {
        public int Id { get; set; }
        public string AgreementName { get; set; }
        public string Description { get; set; }
        public bool IsAgreement { get; set; }
        public string Results { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public TicketsStatus State { get; set; }
        public int RequestTypeId { get; set; }
        public string UserId { get; set; }
    }
}
