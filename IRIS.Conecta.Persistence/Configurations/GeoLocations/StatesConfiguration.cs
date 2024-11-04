using IRIS.Conecta.Domain.Entities.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations.GeoLocations
{
    public class StatesConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__states__3213E83F220489F8");

            builder.ToTable("states");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CountryCode)
                .IsRequired()
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("country_code");
            builder.Property(e => e.CountryId).HasColumnName("country_id");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at");
            builder.Property(e => e.FipsCode)
                .HasMaxLength(255)
                .HasColumnName("fips_code");
            builder.Property(e => e.Flag)
                .HasDefaultValue(true)
                .HasColumnName("flag");
            builder.Property(e => e.Iso2)
                .HasMaxLength(255)
                .HasColumnName("iso2");
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
            builder.Property(e => e.Type)
                .HasMaxLength(191)
                .HasColumnName("type");
            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            builder.Property(e => e.WikiDataId)
                .HasMaxLength(255)
                .HasColumnName("wikiDataId");

            builder.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_states_countries");

        }
    }
}
