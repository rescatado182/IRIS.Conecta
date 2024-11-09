using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;

namespace IRIS.Conecta.Application.Features.AcademicData.Commands.UpdateAcademicData
{
    public class UpdateAcademicDataValidator : AbstractValidator<UpdateAcademicDataCommand>
    {
        private readonly ITicketsRepository ticketsRepository;

        public UpdateAcademicDataValidator(ITicketsRepository ticketsRepository)
        {
            this.ticketsRepository = ticketsRepository;

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

            RuleFor(p => p.AcademicDataDto.TicketId)
                .GreaterThan(0)
                .NotEmpty()
                .MustAsync(async (id, token) => {
                    var ticketExists = await this.ticketsRepository.GetByIdAsync(id);
                    return ticketExists != null;
                })
                .WithMessage("{PropertyName} no existe.");

        }
    }
}
