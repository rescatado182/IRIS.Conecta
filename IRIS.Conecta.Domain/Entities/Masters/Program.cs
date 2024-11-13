using IRIS.Conecta.Domain.Base;
using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Domain.Entities.Masters
{
    public class Program : BaseEntity
    {
        public int Id { get; set; }
        public string? ProgramName { get; set; }
        public ProgramType ProgramType { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
