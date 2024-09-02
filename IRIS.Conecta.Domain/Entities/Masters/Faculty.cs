using IRIS.Conecta.Domain.Base;

namespace IRIS.Conecta.Domain.Entities.Masters
{
    public class Faculty : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Department>? Departments { get; set; }

        public int DepartmentsNumber => Departments == null || Departments.Count == 0 ? 0 : Departments.Count;

    }
}
