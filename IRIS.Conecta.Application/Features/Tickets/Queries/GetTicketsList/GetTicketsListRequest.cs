using IRIS.Conecta.Application.Features.Tickets.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsList
{
    public record GetTicketsListRequest : IRequest<List<TicketsListDto>>
    {
    }
}
