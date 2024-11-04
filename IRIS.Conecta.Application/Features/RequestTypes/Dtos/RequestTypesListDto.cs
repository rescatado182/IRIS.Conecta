using IRIS.Conecta.Domain.Entities.Masters;
using System.Text.Json.Serialization;

namespace IRIS.Conecta.Application.Features.RequestTypes.Dtos
{
    public class RequestTypesListDto
    {
        public int Id { get; set; }
        public string RequestName { get; set; } = null!;
        public string Path { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
