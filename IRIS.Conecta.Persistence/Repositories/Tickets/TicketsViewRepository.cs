using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Domain.Entities.Tickets;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IRIS.Conecta.Persistence.Repositories.Tickets
{

    public class TicketsViewsRepository(IRISConectaDatabaseContext context) :
        GenericRepository<TicketsView>(context), ITicketsViewRepository
    {
        public async Task<List<TicketsView>> GetTicketsByUser(string userId)
        {
            var tickets = await _context.TicketsViews
                .Where(x => x.UserId == userId
                && x.PersonalDataId != 0
                && x.AcademicDataId != 0)                
                .ToListAsync();

            return tickets;
        }

        public async Task<TicketsView> GetTicketById(int ticketId)
        {
            return await _context.TicketsViews
                .Where(x => x.Id == ticketId)
                .FirstOrDefaultAsync();
        }

    }
}
