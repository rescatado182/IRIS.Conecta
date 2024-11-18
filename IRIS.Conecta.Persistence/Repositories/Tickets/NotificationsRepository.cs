using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Domain.Entities.Tickets;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IRIS.Conecta.Persistence.Repositories.Tickets
{
    public class NotificationsRepository : GenericRepository<Notifications>, INotificationsRepository
    {
        public NotificationsRepository(IRISConectaDatabaseContext context) : base(context)
        {            
        }

        public async Task<List<Notifications>> GetNotificationsByTicket(int ticketId)
        {
            var notifications = await _context.Notifications
                .Where(x => x.TicketId == ticketId)
                .ToListAsync();

            return notifications;
        }

    }
}
