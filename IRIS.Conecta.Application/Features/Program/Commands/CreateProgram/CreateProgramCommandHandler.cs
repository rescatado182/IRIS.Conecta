using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.Program.Commands.CreateProgram
{
    public class CreateProgramCommandHandler : IRequestHandler<CreateProgramCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IProgramRepository programRepository;

        public CreateProgramCommandHandler(IMapper mapper, 
            IDepartmentRepository departmentRepository,
            IProgramRepository programRepository)
        {
            this.mapper = mapper;
            this.departmentRepository = departmentRepository;
            this.programRepository = programRepository;
        }
        public async Task<int> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
        {
            // Validate incomming data
            var validator = new CreateProgramValidator(this.departmentRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) {
                throw new BadRequestException("Invalid Program", validationResult);
            }

            // Mapping data
            var program = this.mapper.Map<Domain.Entities.Masters.Program>(request);

            // Create the record
            await this.programRepository.CreateAsync(program);

            return program.Id;
        }
    }
}
