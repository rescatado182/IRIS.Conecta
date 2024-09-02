using IRIS.Conecta.Application.Features.RequestTypes.DTOs.RequestTypes;
using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Queries.GetRequestTypesLists
{
    public record GetRequestTypesListsRequest : IRequest<List<RequestTypesDTO>>
    {
        
    }
}
