using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.CreateTicket
{
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        private readonly IRequestTypeRepository requestTypeRepository;

        public CreateTicketCommandValidator(IRequestTypeRepository requestTypeRepository)
        {
            this.requestTypeRepository = requestTypeRepository;

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} es requerida.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.Status)
                .IsInEnum()
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

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
    }
}
