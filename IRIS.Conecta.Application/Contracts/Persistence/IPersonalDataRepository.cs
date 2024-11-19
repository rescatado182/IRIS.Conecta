using IRIS.Conecta.Domain.Entities;

namespace IRIS.Conecta.Application.Contracts.Persistence
{
    public interface IPersonalDataRepository : IGenericRepository<PersonalData>
    {
        Task<List<PersonalData>> GetPersonalDatasAsync();

        Task<PersonalData> GetPersonalDataByIdAsync(int id);
    }
}
