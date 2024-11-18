using IRIS.Conecta.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations.Tickets
{
    public class NotificationsConfiguration : IEntityTypeConfiguration<Notifications>
    {
        public void Configure(EntityTypeBuilder<Notifications> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(e => e.Id).HasName("PK_Notifications");

            builder.HasIndex(e => e.TicketId, "IX_Notifications_TicketId");

            builder.HasIndex(e => e.Id, "IX_Notifications_Id").IsUnique();

            builder.HasIndex(e => e.NotificationType, "IX_Notifications_NotificationType");

            builder.Property(e => e.Id);
            builder.Property(e => e.SendEmail)
                .HasDefaultValue(false);

            builder.Property(e => e.NotificationType)
                .HasColumnName("NotificationType")
                .IsRequired();

            builder.Property(e => e.SendEmail)
                .HasColumnName("SendEmail");


            builder.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(300);
            
            builder.HasOne(d => d.Ticket).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.TicketId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_Tickets_TicketId");

            
        }
    }
}
