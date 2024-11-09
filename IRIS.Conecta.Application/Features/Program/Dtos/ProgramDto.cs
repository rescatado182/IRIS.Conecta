using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.Program.Dtos
{
    public class ProgramDto
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public ProgramType ProgramType { get; set; }
        public int DepartmentId { get; set; }
    }
}
