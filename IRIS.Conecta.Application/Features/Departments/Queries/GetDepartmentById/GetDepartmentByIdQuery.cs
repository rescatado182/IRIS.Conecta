using IRIS.Conecta.Application.Features.Departments.DTOs;
using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<DepartmentDto>
    {
        public int Id { get; set; }
    }
}
