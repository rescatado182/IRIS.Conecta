using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicket
{
    public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
    {
        private readonly IRequestTypeRepository requestTypeRepository;

        public UpdateTicketCommandValidator(IRequestTypeRepository requestTypeRepository)
        {
            this.requestTypeRepository = requestTypeRepository;

            RuleFor(p => p.AgreementName)
               .NotEmpty().WithMessage("{PropertyName} es requerida.")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.Status)
                .IsInEnum()
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.DeliveryDate)
                .Must(BeAValidDate).WithMessage("{PropertyName} debe ser una fecha valida.")
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .LessThan(p => DateOnly.FromDateTime(DateTime.Now)).WithMessage("{PropertyName} debe ser una fecha valida y no en el pasado");

            RuleFor(p => p.RequestTypeId)
                .GreaterThan(0)
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var requestTypeExists = await this.requestTypeRepository.GetByIdAsync(id);
                    return requestTypeExists != null;
                })
                .WithMessage("{PropertyName} no existe.");

        }

        private bool BeAValidDate(DateOnly date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
