using IRIS.Conecta.Application.Features.Departments.DTOs;
using IRIS.Conecta.Application.Features.Faculties.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.Features.Departments.Queries.GetDepartmentsLists
{
    public class GetDepartmentsListsRequest : IRequest<List<DepartmentsListDto>>
    {
    }
}
