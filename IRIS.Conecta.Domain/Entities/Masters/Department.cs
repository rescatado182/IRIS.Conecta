using IRIS.Conecta.Domain.Base;

namespace IRIS.Conecta.Domain.Entities.Masters
{
    public class Department : BaseEntity
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int FacultyId { get; set; }
        public required Faculty Faculty { get; set; }
        public virtual ICollection<RequestType> RequestTypes { get; set; } = [];

    }
}
