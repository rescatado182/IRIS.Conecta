using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
