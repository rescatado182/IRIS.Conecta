using IRIS.Conecta.Domain.Entities.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations
{
    public class ProgramsConfiguration : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_Programs");

            builder.HasIndex(e => e.Id, "IX_Programs_Id").IsUnique();

            builder.HasIndex(e => e.DepartmentId, "IX_Programs_DepartmentId");

            builder.HasIndex(e => e.ProgramName, "IX_Programs_ProgramName").IsUnique();

            builder.HasIndex(e => e.ProgramType, "IX_Programs_ProgramType");

            builder.Property(e => e.Id).HasColumnName("Id");            
            builder.Property(e => e.ProgramName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ProgramType)
                .HasColumnName("ProgramType")
                .IsRequired();

            builder.HasOne(d => d.Department).WithMany(p => p.Programs)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Programs_Deparments_DepartmentId");
            
        }
    }
}
