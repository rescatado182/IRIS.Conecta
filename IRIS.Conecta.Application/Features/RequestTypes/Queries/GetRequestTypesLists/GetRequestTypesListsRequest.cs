using IRIS.Conecta.Application.Features.RequestTypes.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Queries.GetRequestTypesLists
{
    public record GetRequestTypesListsRequest : IRequest<List<RequestTypesListDto>>
    {
        
    }
}
