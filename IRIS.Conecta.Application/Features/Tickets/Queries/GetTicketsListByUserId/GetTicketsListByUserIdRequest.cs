using IRIS.Conecta.Application.Features.Tickets.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsListByUserId
{
    public class GetTicketsListByUserIdRequest : IRequest<List<TicketsListDto>>
    {
        public string UserId { get; set; }
    }
}
