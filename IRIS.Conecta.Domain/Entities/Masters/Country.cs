namespace IRIS.Conecta.Domain.Entities.Masters;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Iso3 { get; set; }

    public string? NumericCode { get; set; }

    public string? Iso2 { get; set; }

    public string? Phonecode { get; set; }

    public string? Capital { get; set; }

    public string? Currency { get; set; }

    public string? CurrencyName { get; set; }

    public string? CurrencySymbol { get; set; }

    public string? Tld { get; set; }

    public string? Native { get; set; }

    public string? Region { get; set; }

    public int? RegionId { get; set; }

    public string? Subregion { get; set; }

    public int? SubregionId { get; set; }

    public string? Nationality { get; set; }

    public string? Timezones { get; set; }

    public string? Translations { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string? Emoji { get; set; }

    public string? EmojiU { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool Flag { get; set; }

    public string? WikiDataId { get; set; }

    #region Relationships

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<State> States { get; set; } = new List<State>();

    public virtual ICollection<PersonalData> PersonalDatas { get; set; } = [];

    #endregion
}
