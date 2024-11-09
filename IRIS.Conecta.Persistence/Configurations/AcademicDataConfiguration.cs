using IRIS.Conecta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations
{
    public class AcademicDataConfiguration : IEntityTypeConfiguration<AcademicData>
    {
        public void Configure(EntityTypeBuilder<AcademicData> builder)
        {
            builder.ToTable("AcademicData");

            builder.HasKey(e => e.Id).HasName("PK_AcademicData");

            builder.HasIndex(e => e.Id, "IX_AcademicData_Id").IsUnique();

            builder.HasIndex(e => e.ProgramId, "IX_AcademicData_ProgramId");
            
            builder.HasIndex(e => e.TicketId, "IX_AcademicData_TicketIdId");
            builder.HasIndex(e => e.UserId, "IX_AcademicData_UserId");

            builder.Property(e => e.Id);
            builder.Property(e => e.ResearchProject)
                .HasColumnName("ResearchProject");

            builder.Property(e => e.ResearchGroup)
                .HasColumnName("ResearchGroup");

            builder.Property(e => e.ProgramType)
               .HasColumnName("ProgramType")
               .IsRequired();

            builder.Property(e => e.EnrolledSemester)
                .HasColumnName("EnrolledSemester")
                .IsRequired();

            builder.Property(e => e.IsInstitutionalGroup)
                .HasColumnName("InstitutionalGroup")
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasDefaultValue(false)
                .HasMaxLength(450);

            builder.HasOne(e => e.Ticket).WithOne(p => p.AcademicData)
                .HasForeignKey<AcademicData>(e => e.TicketId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcademicData_Tickets_TicketId");
        }
    }
}
