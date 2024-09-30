using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.Departments.DTOs;
using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IMapper mapper;
        private readonly IDepartmentRepository departmentRepository;

        public GetDepartmentByIdQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            this.mapper                 = mapper;
            this.departmentRepository   = departmentRepository;
        }
        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await this.departmentRepository.GetByIdAsync(request.Id);

            return this.mapper.Map<DepartmentDto>(department);
        }
    }
}
