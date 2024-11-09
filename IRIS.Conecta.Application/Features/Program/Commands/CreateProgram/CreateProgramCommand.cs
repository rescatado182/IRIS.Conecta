using IRIS.Conecta.Domain.Enums;
using MediatR;

namespace IRIS.Conecta.Application.Features.Program.Commands.CreateProgram
{
    public class CreateProgramCommand : IRequest<int>
    {
        public string ProgramName { get; set; }
        public ProgramType ProgramType { get; set; }
        public int DepartmentId { get; set; }
    }
}
