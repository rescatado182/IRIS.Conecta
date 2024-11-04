using IRIS.Conecta.Domain.Entities.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations.GeoLocations
{
    public class CitiesConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Cities__3213E83FCFF12A69");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CountryCode)
                .IsRequired()
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("country_code");
            builder.Property(e => e.CountryId).HasColumnName("country_id");
            builder.Property(e => e.CountryName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("country_name");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValue(new DateTime(2014, 1, 1, 12, 1, 1, 0, DateTimeKind.Unspecified))
                .HasColumnName("created_at");
            builder.Property(e => e.Flag)
                .HasDefaultValue(true)
                .HasColumnName("flag");
            builder.Property(e => e.Latitude)
                .HasColumnType("decimal(10, 8)")
                .HasColumnName("latitude");
            builder.Property(e => e.Longitude)
                .HasColumnType("decimal(11, 8)")
                .HasColumnName("longitude");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
            builder.Property(e => e.StateCode)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("state_code");
            builder.Property(e => e.StateId).HasColumnName("state_id");
            builder.Property(e => e.StateName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("state_name");
            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            builder.Property(e => e.WikiDataId)
                .HasMaxLength(255)
                .HasColumnName("wikiDataId");

            builder.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cities_countries");

            builder.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cities_states");

        }
    }
}
