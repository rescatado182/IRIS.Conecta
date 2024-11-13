using IRIS.Conecta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations
{
    class TemplateResponsesConfiguration : IEntityTypeConfiguration<TemplateResponses>
    {
        public void Configure(EntityTypeBuilder<TemplateResponses> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_TemplateResponses");

            builder.HasIndex(e => e.Id, "IX_TemplateResponses_Id").IsUnique();

            builder.HasIndex(e => e.RequestTypeId, "IX_TemplateResponses_RequestTypeId");

            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.TemplateName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("TemplateName");

            builder.HasOne(d => d.RequestType).WithMany(p => p.TemplateResponses)
                .HasForeignKey(d => d.RequestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TemplateResponses_RequestsType_RequestTypeId");
        }
    }
}
