using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IRIS.UI.Models.Save
{
    public class MovilityTypeSaveVM
    {

        public int id { get; set; }


        public string eventName { get; set; }

        public string title { get; set; }

        public TicketsStatus status { get; set; }

        public string movilityType { get; set; }

        //[Display(Name = "País de Destino")]
        //[Required(ErrorMessage = "*Selecciona un {0} válido")]
        //[Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
        //public int DestinationCountryId
        //{ get; set; }

        public string country { get; set; }




        //[Display(Name = "Departamento de Destino")]
        //[Required(ErrorMessage = "*Selecciona un {0} válido")]
        //[Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
        //public int DestinationStateId { get; set; }

        //[Display(Name = "Ciudad de Destino")]
        //[Required(ErrorMessage = "*Selecciona un {0} válido")]
        //[Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
        //public int DestinationCityId { get; set; }

        public string city { get; set; }


        [Display(Name = "Teléfonos")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "*{0} debe tener máximo {1} caracteres")]
        public string phone { get; set; }

        [Display(Name = "Datos de Contacto")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "*{0} debe tener máximo {1} caracteres")]
        public string contactData { get; set; }

        [Display(Name = "Institución de Destino")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "*{0} debe tener máximo {1} caracteres")]
        public string externalInstitution { get; set; }

        public DateOnly startDateMovility { get; set; }
        public DateOnly endDateMovility { get; set; }

        public string userId { get; set; }

        public string managerUserId { get; set; }


        //[JsonIgnore]
        //public virtual CountryVM DestinationCountry { get; set; }

        //[JsonIgnore]
        //public virtual StateVM DestinationState { get; set; }

        //[JsonIgnore]
        //public virtual CityVM DestinationCity { get; set; }
    }
}
