using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motto.MR.Shared.Models;

namespace Motto.MR.DataAccess.Mappings
{
    public class MotorcycleMap : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.ToTable("Motorcycles");

            builder.HasKey(mt => mt.Id);

            builder.Property(mt => mt.Id)
                .IsRequired()
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(mt => mt.Identifier)
                .IsRequired()
                .HasColumnName("Identifier")
                .HasMaxLength(50);

            builder.Property(mt => mt.Year)
                .IsRequired()
                .HasColumnName("Year");

            builder.Property(mt => mt.Model)
                .IsRequired()
                .HasColumnName("Model")
                .HasMaxLength(50);

            builder.Property(mt => mt.LicensePlate)
                .IsRequired()
                .HasColumnName("LicensePlate")
                .HasMaxLength(50);

            builder.HasIndex(mt => mt.LicensePlate)
                       .IsUnique();

        }
    }
}
