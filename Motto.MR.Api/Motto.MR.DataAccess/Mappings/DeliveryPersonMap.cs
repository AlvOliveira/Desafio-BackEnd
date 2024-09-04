using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motto.MR.Shared.Models;

namespace Motto.MR.DataAccess.Mappings
{
    public class DeliveryPersonMap : IEntityTypeConfiguration<DeliveryPerson>
    {
        public void Configure(EntityTypeBuilder<DeliveryPerson> builder)
        {
            builder.ToTable("DeliveryPersons");
            builder.HasKey(dp => dp.Id);

            builder.Property(dp => dp.Id)
                .IsRequired()
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(dp => dp.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(150);

            builder.Property(dp => dp.Cnpj)
                .IsRequired()
                .HasColumnName("Cnpj")
                .HasMaxLength(50);

            builder.Property(dp => dp.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate");

            builder.Property(dp => dp.DriverLicenseNumber)
                .IsRequired()
                .HasColumnName("DriverLicenseNumber")
                .HasMaxLength(50);

            builder.Property(dp => dp.DriverLicenseType)
                .IsRequired()
                .HasColumnName("DriverLicenseType")
                .HasMaxLength(50);

            builder.Property(dp => dp.DriverLicenseImagePath)
                .IsRequired()
                .HasColumnName("DriverLicenseImagePath")
                .HasMaxLength(255);

            builder.HasIndex(dp => dp.Cnpj)
                 .IsUnique();

            builder.HasIndex(dp => dp.DriverLicenseNumber)
                .IsUnique();
        }
    }
}
