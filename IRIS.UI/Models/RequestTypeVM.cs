using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models
{
    public class RequestTypeVM
    {
        public int Id { get; set; }

        //data anotation


        [Required(ErrorMessage = "El nombre del tipo de solicitud es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del tipo de solicitud no puede exceder los {0} caracteres")]
        public string RequestName { get; set; } = null!;
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "El departamento es requerido")]
        public DepartmentsVM Department { get; set; } = null!;


    }
}
