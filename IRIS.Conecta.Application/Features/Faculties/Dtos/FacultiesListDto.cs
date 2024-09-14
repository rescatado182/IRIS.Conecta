namespace IRIS.Conecta.Application.Features.Faculties.Dtos
{
    public class FacultiesListDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int DepartmentId { get; set; }

        public int DepartmentName { get; set; }
    }
}
