using IRIS.Conecta.Domain.Entities.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations
{
    public class DepartmentsConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_Departments");

            builder.HasIndex(e => e.Id, "IX_Departments_Id").IsUnique();
            
            builder.HasIndex(e => e.FacultyId, "IX_Departments_FacultyId_Name");            

            builder.HasIndex(e => e.DepartmentName, "IX_Departments_DepartmentName")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.FacultyId).HasColumnName("FacultyId");
            builder.Property(e => e.DepartmentName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("Department");

            builder.HasOne(d => d.Faculty).WithMany(p => p.Departments)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departments_Faculties_FacultyId");
            
        }
    }
}
