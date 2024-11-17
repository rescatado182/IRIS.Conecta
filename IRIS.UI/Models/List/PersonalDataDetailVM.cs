using IRIS.UI.Pages.BL.Tickets.Shared;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TabBlazor;

namespace IRIS.UI.Models.List
{
    public class PersonalDataDetailVM
    {

        public int Id { get; set; }

        public string FullName { get; set; }

        public string DocumentNumber { get; set; }

        public string DocumentType { get; set; }

        public int BornCountryId { get; set; }

        public int BornStateId { get; set; }

        [Display(Name = "Ciudad de Nacimiento")]
        [Required(ErrorMessage = "*Selecciona un {0} válido")]
        [Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
        public int BornCityId { get; set; }


        [Display(Name = "Departamento de Residencia")]
        [Required(ErrorMessage = "*Selecciona un {0} válido")]
        [Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
        public int ResidenceStateId { get; set; }

        [Display(Name = "Ciudad de Residencia")]
        [Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
        public int ResidenceCityId { get; set; }

        [Display(Name = "Dirección de Residencia")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "*{0} no puede tener más de {1} carácteres")]
        public string AddressResidence { get; set; }

        [Display(Name = "Correo electronico")]
        [MaxLength(100, ErrorMessage = "*{0} debe tener máximo {1} caracteres")]
        public string PersonalEmail { get; set; }


        //[Display(Name = "Correo electronico ITM")]
        //[Required(ErrorMessage = "*{0} es obligatorio")]
        //[MaxLength(100, ErrorMessage = "*{0} debe tener máximo {1} caracteres")]

        //public string EmailInstitutional { get; set; }

        [Display(Name = "Telefono")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "*Selecciona un {0} válido")]
        [MaxLength(10, ErrorMessage = "*{0} debe tener máximo {1} caracteres")]
        [RegularExpression(@"\+?(\d{1,3})?[-.\s]?(\(\d{1,4}\)|\d{1,4})[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}")]
        public string Phone { get; set; }


        [Display(Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "*Selecciona un {0} válido")]
        [MaxLength(15, ErrorMessage = "*{0} debe tener máximo {1} caracteres")]
        [RegularExpression(@"\+?(\d{1,3})?[-.\s]?(\(\d{1,4}\)|\d{1,4})[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}")]
        public string Cellphone { get; set; }

        public int TicketId { get; set; }

        [JsonIgnore]
        public virtual CountryVM BornCountry { get; set; }

        [JsonIgnore]
        public virtual StateVM BornState { get; set; }

        [JsonIgnore]
        public virtual CityVM BornCity { get; set; }

        [JsonIgnore]
        public StateVM StateResidence { get; set; }

        [JsonIgnore]
        public CityVM CityResidence { get; set; }

    }
}
