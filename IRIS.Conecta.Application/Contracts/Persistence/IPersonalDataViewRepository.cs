using IRIS.Conecta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.Contracts.Persistence
{
    public interface IPersonalDataViewRepository : IGenericRepository<PersonalDataView>
    {
        Task<List<PersonalDataView>> GetPersonalDatasAsync();

        Task<PersonalDataView> GetPersonalDataByIdAsync(int id);
    }
}
