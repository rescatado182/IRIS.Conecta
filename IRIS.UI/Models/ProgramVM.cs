using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models
{
    public class ProgramVM
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "El nombre del programa es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del programa no puede exceder los {0} caracteres")]
        public string ProgramName { get; set; } = null!;

        public int FacultyId { get; set; }
    }
}
