using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace IRIS.Conecta.Persistence.Repositories
{
    public class PersonalDataViewRepository : GenericRepository<PersonalDataView>, IPersonalDataViewRepository
    {
        StringBuilder sqlQuery;

        public PersonalDataViewRepository(IRISConectaDatabaseContext context) : base(context)
        {
            sqlQuery = new StringBuilder();
        }
        
        public async Task<List<PersonalDataView>> GetPersonalDatasAsync()
        {
            sqlQuery.Append(
                        "SELECT p.*, ci.country_name, ci.country_code, ci.state_name, ci.name as city," +
                        "(SELECT s.name FROM states s WHERE s.id = p.ResidenceStateId) AS ResidenceState," +
                        "(SELECT ct.name FROM Cities ct WHERE ct.id = p.ResidenceCityId) AS ResidenceCity " +
                        "FROM PersonalData p INNER JOIN Cities ci ON p.BornCityId = ci.id " +
                        "ORDER BY p.Id;");

            var data = await _context.PersonalDatasView.FromSqlRaw(
                sqlQuery.ToString()
            )
            .AsNoTracking()
            .ToListAsync();

            return data;
        }

        public async Task<PersonalDataView> GetPersonalDataByIdAsync(int id)
        {
            sqlQuery.Append(
                        $"SELECT p.*, ci.country_name, ci.country_code, ci.state_name, ci.name as city," +
                        "(SELECT s.name FROM states s WHERE s.id = p.ResidenceStateId) AS ResidenceState," +
                        "(SELECT ct.name FROM Cities ct WHERE ct.id = p.ResidenceCityId) AS ResidenceCity " +
                        "FROM PersonalData p INNER JOIN Cities ci ON p.BornCityId = ci.id " +
                        "WHERE p.Id = " + id);

            var data = await _context.PersonalDatasView.FromSqlRaw(
                sqlQuery.ToString()
            )
            .AsNoTracking()
            .FirstOrDefaultAsync();

            return data;
        }
    }
}
