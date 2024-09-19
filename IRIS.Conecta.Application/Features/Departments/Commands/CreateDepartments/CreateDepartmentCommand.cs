using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Commands.CreateDepartments
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
