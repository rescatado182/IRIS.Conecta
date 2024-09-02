using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities.Masters;
using IRIS.Conecta.Persistence.DatabaseContext;

namespace IRIS.Conecta.Persistence.Repositories
{
    public class RequestTypesRepository : GenericRepository<RequestType>, IRequestTypeRepository
    {
        public RequestTypesRepository(IRISConectaDatabaseContext context) : base(context)
        {
            
        }


    }
}
