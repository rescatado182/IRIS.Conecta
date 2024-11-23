using IRIS.Conecta.Application.Features.Tickets.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsQuery
{
    public class GetTicketsQuery : IRequest<List<TicketsListDto>>
    {
    }
}
