using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities.Masters;
using IRIS.Conecta.Persistence.DatabaseContext;

namespace IRIS.Conecta.Persistence.Repositories
{
    public class FacultiesRepository : GenericRepository<Faculty>, IFacultyRepository
    {
        public FacultiesRepository(IRISConectaDatabaseContext context) : base(context)
        {
            
        }
    }
}
