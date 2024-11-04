using FluentValidation;

namespace IRIS.Conecta.Application.Features.PersonalData.Commands.UpdatePersonalData
{
    public class UpdatePersonalDataValidator : AbstractValidator<UpdatePersonalDataCommand>
    {
        public UpdatePersonalDataValidator()
        {
            RuleFor(p => p.PersonalDataDto.FullName)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.PersonalDataDto.DocumentNumber)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.PersonalDataDto.DocumentType)
                .IsInEnum()
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.PersonalDataDto.BornCountryId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.PersonalDataDto.BornCityId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.PersonalDataDto.ResidenceCityId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.PersonalDataDto.Cellphone)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(15).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.PersonalDataDto.PersonalEmail)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .EmailAddress()
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

        }
    }
}
