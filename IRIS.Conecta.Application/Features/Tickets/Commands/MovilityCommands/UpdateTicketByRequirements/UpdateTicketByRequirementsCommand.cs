using IRIS.Conecta.Domain.Enums;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByRequirements
{
    public class UpdateTicketByRequirementsCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public TicketsStatus Status { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public double Total { get; set; }
        public string UserId { get; set; }
    }
}
