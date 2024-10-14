using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.CreateTicket
{
    public class CreateTicketDto
    {
        public string Title { get; set; }
        public int RequestTypeId { get; set; }
        public TicketsStatus Status { get; set; }
    }
}
