using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public string DepartmentName { get; set; } = string.Empty;
        public int FacultyId { get; set; }
    }
}
