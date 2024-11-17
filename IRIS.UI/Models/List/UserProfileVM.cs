using System.Text.Json.Serialization;

namespace IRIS.UI.Models.List
{
    public class UserProfileVM
    {

            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string UserName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string PhoneNumber { get; set; } = string.Empty;
            public string DocumentNumber { get; set; } = string.Empty;
            public EnumDocumentType DocumentType { get; set; }
            public DateTime? BirthDate { get; set; }
            public int? BornCountryId { get; set; }
            public int? BornStateId { get; set; }
            public int? BornCityId { get; set; }
            public int? ResidenceStateId { get; set; }
            public int? ResidenceCityId { get; set; }
            public string  AddressResidence { get; set; } = string.Empty;

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
