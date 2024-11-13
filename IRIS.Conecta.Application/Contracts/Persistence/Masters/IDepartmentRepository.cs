using IRIS.Conecta.Domain.Entities.Masters;

namespace IRIS.Conecta.Application.Contracts.Persistence.Masters
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<List<Department>> GetDepartmentsWithFaculties();
    }
}
