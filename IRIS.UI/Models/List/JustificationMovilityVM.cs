using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models.List
{
    public class JustificationMovilityVM
    {
        // Convenio (S/A)


        [Display(Name = "Cite el convenio (S/A)")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "*{0} no puede tener más de {1} carácteres")]
        public string AgreementName { get; set; }

        // Objetivo de la solicitud

        [Display(Name = "Objetivo de la movilidad")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "*{0} no puede tener más de {1} carácteres")]
        public string Description { get; set; }
        
        public bool IsAgreement { get; set; }

        [Display(Name = "Productos a entregar en retribución")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "*{0} no puede tener más de {1} carácteres")]
        public string Results { get; set; }

        [Display(Name = "Fecha entrega compromisos")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        public DateOnly DeliveryDate { get; set; }
    }
}
