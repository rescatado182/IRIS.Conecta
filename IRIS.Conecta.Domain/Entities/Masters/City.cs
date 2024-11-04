namespace IRIS.Conecta.Domain.Entities.Masters;

public partial class City
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int StateId { get; set; }

    public string? StateCode { get; set; }

    public string? StateName { get; set; }

    public int CountryId { get; set; }

    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool Flag { get; set; }

    public string? WikiDataId { get; set; }

    #region Relationships

    public virtual required Country Country { get; set; }

    public virtual required State State { get; set; }

    public virtual ICollection<PersonalData> PersonalDatas { get; set; } = [];

    #endregion
}
