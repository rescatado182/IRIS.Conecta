using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence.Masters;

namespace IRIS.Conecta.Application.Features.RequestTypes.Commands.UpdateRequestType
{
    public class UpdateRequestTypeValidator : AbstractValidator<UpdateRequestTypeCommand>
    {
        private readonly IDepartmentRepository departmentRepository;

        public UpdateRequestTypeValidator(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;

            RuleFor(p => p.RequestName)
                .NotEmpty().WithMessage("{PropertyName} es requerida.")
                .NotEmpty()
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.DepartmentId)
                .GreaterThan(0)
                .NotEmpty()
                .MustAsync(async (id, token) =>
                {
                    var DepartmentExists = await this.departmentRepository.GetByIdAsync(id);
                    return DepartmentExists != null;
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
