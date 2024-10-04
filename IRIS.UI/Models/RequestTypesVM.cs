namespace IRIS.UI.Models
{
    public class RequestTypesVM
    {
        public int Id { get; set; }
        public string RequestName { get; set; } = null!;
        public int DepartmentId { get; set; }
        public DepartmentsVM Department { get; set; } = null!;


    }
}
