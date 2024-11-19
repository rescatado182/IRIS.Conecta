using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace IRIS.Conecta.Persistence.Repositories
{
    public class PersonalDataRepository : GenericRepository<PersonalData>, IPersonalDataRepository
    {
        StringBuilder sqlQuery;
        public PersonalDataRepository(IRISConectaDatabaseContext context) : base(context)
        {
            sqlQuery = new StringBuilder();
        }

        public async Task<List<PersonalData>> GetPersonalDatasAsync()
        {
            sqlQuery.Append(
                        "SELECT p.*, ci.country_name, ci.country_code, ci.state_name, ci.name as city," +
                        "(SELECT s.name FROM states s WHERE s.id = p.ResidenceStateId) AS ResidenceState," +
                        "(SELECT ct.name FROM Cities ct WHERE ct.id = p.ResidenceCityId) AS ResidenceCity " +
                        "FROM PersonalData p INNER JOIN Cities ci ON p.BornCityId = ci.id" +
                        "ORDER BY p.Id;");

            var data = await _context.PersonalDatas.FromSqlRaw(
                sqlQuery.ToString()
            )
            .AsNoTracking()
            .ToListAsync();

            return data;
        }

        public async Task<PersonalData> GetPersonalDataByIdAsync(int id)
        {
            sqlQuery.Append(
                        $"SELECT p.*, ci.country_name, ci.country_code, ci.state_name, ci.name as city," +
                        "(SELECT s.name FROM states s WHERE s.id = p.ResidenceStateId) AS ResidenceState," +
                        "(SELECT ct.name FROM Cities ct WHERE ct.id = p.ResidenceCityId) AS ResidenceCity " +
                        "FROM PersonalData p INNER JOIN Cities ci ON p.BornCityId = ci.id" +
                        "WHERE p.Id = @dataId ORDER BY p.Id;");

            var data = await _context.PersonalDatas.FromSqlRaw(
                sqlQuery.ToString(), [new Microsoft.Data.SqlClient.SqlParameter("@dataId", id)] 
            )
            .AsNoTracking()
            .FirstOrDefaultAsync();

            return data;
        }
    }
}
