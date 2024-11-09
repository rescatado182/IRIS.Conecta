using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities;
using IRIS.Conecta.Domain.Enums;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IRIS.Conecta.Persistence.Repositories
{
    public class TicketsRepository(IRISConectaDatabaseContext context) :
        GenericRepository<Ticket>(context), ITicketsRepository
    {
        public async Task<List<Ticket>> GetTicketsByUser(string userId)
        {
            var tickets = await _context.Tickets
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return tickets;
        }

        public async Task ChangeTicketStatus(Ticket ticket, TicketsStatus status)
        {
            ticket.Status = status;
            _context.Entry(ticket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
