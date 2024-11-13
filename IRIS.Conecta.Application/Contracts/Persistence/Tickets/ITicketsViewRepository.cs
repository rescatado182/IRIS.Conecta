using IRIS.Conecta.Application.Features.Tickets.Dtos;
using IRIS.Conecta.Domain.Entities.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.Contracts.Persistence.Tickets
{
    public interface ITicketsViewRepository : IGenericRepository<TicketsView>
    {
        Task<List<TicketsView>> GetTicketsList();
    }
}
