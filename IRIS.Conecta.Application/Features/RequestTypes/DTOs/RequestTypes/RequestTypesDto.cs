namespace IRIS.Conecta.Application.Features.RequestTypes.DTOs.RequestTypes
{
    public class RequestTypesDTO
    {
        public int RequestId { get; set; }
        public string RequestName { get; set; } = null!;

        public DateTime? DateModified { get; set; }
    }
}
