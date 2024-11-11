using IRIS.Conecta.Domain.Enums;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByMovility
{
    public class UpdateTicketByMovilityCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        // Título de la Ponencia (S/A)
        public required string Title { get; set; }

        // Nombre de la actividad que origina la movilidad
        public string EventName { get; set; }
        public TicketsStatus Status { get; set; }
        public string MovilityType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string ContactData { get; set; }
        public string ExternalInstitution { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public string UserId { get; set; }
    }
}
