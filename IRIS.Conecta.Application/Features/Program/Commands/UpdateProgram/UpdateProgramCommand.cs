using IRIS.Conecta.Domain.Enums;
using MediatR;

namespace IRIS.Conecta.Application.Features.Program.Commands.UpdateProgram
{
    public class UpdateProgramCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public ProgramType ProgramType { get; set; }
        public int DepartmentId { get; set; }
    }
}
