using IRIS.Conecta.Domain.Entities.Masters;

namespace IRIS.Conecta.Application.Contracts.Persistence.Masters
{

    public interface IProgramRepository : IGenericRepository<Program>
    {
        Task<List<Program>> GetProgramswithDetails();

        Task<Program> GetProgramwithDetail(int id);
    }
}
