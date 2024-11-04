using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.PersonalData.Commands.CreatePersonalData
{
    public class CreatePersonalDataCommandHandler : IRequestHandler<CreatePersonalDataCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonalDataRepository _personalDataRepository;

        public CreatePersonalDataCommandHandler(IMapper mapper, IPersonalDataRepository personalDataRepository)
        {
            _mapper = mapper;
            _personalDataRepository = personalDataRepository;
        }
        public async Task<int> Handle(CreatePersonalDataCommand request, CancellationToken cancellationToken)
        {
            // Validate incomming data
            var validator = new CreatePersonalDataCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Personal Data", validationResult);

            // Mapping Data
            var data = _mapper.Map<Domain.Entities.PersonalData>(request.PersonalDataDto);

            // Create Data
            await _personalDataRepository.CreateAsync(data);

            return data.Id;
        }
    }
}
