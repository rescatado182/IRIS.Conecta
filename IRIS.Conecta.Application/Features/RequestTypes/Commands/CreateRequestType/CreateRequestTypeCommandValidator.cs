using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;

namespace IRIS.Conecta.Application.Features.RequestTypes.Commands.CreateRequestType
{
    public class CreateRequestTypeCommandValidator : AbstractValidator<CreateRequestTypeCommand>
    {
        private readonly IDepartmentRepository departmentRepository;

        public CreateRequestTypeCommandValidator(IDepartmentRepository departmentRepository) 
        {
            this.departmentRepository = departmentRepository;

            RuleFor(p => p.RequestName)
                .NotEmpty().WithMessage("{PropertyName} es requerida.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.DepartmentId)
                .GreaterThan(0)
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var departmentExists = await this.departmentRepository.GetByIdAsync(id);
                    return departmentExists != null;
                })
                .WithMessage("{PropertyName} no existe.");
            
        }
    }
}
