namespace IRIS.Conecta.Application.Features.Departments.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int FacultyId { get; set; }
    }
}
