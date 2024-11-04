using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities;
using IRIS.Conecta.Persistence.DatabaseContext;

namespace IRIS.Conecta.Persistence.Repositories
{
    public class PersonalDataRepository(IRISConectaDatabaseContext context) :
        GenericRepository<PersonalData>(context), IPersonalDataRepository
    {

    }
}
