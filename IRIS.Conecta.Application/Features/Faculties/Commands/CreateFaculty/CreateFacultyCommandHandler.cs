using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities.Masters;
using MediatR;

namespace IRIS.Conecta.Application.Features.Faculties.Commands.CreateFaculty
{
    public class CreateFacultyCommandHandler : IRequestHandler<CreateFacultyCommand, int>
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;

        public CreateFacultyCommandHandler(IFacultyRepository facultyRepository, IMapper mapper)
        {
            _facultyRepository = facultyRepository;
            _mapper = mapper;
        }


        public async Task<int> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateFacultyCommandValidator(_facultyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if( !validationResult.IsValid ) {
                throw new Exception("Invalid Faculty record");
            }

            var faculty = _mapper.Map<Faculty>(request);

            await _facultyRepository.CreateAsync(faculty);

            return faculty.Id;

        }
    }
}
