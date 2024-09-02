namespace IRIS.Conecta.Application.Features.Facutlties.DTOs
{
    public class FacultiesDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int DepartmentId { get; set; }

        public int DepartmentName { get; set; }
    }
}
