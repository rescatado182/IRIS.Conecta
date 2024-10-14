using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities;
using IRIS.Conecta.Persistence.DatabaseContext;

namespace IRIS.Conecta.Persistence.Repositories
{
    public class TicketsRepository(IRISConectaDatabaseContext context) :
        GenericRepository<Ticket>(context), ITicketsRepository
    {

    }
}
