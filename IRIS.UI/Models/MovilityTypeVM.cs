using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IRIS.UI.Models
{
    public class MovilityTypeVM
    {
        // create id y name

        //                {
        //                "id": 1,
        //  "eventName": "Nombre Evento",
        //  "status": "Open",
        //  "movilityType": "0",
        //  "country": "0",
        //  "city": "0",
        //  "phone": "3137984612",
        //  "contactData": "SDASDA",
        //  "externalInstitution": "itm",
        //  "startDate": "2024-10-22",
        //  "endDate": "2024-10-22"
        //}

        public int Id { get; set; }


        public string EventName { get; set; }

        public TicketsStatus Status { get; set; }


        [Display(Name = "Tipo de Movilidad")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [EnumDataType(typeof(EnumMovilityType), ErrorMessage = "*Seleccione un {0} válido")]
        public EnumMovilityType EnumMovilityType { get; set; }

        public string MovilityType { get; set; }

        [Display(Name = "País de Destino")]
        [Required(ErrorMessage = "*Selecciona un {0} válido")]
        [Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
        public int DestinationCountryId
        { get; set; }

        public string Country { get; set; }




        [Display(Name = "Departamento de Destino")]
        [Required(ErrorMessage = "*Selecciona un {0} válido")]
        [Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
        public int DestinationStateId { get; set; }

        [Display(Name = "Ciudad de Destino")]
        [Required(ErrorMessage = "*Selecciona un {0} válido")]
        [Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
        public int DestinationCityId { get; set; }

        public string City { get; set; }


        [Display(Name = "Teléfonos")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "*{0} debe tener máximo {1} caracteres")]
        public string Phone { get; set; }

        [Display(Name = "Datos de Contacto")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "*{0} debe tener máximo {1} caracteres")]
        public string ContactData { get; set; }

        [Display(Name = "Institución de Destino")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "*{0} debe tener máximo {1} caracteres")]
        public string externalInstitution { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }



        [JsonIgnore]
        public virtual CountryVM DestinationCountry { get; set; }

        [JsonIgnore]
        public virtual StateVM DestinationState { get; set; }

        [JsonIgnore]
        public virtual CityVM DestinationCity { get; set; }
    }
}
