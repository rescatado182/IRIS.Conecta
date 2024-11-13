using IRIS.Conecta.Domain.Base;
using IRIS.Conecta.Domain.Entities.Masters;
using IRIS.Conecta.Domain.Entities.Tickets;

namespace IRIS.Conecta.Domain.Entities
{
    public class RequestType : BaseEntity
    {
        public int Id { get; set; }
        public string RequestName { get; set; } = null!;
        public string? Path { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;

        public virtual ICollection<TemplateResponses> TemplateResponses { get; set; } = [];
        public virtual ICollection<Ticket> Tickets { get; set; } = [];




    }
}
