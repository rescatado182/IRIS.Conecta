using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Commands.CreateDepartments
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; } = string.Empty;
    }
}
