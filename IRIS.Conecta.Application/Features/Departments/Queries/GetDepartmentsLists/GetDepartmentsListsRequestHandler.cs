using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.Departments.DTOs;
using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Queries.GetDepartmentsLists
{
    public class GetDepartmentsListsRequestHandler : IRequestHandler<GetDepartmentsListsRequest, List<DepartmentsListDto>>
    {
        private readonly IDepartmentRepository _DepartmentRepository;
        private readonly IMapper _mapper;

        public GetDepartmentsListsRequestHandler(IDepartmentRepository DepartmentRepository, IMapper mapper)
        {
            _DepartmentRepository = DepartmentRepository;
            _mapper = mapper;
        }

        public async Task<List<DepartmentsListDto>> Handle(GetDepartmentsListsRequest request, CancellationToken cancellationToken)
        {
            // Query Database
            var Departments = await _DepartmentRepository.GetDepartmentsWithFaculties();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<DepartmentsListDto>>(Departments);

            return data;

        }
    }
}
