using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities;
using IRIS.Conecta.Persistence.DatabaseContext;

namespace IRIS.Conecta.Persistence.Repositories
{
    public class AcademicDataRepository(IRISConectaDatabaseContext context) :
        GenericRepository<AcademicData>(context), IAcademicDataRepository
    {

    }
}
