using IRIS.Conecta.Domain.Entities.Tickets;

namespace IRIS.Conecta.Application.Contracts.Persistence.Tickets
{
    public interface ITicketsViewRepository : IGenericRepository<TicketsView>
    {
        Task<List<TicketsView>> GetTicketsByUser(string userId);
        Task<TicketsView> GetTicketById(int ticketId);
    }
}
