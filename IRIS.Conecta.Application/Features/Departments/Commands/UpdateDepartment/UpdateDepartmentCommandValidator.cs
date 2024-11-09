using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;

namespace IRIS.Conecta.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        private readonly IFacultyRepository _facultyRepository;

        public UpdateDepartmentCommandValidator(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
            

            RuleFor(p => p.DepartmentName)
                .NotEmpty().WithMessage("{PropertyName} es requerida.")
                .NotEmpty()
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.FacultyId)
                .GreaterThan(0)
                .NotEmpty()
                .MustAsync(async (id, token) =>
                {
                    var facultyExists = await _facultyRepository.GetByIdAsync(id);
                    return facultyExists != null;
                })
                .WithMessage("{PropertyName} no existe.");
        }

        //private async Task<bool> DepartmentMustExists(int id, CancellationToken cancellationToken)
        //{ 
        //    var deparmtent = await _DepartmentRepository.GetByIdAsync(id);
        //    return deparmtent != null;
        //}
    }
}
