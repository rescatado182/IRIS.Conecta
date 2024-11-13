using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicket
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IRequestTypeRepository requestTypeRepository;
        private readonly ITicketsRepository ticketsRepository;

        public UpdateTicketCommandHandler(IMapper mapper,
            IRequestTypeRepository requestTypeRepository,
            ITicketsRepository ticketsRepository)
        {
            this.mapper = mapper;
            this.requestTypeRepository = requestTypeRepository;
            this.ticketsRepository = ticketsRepository;
        }
        public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            // Validate incomming data
            var ticket = await ticketsRepository.GetByIdAsync(request.Id);

            if (ticket is null) {
                throw new NotFoundException(nameof(ticket), request.Id);
            }

            var validator = new UpdateTicketCommandValidator(requestTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) {
                throw new ValidationException(validationResult);
            }

            // Mapping Data
            mapper.Map(request, ticket);
            await this.ticketsRepository.UpdateAsync(ticket);

            return Unit.Value;
        }
    }
}
