using IRIS.Conecta.Domain.Base;

namespace IRIS.Conecta.Domain.Entities.Masters
{
    public class RequestType : BaseEntity
    {
        public int RequestId { get; set; }
        public string RequestName { get; set; } = null!;
    }
}
