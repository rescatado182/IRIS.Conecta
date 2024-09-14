using IRIS.Conecta.Domain.Entities.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations
{
    public class FacultiesConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_Faculties");

            builder.HasIndex(e => e.FacultyName, "IX_Faculties_Name").IsUnique();

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.FacultyName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
