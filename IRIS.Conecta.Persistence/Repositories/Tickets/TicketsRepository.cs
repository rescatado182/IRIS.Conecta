using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Domain.Entities.Tickets;
using IRIS.Conecta.Domain.Enums;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IRIS.Conecta.Persistence.Repositories.Tickets
{
    public class TicketsRepository : GenericRepository<Ticket>, ITicketsRepository
    {
        public TicketsRepository(IRISConectaDatabaseContext context) : base(context)
        {
        }

        public async Task ChangeTicketStatus(Ticket ticket, TicketsStatus status)
        {
            ticket.Status = status;
            _context.Entry(ticket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
    }
}
