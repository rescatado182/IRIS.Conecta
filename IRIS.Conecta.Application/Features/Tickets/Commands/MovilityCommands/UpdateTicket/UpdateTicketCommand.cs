using IRIS.Conecta.Domain.Enums;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicket
{
    /**
     *  By Justification
     */
    public class UpdateTicketCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string AgreementName { get; set; }
        public string Description { get; set; }
        public bool IsAgreement { get; set; } = false;
        public string Results { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public TicketsStatus Status { get; set; }
        public int RequestTypeId { get; set; }
    }
}
