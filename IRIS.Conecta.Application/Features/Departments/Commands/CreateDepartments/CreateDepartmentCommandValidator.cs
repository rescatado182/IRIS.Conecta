using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;

namespace IRIS.Conecta.Application.Features.Departments.Commands.CreateDepartments
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private IDepartmentRepository departmentRepository;

        public CreateDepartmentCommandValidator(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;

            RuleFor(p => p.DepartmentName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }


    }




}
