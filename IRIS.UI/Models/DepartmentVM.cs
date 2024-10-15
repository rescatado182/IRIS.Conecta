using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models
{
    public class DepartmentsVM
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "El nombre del departamento es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del departamento no puede exceder los {0} caracteres")]
        public string DepartmentName { get; set; } = null!;
        public int FacultyId { get; set; }

        [Required(ErrorMessage = "La facultad es requerida")]
        public FacultyVM? Faculty { get; set; }
    }
}
