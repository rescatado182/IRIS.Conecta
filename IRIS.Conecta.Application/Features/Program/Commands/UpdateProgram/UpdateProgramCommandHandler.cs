using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Masters;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.Program.Commands.UpdateProgram
{
    public class UpdateProgramCommandHandler : IRequestHandler<UpdateProgramCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IProgramRepository programRepository;

        public UpdateProgramCommandHandler(IMapper mapper, 
            IDepartmentRepository departmentRepository,
            IProgramRepository programRepository)
        {
            this.mapper = mapper;
            this.departmentRepository   = departmentRepository;
            this.programRepository      = programRepository;
        }
        public async Task<Unit> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
        {
            // Get and validate incomming data
            var program = await this.programRepository.GetByIdAsync(request.Id);

            if (program == null) {
                throw new NotFoundException(nameof(program), request.Id);
            }

            var validator = new UpdateProgramValidator(this.departmentRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) {
                throw new ValidationException(validationResult);
            }

            // Mapping data
            this.mapper.Map(request, program);
            await this.programRepository.UpdateAsync(program);

            return Unit.Value;

        }
    }
}
