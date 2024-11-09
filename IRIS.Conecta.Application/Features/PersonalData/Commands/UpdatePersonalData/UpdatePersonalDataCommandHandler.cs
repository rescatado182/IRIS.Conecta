using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.PersonalData.Commands.UpdatePersonalData
{
    public class UpdatePersonalDataCommandHandler : IRequestHandler<UpdatePersonalDataCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPersonalDataRepository _personalDataRepository;
        private readonly ITicketsRepository _ticketsRepository;

        public UpdatePersonalDataCommandHandler(IMapper mapper, 
            IPersonalDataRepository personalDataRepository,
            ITicketsRepository ticketsRepository)
        {
            _mapper                 = mapper;
            _personalDataRepository = personalDataRepository;
            _ticketsRepository      = ticketsRepository;
        }
        public async Task<Unit> Handle(UpdatePersonalDataCommand request, CancellationToken cancellationToken)
        {
            // Validate exists
            var personalData = await _personalDataRepository.GetByIdAsync(request.Id);

            if (personalData is null)            
                throw new NotFoundException(nameof(personalData), request.Id);

            // Validate incomming data
            var validator = new UpdatePersonalDataValidator(_ticketsRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if ( !validationResult.IsValid ) {
                throw new ValidationException(validationResult);
            }

            // Mapping Data
            _mapper.Map(request.PersonalDataDto, personalData);
            

            // Update Data
            await _personalDataRepository.UpdateAsync(personalData);

            return Unit.Value;
        }
    }
}
