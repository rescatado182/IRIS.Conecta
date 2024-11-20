using IRIS.Conecta.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations.Tickets
{
    public class TicketsViewConfiguration : IEntityTypeConfiguration<TicketsView>
    {
        public void Configure(EntityTypeBuilder<TicketsView> builder)
        {
            builder
                .HasNoKey()
                .ToView("TicketsView");

            builder.Property(e => e.StartDateMovility).HasPrecision(0);
            builder.Property(e => e.StartDateRequirement).HasPrecision(0);

            builder.Property(e => e.EndDateMovility).HasPrecision(0);
            builder.Property(e => e.EndDateRequirement).HasPrecision(0);

            builder.Property(e => e.DeliveryDate).HasPrecision(0);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(e => e.ContactData).HasMaxLength(200);
            builder.Property(e => e.CountryName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("country_name");

            builder.Property(e => e.ManagerUserId).HasColumnName("ManagerUserId");
            builder.Property(e => e.Title).HasColumnName("Title");
            builder.Property(e => e.EventName).HasColumnName("EventName");
            builder.Property(e => e.RequestName).HasColumnName("RequestName");
            builder.Property(e => e.Department).HasColumnName("Department");
            builder.Property(e => e.FacultyName).HasColumnName("FacultyName");
            builder.Property(e => e.FullName).HasColumnName("FullName");
            builder.Property(e => e.AgreementName).HasColumnName("AgreementName");
            builder.Property(e => e.Description).HasColumnName("Description");
            builder.Property(e => e.IsAgreement).HasColumnName("IsAgreement");
            builder.Property(e => e.Results).HasColumnName("Results");
            builder.Property(e => e.MovilityType).HasColumnName("MovilityType");
            builder.Property(e => e.Country).HasColumnName("Country");
            builder.Property(e => e.City).HasColumnName("City");
            builder.Property(e => e.Phone).HasColumnName("Phone");
            builder.Property(e => e.ContactData).HasColumnName("ContactData");
            builder.Property(e => e.ExternalInstitution).HasColumnName("ExternalInstitution");
            builder.Property(e => e.ManagerUser).HasColumnName("ManagerUser");            
            builder.Property(e => e.Total).HasColumnName("Total");

            builder.Property(e => e.TicketRequirements)
                .HasColumnName("TicketRequirements")
                .HasMaxLength(300);
        }
    }
}
