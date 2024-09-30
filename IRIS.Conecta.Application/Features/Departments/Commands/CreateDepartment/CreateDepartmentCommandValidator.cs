using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.Departments.DTOs;

namespace IRIS.Conecta.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        private readonly IFacultyRepository _facultyRepository;

        public CreateDepartmentCommandValidator(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
            
            RuleFor(p => p.DepartmentName)
                .NotEmpty().WithMessage("{PropertyName} es requerida.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.FacultyId)
                .GreaterThan(0)
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var facultyExists = await _facultyRepository.GetByIdAsync(id);
                    return facultyExists != null;
                })
                .WithMessage("{PropertyName} no existe.");
        }






    }




}
