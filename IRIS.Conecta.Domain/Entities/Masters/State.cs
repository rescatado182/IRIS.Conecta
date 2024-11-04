namespace IRIS.Conecta.Domain.Entities.Masters;

public partial class State
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int CountryId { get; set; }

    public string? CountryCode { get; set; }

    public string? FipsCode { get; set; }

    public string? Iso2 { get; set; }

    public string? Type { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool Flag { get; set; }

    public string? WikiDataId { get; set; }

    #region Relationships

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual required Country Country { get; set; }

    public virtual ICollection<PersonalData> PersonalDatas { get; set; } = [];

    #endregion
}
