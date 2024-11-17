using FluentValidation;
using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.ChangeTicketStatus
{
    public class ChangeTicketStatusValidator : AbstractValidator<ChangeTicketStatusCommand>
    {
        public ChangeTicketStatusValidator()
        {
            RuleFor(p => p.Status)
                .IsInEnum()
                .NotEmpty().WithMessage("Status es requerido.")
                .MustAsync(TicketStatusIsValid)
                .WithMessage("Status debe tener un Estado válido para ser cambiado");
        }

        private async Task<bool> TicketStatusIsValid(TicketsStatus status, CancellationToken token)
        {
            bool flag = false;
            string TicketStatus = status.ToString();

            switch (TicketStatus)
            {
                case "Open":
                case "InProcess":
                    flag = true;
                break;
                case "Closed":
                case "Cancelled":
                case "Resolved":
                    flag = false;
                break;
            }

            return flag;
        }

        
    }
}
