using IRIS.Conecta.Domain.Base;

namespace IRIS.Conecta.Domain.Entities.Masters
{
    public class Department : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int FacultyId { get; set; }

        public Faculty? Faculty { get; set; }

        public ICollection<RequestType>? RequestTypes { get; set; }

        public int RequestTypesNumber => RequestTypes == null || RequestTypes.Count == 0 ? 0 : RequestTypes.Count;

    }
}
