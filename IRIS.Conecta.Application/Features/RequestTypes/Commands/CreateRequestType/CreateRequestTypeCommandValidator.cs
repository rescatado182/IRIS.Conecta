using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;

namespace IRIS.Conecta.Application.Features.RequestTypes.Commands.CreateRequestType
{
    public class CreateRequestTypeCommandValidator : AbstractValidator<CreateRequestTypeCommand>
    {
        private readonly IProgramRepository ProgramRepository;

        public CreateRequestTypeCommandValidator(IProgramRepository ProgramRepository) 
        {
            this.ProgramRepository = ProgramRepository;

            RuleFor(p => p.RequestName)
                .NotEmpty().WithMessage("{PropertyName} es requerida.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.ProgramId)
                .GreaterThan(0)
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var ProgramExists = await this.ProgramRepository.GetByIdAsync(id);
                    return ProgramExists != null;
                })
                .WithMessage("{PropertyName} no existe.");
            
        }
    }
}
