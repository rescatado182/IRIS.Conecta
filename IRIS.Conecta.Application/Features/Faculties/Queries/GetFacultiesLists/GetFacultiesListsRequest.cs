using IRIS.Conecta.Application.Features.Faculties.DTOs;
using MediatR;

namespace IRIS.Conecta.Application.Features.Faculties.Queries.GetFacultiesLists
{
    public class GetFacultiesListsRequest : IRequest<List<FacultiesDto>>
    {
    }
}
