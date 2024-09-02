using IRIS.Conecta.Application.Features.Facutlties.DTOs;
using MediatR;

namespace IRIS.Conecta.Application.Features.Facutlties.Queries
{
    public class GetFacultiesListsRequest : IRequest<List<FacultiesDto>>
    {
    }
}
