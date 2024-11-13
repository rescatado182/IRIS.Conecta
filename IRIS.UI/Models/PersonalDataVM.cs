using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IRIS.UI.Models
{
    public class PersonalDataVM
    {

        public int Id { get; set; }

        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "*{0} no puede tener más de {1} carácteres")]
        public string FullName { get; set; }

        [Display(Name = "Numero Documento")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [MaxLength(20, ErrorMessage = "*{0} no puede tener más de {1} carácteres")]
        public string DocumentNumber { get; set; }

        [Display(Name = "Tipo de Documento")]
        [Required(ErrorMessage = "*{0} es obligatorio")]
        [EnumDataType(typeof(EnumDocumentType), ErrorMessage = "*Seleccione un {0} válido")]
        public EnumDocumentType DocumentType { get; set; }

        [Display(Name = "País de Nacimiento")]
        [Required(ErrorMessage = "*Selecciona un {0} válido")]
        [Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
        public int BornCountryId { get; set; }

        [Display(Name = "Departamento de Nacimiento")]
        [Required(ErrorMessage = "*Selecciona un {0} válido")]
        [Range(1, int.MaxValue, ErrorMessage = "*Selecciona un {0} válido")]
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
        public string Email { get; set; }

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
