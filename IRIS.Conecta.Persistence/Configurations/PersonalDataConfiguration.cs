using IRIS.Conecta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRIS.Conecta.Persistence.Configurations
{
    public class PersonalDataConfiguration : IEntityTypeConfiguration<PersonalData>
    {
        public void Configure(EntityTypeBuilder<PersonalData> builder)
        {
            builder.ToTable("PersonalData");

            builder.HasKey(e => e.Id).HasName("PK_PersonalData");

            builder.HasIndex(e => e.FullName, "IX_PersonalData_Fullname");

            builder.HasIndex(e => e.Id, "IX_PersonalData_Id").IsUnique();

            builder.HasIndex(e => e.DocumentNumber, "IX_PersonalData_DocumentNumber");
            builder.HasIndex(e => e.DocumentType, "IX_PersonalData_DocumentType");
            builder.HasIndex(e => e.UserId, "IX_PersonalData_UserId");

            builder.Property(e => e.Id);
            builder.Property(e => e.DocumentType)
                .HasColumnName("DocumentType")
                .IsRequired();

            builder.Property(e => e.DocumentNumber)
                .HasColumnName("DocumentNumber")
                .IsRequired();

            builder.Property(e => e.BornCountryId)
                .HasColumnName("BornCountryId")
                .IsRequired();

            builder.Property(e => e.BornCityId)
                .HasColumnName("BornCityId")
                .IsRequired();

            builder.Property(e => e.ResidenceCityId)
                .HasColumnName("ResidenceCityId")
                .IsRequired();

            builder.Property(e => e.PersonalEmail)
                .IsRequired()                
                .HasMaxLength(100);

            builder.Property(e => e.AddressResidence)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(e => e.Cellphone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.BirthDate).HasPrecision(0);

            builder.Property(e => e.Phone).HasMaxLength(15);

            builder.Property(e => e.UserId)
                .HasDefaultValue(false);

            builder.HasOne(d => d.BornCity).WithMany(p => p.PersonalDatas)
                .HasForeignKey(d => d.BornCityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonalDatas_Cities_BornCityId");

            builder.HasOne(d => d.BornCountry).WithMany(p => p.PersonalDatas)
                .HasForeignKey(d => d.BornCountryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonalDatas_Countries_BornCountryId");

            builder.HasOne(d => d.StateResidence).WithMany(p => p.PersonalDatas)
                .HasForeignKey(d => d.ResidenceStateId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonalDatas_States_ResidenceStateId");

            builder.HasOne(e => e.Ticket).WithOne(p => p.PersonalData)
                .HasForeignKey<PersonalData>(e => e.TicketId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonalData_Tickets_TicketId");



        }
    }
}
