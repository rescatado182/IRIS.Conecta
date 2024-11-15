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

        public GetTicketsListByUserIdRequestHandler(IMapper mapper, ITicketsRepository ticketsRepository)
        {
            _mapper = mapper;
            _ticketsRepository = ticketsRepository;
        }

        public async Task<List<TicketsListDto>> Handle(GetTicketsListByUserIdRequest request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketsRepository.GetTicketsByUser(request.UserId);
            var data = _mapper.Map<List<TicketsListDto>>(tickets);

            return data;
            
        }
    }
}
