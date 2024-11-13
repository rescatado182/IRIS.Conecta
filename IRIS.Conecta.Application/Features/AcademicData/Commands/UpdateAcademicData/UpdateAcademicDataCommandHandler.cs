using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.AcademicData.Commands.UpdateAcademicData
{
    internal class UpdateAcademicDataCommandHandler : IRequestHandler<UpdateAcademicDataCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAcademicDataRepository _academicDataRepository;
        private readonly ITicketsRepository _ticketsRepository;

        public UpdateAcademicDataCommandHandler(IMapper mapper, 
            IAcademicDataRepository academicDataRepository,
            ITicketsRepository ticketsRepository)
        {
            _mapper = mapper;
            _academicDataRepository = academicDataRepository;
            _ticketsRepository = ticketsRepository;
        }
        public async Task<Unit> Handle(UpdateAcademicDataCommand request, CancellationToken cancellationToken)
        {
            // Validate incomming data
            var validator = new UpdateAcademicDataValidator(_ticketsRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) {
                throw new BadRequestException("Invalid Personal Data", validationResult);
            }

            // Mapping data
            var data = _mapper.Map<Domain.Entities.AcademicData>(request);

            // Update record
            await _academicDataRepository.UpdateAsync(data);

            return Unit.Value;
        }
    }
}
