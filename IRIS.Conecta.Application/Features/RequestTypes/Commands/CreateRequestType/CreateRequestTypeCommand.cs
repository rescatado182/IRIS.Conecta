using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Commands.CreateRequestType
{
    public class CreateRequestTypeCommand : IRequest<int>
    {
        public string RequestName { get; set; } = null!;
        public string Path { get; set; } = null!;
        public int DepartmentId { get; set; }
    }
}
