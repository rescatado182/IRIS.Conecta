using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IRIS.Conecta.Persistence.Repositories
{
    public class RequestTypesRepository(IRISConectaDatabaseContext context) : 
        GenericRepository<RequestType>(context), IRequestTypeRepository
    {

        public async Task<List<RequestType>> GetRequestTypesListWithDeparments()
        {
            var requestTypes = await _context.RequestTypes
                .Include(q => q.Department)
                .ToListAsync();

            return requestTypes;
        }

        public async Task<RequestType> GetRequestTypeWithDeparment(int id)
        {
            var requestType = await _context.RequestTypes
                .Include(q => q.Department)
                .FirstOrDefaultAsync(q => q.Id == id);

            return requestType;
        }


    }
}
