using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.PersonalData.Commands.CreatePersonalData
{
    public class CreatePersonalDataCommandHandler : IRequestHandler<CreatePersonalDataCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonalDataRepository _personalDataRepository;
        private readonly ITicketsRepository _ticketsRepository;

        public CreatePersonalDataCommandHandler(IMapper mapper, 
            IPersonalDataRepository personalDataRepository,
            ITicketsRepository ticketsRepository)
        {
            _mapper = mapper;
            _personalDataRepository = personalDataRepository;
            _ticketsRepository      = ticketsRepository;
        }
        public async Task<int> Handle(CreatePersonalDataCommand request, CancellationToken cancellationToken)
        {
            // Validate incomming data
            var validator = new CreatePersonalDataValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Personal Data", validationResult);

            // Mapping Data
            var data = _mapper.Map<Domain.Entities.PersonalData>(request.PersonalDataDto);

            // Create Data
            await _personalDataRepository.CreateAsync(data);

            await this.SavePersonalDataIdInTicket(request, data.Id);

            return data.Id;
        }

        private async Task SavePersonalDataIdInTicket(CreatePersonalDataCommand createPersonalData, int PersonalDataId)
        {
            var dto = createPersonalData.PersonalDataDto;

            // Validate incomming data
            var ticket = await _ticketsRepository.GetByIdAsync(dto.TicketId);

            if (ticket is null) {
                throw new NotFoundException(nameof(ticket), PersonalDataId);
            }

            var ticketNew = new TicketBasicChangesDto
            {
                Id              = dto.TicketId,
                UserId          = dto.UserId,
                Title           = ticket.Title,
                Description     = ticket.Description,
                Status          = ticket.Status,
                RequestTypeId   = ticket.RequestTypeId,
                PersonalDataId  = PersonalDataId,
                AcademicDataId  = ticket.AcademicDataId 
            };

            var data = _mapper.Map<Domain.Entities.Tickets.Ticket>(ticketNew);
            await _ticketsRepository.UpdateAsync(data);
        }
    }
}
