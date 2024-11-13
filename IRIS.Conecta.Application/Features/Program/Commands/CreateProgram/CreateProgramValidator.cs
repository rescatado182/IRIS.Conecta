using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence.Masters;

namespace IRIS.Conecta.Application.Features.Program.Commands.CreateProgram
{
    public class CreateProgramValidator : AbstractValidator<CreateProgramCommand>
    {
        private readonly IDepartmentRepository departmentRepository;

        public CreateProgramValidator(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;

            RuleFor(p => p.ProgramName)
                .NotEmpty().WithMessage("{PropertyName} es requerida.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.ProgramType)
                .IsInEnum()
                .NotEmpty().WithMessage("{PropertyName} es requerida.");
                

            RuleFor(p => p.DepartmentId)
                .GreaterThan(0)
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var ProgramExists = await this.departmentRepository.GetByIdAsync(id);
                    return ProgramExists != null;
                })
                .WithMessage("{PropertyName} no existe.");
        }
    }
}
