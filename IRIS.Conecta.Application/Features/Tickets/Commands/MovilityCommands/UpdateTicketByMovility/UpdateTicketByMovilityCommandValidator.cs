using FluentValidation;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByMovility
{
    public class UpdateTicketByMovilityCommandValidator : AbstractValidator<UpdateTicketByMovilityCommand>
    {
        public UpdateTicketByMovilityCommandValidator()
        {

            RuleFor(p => p.Title)
               .NotEmpty().WithMessage("El campo es {PropertyName} es requerido.")
               .NotNull();

            RuleFor(p => p.EventName)
               .NotEmpty().WithMessage("El campo es {PropertyName} es requerido.")
               .NotNull();

            RuleFor(p => p.MovilityType)
               .NotEmpty().WithMessage("{PropertyName} es requerida.")
               .NotNull();

            RuleFor(p => p.Phone)
               .MinimumLength(6).MaximumLength(20)
               .WithMessage("{PropertyName} debe ser un número telefónico válido.");

            RuleFor(p => p.Status)
                .IsInEnum()
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.ContactData)
               .NotEmpty().WithMessage("{PropertyName} es requerida.")
               .MaximumLength(200).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.ExternalInstitution)
                .NotEmpty().WithMessage("{PropertyName} es requerida.");

            RuleFor(p => p.StartDateMovility)
                .Must(BeAValidDate).WithMessage("{PropertyName} debe ser una fecha válida.")
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.EndDateMovility)
                .Must(BeAValidDate).WithMessage("{PropertyName} debe ser una fecha válida.")
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

        }

        private bool BeAValidDate(DateOnly date)
        {
            return !date.Equals(default(DateTime));
        }

        

        
    }
}
