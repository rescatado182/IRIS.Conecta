namespace IRIS.Conecta.Domain.Base
{
    public abstract class BaseEntity
    {
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
