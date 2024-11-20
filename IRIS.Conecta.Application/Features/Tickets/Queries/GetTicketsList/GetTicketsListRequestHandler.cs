using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsList
{
    public class GetTicketsListRequestHandler : IRequestHandler<GetTicketsListRequest, List<TicketsListDto>>
    {
        private readonly IMapper mapper;
        private readonly ITicketsRepository ticketsRepository;        

        public GetTicketsListRequestHandler(IMapper mapper, ITicketsRepository ticketsRepository)
        {
            this.mapper = mapper;
            this.ticketsRepository = ticketsRepository;
            
        }
        public async Task<List<TicketsListDto>> Handle(GetTicketsListRequest request, CancellationToken cancellationToken)
        {
            var tickets = await this.ticketsRepository.GetAsync();

            var data = this.mapper.Map<List<TicketsListDto>>(tickets);

            return data;
        }
    }
}
