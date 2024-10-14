using IRIS.Conecta.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByRequirements
{
    public class UpdateTicketByRequirementsDto
    {
        public int Id { get; set; }
        public TicketsStatus Status { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public double Total { get; set; }
    }
}
