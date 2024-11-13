using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsList
{
    public class GetTicketsListRequestHandler : IRequestHandler<GetTicketsListRequest, List<TicketsListDto>>
    {
        private readonly IMapper mapper;
        private readonly ITicketsViewRepository ticketsViewRepository;        

        public GetTicketsListRequestHandler(IMapper mapper, ITicketsViewRepository ticketsViewRepository)
        {
            this.mapper = mapper;
            this.ticketsViewRepository = ticketsViewRepository;
            
        }
        public async Task<List<TicketsListDto>> Handle(GetTicketsListRequest request, CancellationToken cancellationToken)
        {
            var tickets = await this.ticketsViewRepository.GetTicketsList();

            var data = this.mapper.Map<List<TicketsListDto>>(tickets);

            return data;
        }
    }
}
