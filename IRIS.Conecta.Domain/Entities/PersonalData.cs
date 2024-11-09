using IRIS.Conecta.Domain.Base;
using IRIS.Conecta.Domain.Entities.Masters;
using IRIS.Conecta.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IRIS.Conecta.Domain.Entities;

public class PersonalData : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? FullName { get; set; } = null;
    public string? DocumentNumber { get; set; }
    public DocumentType DocumentType { get; set; }
    public DateOnly BirthDate { get; set; }
    public int BornCountryId { get; set; }
    public int BornStateId { get; set; }
    public int BornCityId { get; set; }
    public int ResidenceStateId { get; set; }
    public int ResidenceCityId { get; set; }
    public string? AddressResidence { get; set; }
    public string? PersonalEmail { get; set; }
    public string? Phone { get; set; }
    public required string Cellphone { get; set; }
    public required string UserId { get; set; }
    public int? TicketId { get; set; }

    #region Relationships

    [JsonIgnore]
    public virtual Country? BornCountry { get; set; }

    [JsonIgnore]
    public virtual State? BornState { get; set; }

    [JsonIgnore]
    public virtual City? BornCity { get; set; }

    [JsonIgnore]
    public State? StateResidence { get; set; }

    [JsonIgnore]
    public City? CityResidence { get; set; }

    public virtual Ticket? Ticket { get; set; }

    #endregion
}
