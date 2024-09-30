using IRIS.Conecta.Application.Features.RequestTypes.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Queries.GetRequestTypeById
{
    public class GetRequestTypeByIdQuery : IRequest<RequestTypesDto>
    {
        public int Id { get; set; }
    }
}
