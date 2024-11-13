using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Domain.Entities.Tickets;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.CreateTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IRequestTypeRepository _requestTypeRepository;
        private readonly ITicketsRepository _ticketsRepository;

        public CreateTicketCommandHandler(IMapper mapper,
            IRequestTypeRepository requestTypeRepository,
            ITicketsRepository ticketsRepository)
        {
            _mapper                 = mapper;
            _requestTypeRepository  = requestTypeRepository;
            _ticketsRepository      = ticketsRepository;
        }
        public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            // Validate incomming data
            var validator = new CreateTicketCommandValidator(_requestTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if ( !validationResult.IsValid )
                throw new BadRequestException("Invalid Ticket", validationResult);

            // Mapping data
            var ticket = _mapper.Map<Ticket>(request);

            // Create the data
            await _ticketsRepository.CreateAsync(ticket);

            return ticket.Id;
        }
    }
}
