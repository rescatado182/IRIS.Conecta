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
        private readonly ITicketsRepository ticketsRepository;

        public GetTicketByIdRequestHandler(IMapper mapper, ITicketsRepository ticketsRepository)
        {
            this.mapper = mapper;
            this.ticketsRepository = ticketsRepository;
        }
        public async Task<TicketByIdDto> Handle(GetTicketByIdRequest request, CancellationToken cancellationToken)
        {
            var ticket = await this.ticketsRepository.GetByIdAsync(request.Id);

            if (ticket == null) {
                throw new NotFoundException(nameof(ticket), request.Id);
            }

            return this.mapper.Map<TicketByIdDto>(ticket);
        }
    }
}
