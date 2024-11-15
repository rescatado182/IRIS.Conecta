using IRIS.Conecta.Domain.Entities.Tickets;

namespace IRIS.Conecta.Application.Contracts.Persistence.Tickets
{
    public interface ITicketsRepository : IGenericRepository<Ticket>
    {
        Task<List<Ticket>> GetTicketsByUser(string userId);
    }
}
