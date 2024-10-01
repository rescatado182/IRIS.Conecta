using IRIS.Conecta.Application.Features.Departments.DTOs;
using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Queries.GetDepartmentsLists
{
    public class GetDepartmentsListsRequest : IRequest<List<DepartmentsListDto>>
    {
    }
}
