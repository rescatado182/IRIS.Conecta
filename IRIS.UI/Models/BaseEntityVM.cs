namespace IRIS.UI.Models
{
    public class BaseEntityVM
    {
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
