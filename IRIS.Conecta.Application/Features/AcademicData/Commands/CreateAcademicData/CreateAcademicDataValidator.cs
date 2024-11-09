using FluentValidation;

namespace IRIS.Conecta.Application.Features.AcademicData.Commands.CreateAcademicData
{
    public class CreateAcademicDataValidator : AbstractValidator<CreateAcademicDataCommand>
    {
        public CreateAcademicDataValidator()
        {
            RuleFor(p => p.AcademicDataDto.ResearchGroup)
               .NotEmpty().WithMessage("{PropertyName} es requerido.")
               .NotNull()
               .MaximumLength(200).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.AcademicDataDto.ResearchProject)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.AcademicDataDto.ProgramType)
                .IsInEnum()
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.AcademicDataDto.AverageCredit)
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.AcademicDataDto.EnrolledSemester)
                .NotEmpty().WithMessage("{PropertyName} es requerido.");            
            
        }
    }
}
