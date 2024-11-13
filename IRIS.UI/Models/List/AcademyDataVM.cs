using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IRIS.UI.Models.List
{
    public class AcademyDataVM
    {
        public int Id { get; set; }

        [Display(Name = "Facultad")]
        [Required(ErrorMessage = "*Selecciona una {0} válida")]
        [Range(1, int.MaxValue, ErrorMessage = "*Selecciona una {0} válida")]
        public int FacultyId { get; set; }

        [Display(Name = "Programa")]
        [Required(ErrorMessage = "*Selecciona un {0} válido")]
        [Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
        public int ProgramId { get; set; }


        [Display(Name = "Proyecto de investigación")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "*{0} no puede tener más de {1} carácteres")]
        public string ResearchProject { get; set; }


        [Display(Name = "Promedio crédito")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [Range(0, 5, ErrorMessage = "El promedio debe estar entre 0 y 5.")]
        public double AverageCredit { get; set; }

        [Display(Name = "Tipo de formación")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [EnumDataType(typeof(EnumProgramType), ErrorMessage = "*Seleccione un {0} válido")]
        public EnumProgramType ProgramType { get; set; }

        [Display(Name = "Semestre Matriculado")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [Range(0, 10, ErrorMessage = "El semestre debe estar entre 0 y 10")]
        public int EnrolledSemester { get; set; }

        [Display(Name = "G. de investigación/Semillero")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "*{0} no puede tener más de {1} carácteres")]
        public string ResearchGroup { get; set; }

        [Display(Name = "Pertenece a algún grupo cultural o deportivo institucional")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        public bool IsInstitutionalGroup { get; set; }

        [JsonIgnore]
        public virtual FacultyVM Faculties { get; set; }

        [JsonIgnore]
        public virtual ProgramVM Program { get; set; }

    }
}
