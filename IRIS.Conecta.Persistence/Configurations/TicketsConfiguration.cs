using IRIS.Conecta.Domain.Entities;
using IRIS.Conecta.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations
{
    public class TicketsConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(e => e.Id).HasName("PK_Tickets");

            builder.HasIndex(e => e.Title, "IX_Ticket_Title");

            builder.HasIndex(e => e.Id, "IX_Ticket_Id").IsUnique();

            builder.HasIndex(e => e.Status, "IX_Ticket_Status");

            builder.Property(e => e.Id);
            builder.Property(e => e.RequestTypeId);
            builder.Property(e => e.UserId);
            builder.Property(e => e.ManagerUserId);

            builder.Property(e => e.Status)
                .HasColumnName("Status")
                .IsRequired();

            builder.Property(e => e.TicketRequirements)
                .HasColumnName("TicketRequirements");                

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(e => e.Country);
            builder.Property(e => e.City);
            builder.Property(e => e.Results);
            builder.Property(e => e.MovilityType);
            builder.Property(e => e.Phone).HasMaxLength(20);
            builder.Property(e => e.ContactData).HasMaxLength(200);
            builder.Property(e => e.ExternalInstitution).HasMaxLength(100);

            builder.Property(e => e.IsAgreement)
                .HasDefaultValue(false);

            builder.Property(e => e.StartDateMovility).HasPrecision(0);
            builder.Property(e => e.EndDateMovility).HasPrecision(0);

            builder.Property(e => e.StartDateRequirement).HasPrecision(0);
            builder.Property(e => e.EndDateRequirement).HasPrecision(0);

            builder.Property(e => e.DeliveryDate).HasPrecision(0);

            builder.Property(e => e.Total).HasColumnType("float");

            builder.HasOne(d => d.RequestType).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.RequestTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_RequestTypes_RequestTypeId");

            builder.HasOne(d => d.PersonalData).WithOne(p => p.Ticket)
                .HasForeignKey<PersonalData>(d => d.TicketId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonalData_Tickets_TicketId");
        }
    }
}
