using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.Departments.DTOs;
using IRIS.Conecta.Application.Features.Faculties.Dtos;
using IRIS.Conecta.Application.Features.Faculties.Queries.GetFacultiesLists;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.Features.Departments.Queries.GetDepartmentsLists
{
    public class GetDepartmentsListsRequestHandler : IRequestHandler<GetDepartmentsListsRequest, List<DepartmentsListDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;


        public GetDepartmentsListsRequestHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<DepartmentsListDto>> Handle(GetDepartmentsListsRequest request, CancellationToken cancellationToken)
        {
            // Query Database
            var departments = await _departmentRepository.GetAsync();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<DepartmentsListDto>>(departments);

            return data;

        }
    }
}
