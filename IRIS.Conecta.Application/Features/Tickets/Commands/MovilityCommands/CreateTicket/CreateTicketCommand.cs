using IRIS.Conecta.Domain.Enums;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.CreateTicket
{
    public class CreateTicketCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketsStatus Status { get; set; }
        public int RequestTypeId { get; set; }
        public string UserId { get; set; }
    }
}
