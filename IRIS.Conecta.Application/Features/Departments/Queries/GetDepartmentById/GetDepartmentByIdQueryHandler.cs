using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.Departments.DTOs;
using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IMapper mapper;
        private readonly IDepartmentRepository DepartmentRepository;

        public GetDepartmentByIdQueryHandler(IMapper mapper, IDepartmentRepository DepartmentRepository)
        {
            this.mapper                 = mapper;
            this.DepartmentRepository   = DepartmentRepository;
        }
        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var Department = await this.DepartmentRepository.GetByIdAsync(request.Id);

            return this.mapper.Map<DepartmentDto>(Department);
        }
    }
}
