using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models.List
{
    public class RequirementsMovilityVM
    {
        [Display(Name = "Requerimientos solicitados")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [EnumDataType(typeof(EnumTicketRequirements), ErrorMessage = "*Seleccione un {0} válido")]
        public EnumTicketRequirements RequirementsTypes { get; set; }

        public string RequirementsTypesDisplayName { get; set; }
        public DateOnly StartDateRequirement { get; set; }
        public DateOnly EndDateRequirement { get; set; }

        [Display(Name = "Valor de Inscripción")]
        [Required(ErrorMessage = "Por favor, selecciona un {0} válido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El {0} debe ser mayor que 0.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]

        public double Total { get; set; }
    }
}
