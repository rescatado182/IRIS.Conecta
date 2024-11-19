using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsListByUserId
{
    public class GetTicketsListByUserIdRequestHandler : IRequestHandler<GetTicketsListByUserIdRequest,
        List<TicketsListDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITicketsRepository _ticketsRepository;
        private readonly ITicketsViewRepository _ticketsViewRepository;

        public GetTicketsListByUserIdRequestHandler(IMapper mapper, 
            ITicketsRepository ticketsRepository,
            ITicketsViewRepository ticketsViewRepository)
        {
            _mapper = mapper;
            _ticketsRepository      = ticketsRepository;
            _ticketsViewRepository  = ticketsViewRepository;
        }

        public async Task<List<TicketsListDto>> Handle(GetTicketsListByUserIdRequest request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketsViewRepository.GetTicketsByUser(request.UserId);
            var data = _mapper.Map<List<TicketsListDto>>(tickets);

            return data;
            
        }
    }
}
