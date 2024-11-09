using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;

namespace IRIS.Conecta.Application.Features.RequestTypes.Commands.UpdateRequestType
{
    public class UpdateRequestTypeValidator : AbstractValidator<UpdateRequestTypeCommand>
    {
        private readonly IProgramRepository ProgramRepository;
        
        public UpdateRequestTypeValidator(IProgramRepository ProgramRepository)
        {
            this.ProgramRepository   = ProgramRepository;

            RuleFor(p => p.RequestName)
                .NotEmpty().WithMessage("{PropertyName} es requerida.")
                .NotEmpty()
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.ProgramId)
                .GreaterThan(0)
                .NotEmpty()
                .MustAsync(async (id, token) =>
                {
                    var ProgramExists = await this.ProgramRepository.GetByIdAsync(id);
                    return ProgramExists != null;
                })
                .WithMessage("{PropertyName} no existe.");
        }

        //private async Task<bool> RequestTypeMustExists(int id, CancellationToken cancellationToken)
        //{
        //    var requestType = await this.requestTypeRepository.GetByIdAsync(id);
        //    return requestType != null;
        //}
    }
}
