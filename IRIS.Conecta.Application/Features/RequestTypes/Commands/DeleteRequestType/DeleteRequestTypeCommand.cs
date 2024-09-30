using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Commands.DeleteRequestType
{
    public class DeleteRequestTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
