using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence.Masters;

namespace IRIS.Conecta.Application.Features.RequestTypes.Commands.CreateRequestType
{
    public class CreateRequestTypeCommandValidator : AbstractValidator<CreateRequestTypeCommand>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public CreateRequestTypeCommandValidator(IDepartmentRepository departmentRepository) 
        {
            _departmentRepository = departmentRepository;

            RuleFor(p => p.RequestName)
                .NotEmpty().WithMessage("{PropertyName} es requerida.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.DepartmentId)
                .GreaterThan(0)
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var DepartmentExists = await _departmentRepository.GetByIdAsync(id);
                    return DepartmentExists != null;
                })
                .WithMessage("{PropertyName} no existe.");
            
        }
    }
}
