using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.ChangeTicketStatus
{
    public class ChangeTicketStatusValidator : AbstractValidator<ChangeTicketStatusCommand>
    {
        private readonly ITicketsRepository _ticketsRepository;

        public ChangeTicketStatusValidator(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;

            RuleFor(p => p)                
                .NotEmpty().WithMessage("La Solicitud es requerida.")
                .MustAsync( async(ticket, token) => await TicketStatusIsValid(ticket.Id, ticket.Status, token));


            RuleFor(p => p.Status)
                .IsInEnum()
                .NotEmpty().WithMessage("Status debe tener un Estado válido para ser cambiado");
        }

        private async Task<bool> TicketStatusIsValid(int ticketId, TicketsStatus ticketStatus, CancellationToken token)
        {
            var ticket  = await _ticketsRepository.GetByIdAsync(ticketId);
            bool flag   = false;

            string incomming_status = ticketStatus.ToString();
            string current_status   = ticket.Status.ToString();


            if (ticket != null)
            {
                if (current_status == "Open") {
                    flag = true;
                }

                else if (current_status == "InProcess" && incomming_status != "Open") {
                    flag = true;
                }

                else if (incomming_status == "InProcess" && (current_status != "Closed" || current_status != "Resolved") ) {
                    flag = true;
                }

                else if (incomming_status == "InProcess" && current_status != "Cancelled" ) {
                    flag = true;
                }

                else if (current_status == "Closed" || current_status == "Cancelled" || current_status == "Resolved") {
                    flag = false;
                }
            }

            return flag;
        }

        
    }
}
