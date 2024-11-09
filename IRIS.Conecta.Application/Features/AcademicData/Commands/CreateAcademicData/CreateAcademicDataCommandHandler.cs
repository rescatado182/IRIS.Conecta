using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.AcademicData.Commands.CreateAcademicData
{
    public class CreateAcademicDataCommandHandler : IRequestHandler<CreateAcademicDataCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAcademicDataRepository _academicDataRepository;

        public CreateAcademicDataCommandHandler(IMapper mapper, IAcademicDataRepository academicDataRepository)
        {
            _mapper = mapper;
            _academicDataRepository = academicDataRepository;
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

            return data.Id;
        }
    }
}
