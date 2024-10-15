using IRIS.Conecta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations
{
    public class RequestTypesConfiguration : IEntityTypeConfiguration<RequestType>
    {
        public void Configure(EntityTypeBuilder<RequestType> builder)
        {
            builder.ToTable("RequestTypes");

            builder.HasKey(e => e.Id).HasName("PK_RequestTypes");

            builder.HasIndex(e => e.RequestName, "IX_RequestTypes_DepartmentId_Name");

            builder.HasIndex(e => e.Id, "IX_RequestTypeId").IsUnique();

            builder.HasIndex(e => e.RequestName, "IX_RequestTypes_DepartmentId_Name");

            builder.Property(e => e.Id);
            builder.Property(e => e.DepartmentId);
            builder.Property(e => e.RequestName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(d => d.Department).WithMany(p => p.RequestTypes)
                .HasForeignKey(d => d.DepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestTypes_Departments_DepartmentId");

        }
    }
}
