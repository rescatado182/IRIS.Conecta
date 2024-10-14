using IRIS.Conecta.Application.Features.Tickets.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketById
{
    public class GetTicketByIdRequest : IRequest<TicketByIdDto>
    {
        public int Id { get; set; }       
    }
}
