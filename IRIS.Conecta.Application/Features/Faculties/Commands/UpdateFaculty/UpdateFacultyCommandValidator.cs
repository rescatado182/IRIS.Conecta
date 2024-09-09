using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;

namespace IRIS.Conecta.Application.Features.Faculties.Commands.UpdateFaculty
{
    public class UpdateFacultyCommandValidator : AbstractValidator<UpdateFacultyCommand>
    {
        private readonly IFacultyRepository _facultyRepository;

        public UpdateFacultyCommandValidator(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;

            RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(FacultyMustExist);

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");
        }

        private async Task<bool> FacultyMustExist(int id, CancellationToken token)
        {
            var faculty = await _facultyRepository.GetByIdAsync(id);
            return faculty != null;
        }
    }
}
