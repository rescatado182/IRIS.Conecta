using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Domain.Entities.Tickets;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace IRIS.Conecta.Persistence.Repositories.Tickets
{

    public class TicketsViewsRepository : GenericRepository<TicketsView>, ITicketsViewRepository
    {
        StringBuilder sqlQuery;
        public TicketsViewsRepository(IRISConectaDatabaseContext context) : base(context)
        {
            sqlQuery = new StringBuilder();
        }        

        public async Task<List<TicketsView>> GetTicketsList()
        {
            sqlQuery.Append(
                        "SELECT t.*, r.RequestName, d.Department, f.FacultyName, " +
                        "CONCAT(u.FirstName, ' ', u.LastName) AS FullName " +
                        "FROM Tickets t " +
                        "INNER JOIN RequestTypes r ON t.RequestTypeId = r.Id " +
                        "INNER JOIN Departments d ON r.DepartmentId = d.Id " +
                        "INNER JOIN Faculties f ON d.FacultyId = f.Id " +
                        "INNER JOIN [Identity.Users] u ON t.UserId = u.Id " +
                        "ORDER BY t.DateCreated;");

            var tickets = await _context.TicketsViews.FromSqlRaw(
                sqlQuery.ToString()
            )
            .AsNoTracking()
            .ToListAsync();
            
            return tickets;
        }

    }
}
