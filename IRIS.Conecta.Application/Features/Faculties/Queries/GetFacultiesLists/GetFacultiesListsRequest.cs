using IRIS.Conecta.Application.Features.Faculties.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Faculties.Queries.GetFacultiesLists
{
    public class GetFacultiesListsRequest : IRequest<List<FacultiesListDto>>
    {
    }
}
