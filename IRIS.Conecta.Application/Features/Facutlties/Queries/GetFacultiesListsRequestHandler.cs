using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.Facutlties.DTOs;
using MediatR;

namespace IRIS.Conecta.Application.Features.Facutlties.Queries
{
    public class GetFacultiesListsRequestHandler : IRequestHandler<GetFacultiesListsRequest, List<FacultiesDto>>
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;

        public GetFacultiesListsRequestHandler(IFacultyRepository facultyRepository, IMapper mapper)
        {
            _facultyRepository = facultyRepository;
            _mapper = mapper;
        }
        public async Task<List<FacultiesDto>> Handle(GetFacultiesListsRequest request, CancellationToken cancellationToken)
        {
            // Query Database
            var faculties = await _facultyRepository.GetAsync();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<FacultiesDto>>(faculties);

            return data;
            
        }
    }
}
