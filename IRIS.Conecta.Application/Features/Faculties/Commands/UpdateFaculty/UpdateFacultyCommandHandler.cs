using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities.Masters;
using MediatR;

namespace IRIS.Conecta.Application.Features.Faculties.Commands.UpdateFaculty
{
    public class UpdateFacultyCommandHandler : IRequestHandler<UpdateFacultyCommand, Unit>
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;

        public UpdateFacultyCommandHandler(IFacultyRepository facultyRepository, IMapper mapper)
        {
            _facultyRepository = facultyRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new UpdateFacultyCommandValidator(_facultyRepository);
            var validationResult = validator.ValidateAsync(request);

            if (!validationResult.IsCompletedSuccessfully) {
                throw new Exception("Faculty record invalid");
            }

            // convert to domain entity object
            var faculty = _mapper.Map<Faculty>(request);

            await _facultyRepository.UpdateAsync(faculty);

            return Unit.Value;
        }
    }
}
