using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketById
{
    public class GetTicketByIdRequestHandler : IRequestHandler<GetTicketByIdRequest, TicketByIdDto>
    {
        private readonly IMapper mapper;
        private readonly ITicketsViewRepository ticketsViewRepository;

        public GetTicketByIdRequestHandler(IMapper mapper, 
            ITicketsViewRepository ticketsViewRepository)
        {
            this.mapper = mapper;
            this.ticketsViewRepository = ticketsViewRepository;
        }
        public async Task<TicketByIdDto> Handle(GetTicketByIdRequest request, CancellationToken cancellationToken)
        {
            var ticket = await this.ticketsViewRepository.GetTicketById(request.Id);

            if (ticket == null) {
                throw new NotFoundException(nameof(ticket), request.Id);
            }

            return this.mapper.Map<TicketByIdDto>(ticket);
        }
    }
}
