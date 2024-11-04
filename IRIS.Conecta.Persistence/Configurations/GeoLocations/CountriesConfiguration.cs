using IRIS.Conecta.Domain.Entities.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations.GeoLocations
{
    public class CountriesConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Countrie__3213E83FA74F3AF0");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Capital)
                .HasMaxLength(255)
                .HasColumnName("capital");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.Currency)
                .HasMaxLength(255)
                .HasColumnName("currency");
            builder.Property(e => e.CurrencyName)
                .HasMaxLength(255)
                .HasColumnName("currency_name");
            builder.Property(e => e.CurrencySymbol)
                .HasMaxLength(255)
                .HasColumnName("currency_symbol");
            builder.Property(e => e.Emoji)
                .HasMaxLength(191)
                .HasColumnName("emoji");
            builder.Property(e => e.EmojiU)
                .HasMaxLength(191)
                .HasColumnName("emojiU");
            builder.Property(e => e.Flag)
                .HasDefaultValue(true)
                .HasColumnName("flag");
            builder.Property(e => e.Iso2)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("iso2");
            builder.Property(e => e.Iso3)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("iso3");
            builder.Property(e => e.Latitude)
                .HasColumnType("decimal(10, 8)")
                .HasColumnName("latitude");
            builder.Property(e => e.Longitude)
                .HasColumnType("decimal(11, 8)")
                .HasColumnName("longitude");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");
            builder.Property(e => e.Nationality)
                .HasMaxLength(255)
                .HasColumnName("nationality");
            builder.Property(e => e.Native)
                .HasMaxLength(255)
                .HasColumnName("native");
            builder.Property(e => e.NumericCode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("numeric_code");
            builder.Property(e => e.Phonecode)
                .HasMaxLength(255)
                .HasColumnName("phonecode");
            builder.Property(e => e.Region)
                .HasMaxLength(255)
                .HasColumnName("region");
            builder.Property(e => e.RegionId).HasColumnName("region_id");
            builder.Property(e => e.Subregion)
                .HasMaxLength(255)
                .HasColumnName("subregion");
            builder.Property(e => e.SubregionId).HasColumnName("subregion_id");
            builder.Property(e => e.Timezones).HasColumnName("timezones");
            builder.Property(e => e.Tld)
                .HasMaxLength(255)
                .HasColumnName("tld");
            builder.Property(e => e.Translations).HasColumnName("translations");
            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            builder.Property(e => e.WikiDataId)
                .HasMaxLength(255)
                .HasColumnName("wikiDataId");
        }
    }
}
