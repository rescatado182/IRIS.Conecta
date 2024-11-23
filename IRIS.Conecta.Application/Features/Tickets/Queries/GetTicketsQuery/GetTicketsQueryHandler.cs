using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsQuery
{
    public class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, List<TicketsListDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITicketsRepository _ticketsRepository;

        public GetTicketsQueryHandler(IMapper mapper, ITicketsRepository ticketsRepository)
        {
            _mapper = mapper;
            _ticketsRepository = ticketsRepository;
        }
        public async Task<List<TicketsListDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketsRepository.GetAsync();

            var data = _mapper.Map<List<TicketsListDto>>(tickets);

            return data;
        }
    }
}
