using FluentValidation;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByRequirements
{
    public class UpdateTicketByRequirementsCommandValidator : AbstractValidator<UpdateTicketByRequirementsCommand>
    {
        public UpdateTicketByRequirementsCommandValidator()
        {
            RuleFor(p => p.Status)
                .IsInEnum()
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.Total)
                .NotEmpty().WithMessage("{PropertyName} es requerida.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser un monto válido.");

            RuleFor(p => p.StartDate)
                .Must(BeAValidDate).WithMessage("{PropertyName} debe ser una fecha válida.")
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .LessThan(p => DateOnly.FromDateTime(DateTime.Now)).WithMessage("{PropertyName} debe ser una fecha valida y no en el pasado");

            RuleFor(p => p.EndDate)
                .Must(BeAValidDate).WithMessage("{PropertyName} debe ser una fecha válida.")
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .LessThan(p => DateOnly.FromDateTime(DateTime.Now)).WithMessage("{PropertyName} debe ser una fecha valida y no en el pasado");

        }

        private bool BeAValidDate(DateOnly date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
