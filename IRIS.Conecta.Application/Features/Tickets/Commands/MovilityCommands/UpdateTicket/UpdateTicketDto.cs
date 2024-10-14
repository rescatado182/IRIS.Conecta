using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicket
{
    public class UpdateTicketDto
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public TicketsStatus State { get; set; }
        public int RequestTypeId { get; set; }
    }
}
