using IRIS.Conecta.Application.Features.Faculties.Dtos;

namespace IRIS.Conecta.Application.Features.Departments.DTOs
{
    public class DepartmentsListDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int FacultyId { get; set; }
        public required FacultiesDto Faculty { get; set; }

    }
}
