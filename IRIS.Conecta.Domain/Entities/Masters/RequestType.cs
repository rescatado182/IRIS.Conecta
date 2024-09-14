using IRIS.Conecta.Domain.Base;

namespace IRIS.Conecta.Domain.Entities.Masters
{
    public class RequestType : BaseEntity
    {
        public int Id { get; set; }
        public string RequestName { get; set; } = null!;
        public int DepartmentId { get; set; }
        public virtual required Department Department { get; set; } 
    }
}
