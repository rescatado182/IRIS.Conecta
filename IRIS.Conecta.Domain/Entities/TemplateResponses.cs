using IRIS.Conecta.Domain.Base;

namespace IRIS.Conecta.Domain.Entities
{
    public class TemplateResponses : BaseEntity
    {
        public int Id { get; set; }

        public required string TemplateName { get; set; }

        public int RequestTypeId { get; set; }

        public virtual required RequestType RequestType { get; set; }

    }
}
