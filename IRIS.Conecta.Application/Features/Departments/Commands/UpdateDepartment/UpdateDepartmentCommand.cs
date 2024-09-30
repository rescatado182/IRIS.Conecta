using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int FacultyId { get; set; }
    }
}
