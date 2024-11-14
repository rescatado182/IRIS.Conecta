using IRIS.Conecta.Domain.Enums;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.ChangeTicketStatus
{
    public class ChangeTicketStatusCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ManagerUserId { get; set; }
        public TicketsStatus Status { get; set; }
        
    }
}
