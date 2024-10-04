namespace IRIS.UI.Models
{
    public class DepartmentsVM
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int FacultyId { get; set; }
        public FacultiesVM? Faculty { get; set; }
    }
}
