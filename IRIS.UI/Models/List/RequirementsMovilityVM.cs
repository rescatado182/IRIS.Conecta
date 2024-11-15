using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models.List
{
    public class RequirementsMovilityVM
    {
        //[Display(Name = "Tipos de Requerimiento")]
        //[Required(ErrorMessage = "*{0} es obligatorio")]
        //[EnumDataType(typeof(EnumRequirementsTypes), ErrorMessage = "*Seleccione un {0} válido")]
        public EnumRequirementsTypes RequirementsTypes { get; set; }

        public string RequirementsTypesDisplayName { get; set; }
        public DateOnly StartDateRequirement { get; set; }
        public DateOnly EndDateRequirement { get; set; }
        public double Total { get; set; }
    }
}
