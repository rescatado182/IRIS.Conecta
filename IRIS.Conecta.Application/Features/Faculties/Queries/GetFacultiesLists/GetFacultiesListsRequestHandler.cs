using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Masters;
using IRIS.Conecta.Application.Features.Faculties.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Faculties.Queries.GetFacultiesLists
{
    public class GetFacultiesListsRequestHandler : IRequestHandler<GetFacultiesListsRequest, List<FacultiesListDto>>
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;

        public GetFacultiesListsRequestHandler(IFacultyRepository facultyRepository, IMapper mapper)
        {
            _facultyRepository = facultyRepository;
            _mapper = mapper;
        }
        public async Task<List<FacultiesListDto>> Handle(GetFacultiesListsRequest request, CancellationToken cancellationToken)
        {
            // Query Database
            var faculties = await _facultyRepository.GetAsync();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<FacultiesListDto>>(faculties);

            return data;

        }
    }
}
