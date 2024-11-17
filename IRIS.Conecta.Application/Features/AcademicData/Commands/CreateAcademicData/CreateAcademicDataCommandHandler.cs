using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.AcademicData.Commands.CreateAcademicData
{
    public class CreateAcademicDataCommandHandler : IRequestHandler<CreateAcademicDataCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAcademicDataRepository _academicDataRepository;
        private readonly ITicketsRepository _ticketsRepository;

        public CreateAcademicDataCommandHandler(IMapper mapper, 
            IAcademicDataRepository academicDataRepository,
            ITicketsRepository ticketsRepository)
        {
            _mapper = mapper;
            _academicDataRepository = academicDataRepository;
            _ticketsRepository      = ticketsRepository;
        }
        public async Task<int> Handle(CreateAcademicDataCommand request, CancellationToken cancellationToken)
        {
            // Validate incomming data
            var validator = new CreateAcademicDataValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) {
                throw new BadRequestException("Invalid Personal Data", validationResult);
            }

            // Mapping Data
            var data = _mapper.Map<Domain.Entities.AcademicData>(request.AcademicDataDto);

            // Create the record
            await _academicDataRepository.CreateAsync(data);

            await this.SaveAcademicDataIdInTicket(request, data.Id);

            return data.Id;
        }

        private async Task SaveAcademicDataIdInTicket(CreateAcademicDataCommand createAcademicData, int AcademicDataId)
        {
            var dto = createAcademicData.AcademicDataDto;

            // Validate incomming data
            var ticket = await _ticketsRepository.GetByIdAsync(dto.TicketId);

            if (ticket is null)
            {
                throw new NotFoundException(nameof(ticket), AcademicDataId);
            }

            var ticketNew = new TicketBasicChangesDto
            {
                Id              = dto.TicketId,
                UserId          = dto.UserId,
                Title           = ticket.Title,
                Description     = ticket.Description,
                Status          = ticket.Status,
                RequestTypeId   = ticket.RequestTypeId,
                PersonalDataId  = ticket.PersonalDataId,
                AcademicDataId  = AcademicDataId                
            };

            var data = _mapper.Map<Domain.Entities.Tickets.Ticket>(ticketNew);
            await _ticketsRepository.UpdateAsync(data);
        }
    }
}
