using MediatR;

namespace IRIS.Conecta.Application.Features.Program.Commands.DeleteProgram
{
    public class DeleteProgramCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
