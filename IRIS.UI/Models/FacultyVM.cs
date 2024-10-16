using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models
{
    public class FacultyVM
    { 
        public int Id { get; set; }


        [Required(ErrorMessage = "El nombre de la facultad es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la facultad no puede exceder los {0} caracteres")]
        public string FacultyName { get; set; } = null!;


    }
}
