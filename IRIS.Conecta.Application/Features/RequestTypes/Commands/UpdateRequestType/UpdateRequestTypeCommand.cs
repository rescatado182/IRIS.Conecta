using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Commands.UpdateRequestType
{
    public class UpdateRequestTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string RequestName { get; set; }
        public int DepartmentId { get; set; }
    }
}
