using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motto.MR.Shared.Models;

namespace Motto.MR.DataAccess.Mappings
{
    public class RentalMap : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("Rentals");

            builder.HasKey(rt => rt.Id);

            builder.Property(rt => rt.Id)
                .IsRequired()
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(rt => rt.MotorcycleId)
                .IsRequired()
                .HasColumnName("MotorcycleId");

            builder.Property(rt => rt.DeliveryPersonId)
                .IsRequired()
                .HasColumnName("DeliveryPersonId");

            builder.Property(rt => rt.RentalPlanId)
                .IsRequired()
                .HasColumnName("RentalPlanId");

            builder.Property(rt => rt.StartDate)
                .IsRequired()
                .HasColumnName("StartDate");

            builder.Property(rt => rt.EndDate)
                .IsRequired()
                .HasColumnName("EndDate");

            builder.Property(rt => rt.ExpectedEndDate)
                .IsRequired()
                .HasColumnName("ExpectedEndDate");

            builder.Property(rt => rt.TotalRentalCost)
                .IsRequired()
                .HasColumnName("TotalRentalCost");

            builder.Property(rt => rt.TotalFines)
                .IsRequired()
                .HasColumnName("TotalFines");

            builder.HasOne(rt => rt.Motorcycle)
                .WithMany()
                .HasForeignKey(rt => rt.MotorcycleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rt => rt.DeliveryPerson)
                .WithMany()
                .HasForeignKey(rt => rt.DeliveryPersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rt => rt.RentalPlan)
                .WithMany()
                .HasForeignKey(rt => rt.RentalPlanId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
