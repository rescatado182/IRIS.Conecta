using IRIS.Conecta.Domain.Enums;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByRequirements
{
    public class UpdateTicketByRequirementsCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public TicketsStatus Status { get; set; }
        public DateOnly StartDateRequirement { get; set; }
        public DateOnly EndDateRequirement { get; set; }
        public string TicketRequirements { get; set; }
        public double Total { get; set; }
        public string UserId { get; set; }
        public string ManagerUserId { get; set; }
    }
}
