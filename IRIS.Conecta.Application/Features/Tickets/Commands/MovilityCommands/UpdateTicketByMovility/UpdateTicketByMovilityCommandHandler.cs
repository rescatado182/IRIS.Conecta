using AutoMapper;
using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByMovility
{
    public class UpdateTicketByMovilityCommandHandler : IRequestHandler<UpdateTicketByMovilityCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly ITicketsRepository ticketsRepository;

        public UpdateTicketByMovilityCommandHandler(IMapper mapper, ITicketsRepository ticketsRepository)
        {
            this.mapper = mapper;
            this.ticketsRepository = ticketsRepository;
        }
        public async Task<Unit> Handle(UpdateTicketByMovilityCommand request, CancellationToken cancellationToken)
        {
            // Validate incomming data
            var ticket = await this.ticketsRepository.GetByIdAsync(request.Id);

            if (ticket is null) {
                throw new NotFoundException(nameof(ticket), request.Id);
            }

            var validator = new UpdateTicketByMovilityCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) {
                throw new ValidationException((IEnumerable<FluentValidation.Results.ValidationFailure>)validationResult);
            }

            // Mapping Data
            mapper.Map(request, ticket);
            await this.ticketsRepository.UpdateAsync(ticket);

            return Unit.Value;
        }
    }
}
