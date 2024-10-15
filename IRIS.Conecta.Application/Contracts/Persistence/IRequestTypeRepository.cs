using IRIS.Conecta.Domain.Entities;

namespace IRIS.Conecta.Application.Contracts.Persistence
{
    public interface IRequestTypeRepository : IGenericRepository<RequestType>
    {
        Task<List<RequestType>> GetRequestTypesListWithDeparments();

        Task<RequestType> GetRequestTypeWithDeparment(int id);
    }
}
