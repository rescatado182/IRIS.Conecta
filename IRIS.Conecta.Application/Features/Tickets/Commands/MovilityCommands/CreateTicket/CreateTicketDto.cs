using IRIS.Conecta.Domain.Enums;
using System.Text.Json.Serialization;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.CreateTicket
{
    public class CreateTicketDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int RequestTypeId { get; set; }
        public string UserId { get; set; }
        public TicketsStatus Status { get; set; }
    }
}
