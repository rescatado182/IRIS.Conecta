using IRIS.Conecta.Domain.Entities.Tickets;

namespace IRIS.Conecta.Application.Contracts.Persistence.Tickets
{
    public interface INotificationsRepository : IGenericRepository<Notifications>
    {
        Task<List<Notifications>> GetNotificationsByTicket(int ticketId);
    }
}
