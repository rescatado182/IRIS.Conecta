namespace IRIS.Conecta.Application.Features.RequestTypes.Dtos
{
    public class RequestTypesDto
    {
        public int Id { get; set; }
        public string RequestName { get; set; } = null!;
        public string Path { get; set; }
        public int DepartmentId { get; set; }
    }
}
