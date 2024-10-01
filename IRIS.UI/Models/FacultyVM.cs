using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models
{
    public class FacultiesVM
    {
        public int Id { get; set; }


        //datanotation

        [Required]
        [StringLength(100, ErrorMessage = "Faculty Name must be less than 50 characters")]
        public string FacultyName { get; set; } = null!;


    }
}
