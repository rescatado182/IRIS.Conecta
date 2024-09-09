using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;

namespace IRIS.Conecta.Application.Features.Faculties.Commands.CreateFaculty
{
    public class CreateFacultyCommandValidator : AbstractValidator<CreateFacultyCommand>
    {
        private readonly IFacultyRepository _facultyRepository;

        public CreateFacultyCommandValidator(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }

        
    }
}
