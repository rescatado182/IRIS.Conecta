using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.Program.Commands.DeleteProgram
{
    public class DeleteProgramCommandHandler : IRequestHandler<DeleteProgramCommand, Unit>
    {
        private readonly IProgramRepository programRepository;

        public DeleteProgramCommandHandler(IProgramRepository programRepository)
        {
            this.programRepository = programRepository;
        }
        public async Task<Unit> Handle(DeleteProgramCommand request, CancellationToken cancellationToken)
        {
            var program = await this.programRepository.GetByIdAsync(request.Id);

            if (program == null) {
                throw new NotFoundException(nameof(Domain.Entities.Masters.Program), request.Id);
            }
            
            await this.programRepository.DeleteAsync(program);

            return Unit.Value;
        }
    }
}
