using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Motto.MR.Shared.Models;

namespace Motto.MR.DataAccess.Mappings
{
    public class RentalPlanMap : IEntityTypeConfiguration<RentalPlan>
    {
        public void Configure(EntityTypeBuilder<RentalPlan> builder)
        {
            builder.ToTable("RentalPlans");

            builder.HasKey(rp => rp.Id);

            builder.Property(rp => rp.Id)
                .IsRequired()
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(rp => rp.Days)
                .HasColumnName("Days")
                .IsRequired();

            builder.Property(rp => rp.DailyCost)
                .HasColumnName("DailyCost")
                .HasColumnType("decimal(10, 2)")
                .IsRequired();

            builder.Property(rp => rp.PenaltyPercentage)
                .HasColumnName("PenaltyPercentage")
                .HasColumnType("decimal(5, 2)")
                .IsRequired(false);

            builder.Property(rp => rp.AdditionalDailyCost)
                .HasColumnName("AdditionalDailyCost")
                .HasColumnType("decimal(10, 2)")
                .IsRequired();

            builder.Property(rp => rp.Created)
                .HasColumnName("Created")
                .IsRequired();

            builder.Property(rp => rp.Updated)
                .HasColumnName("Updated")
                .IsRequired();

            builder.HasData(
                new RentalPlan { Id = 1, Days = 7, DailyCost = 30.00m, PenaltyPercentage = 20.00m, AdditionalDailyCost = 50.00m, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new RentalPlan { Id = 2, Days = 15, DailyCost = 28.00m, PenaltyPercentage = 40.00m, AdditionalDailyCost = 50.00m, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new RentalPlan { Id = 3, Days = 30, DailyCost = 22.00m, PenaltyPercentage = null, AdditionalDailyCost = 50.00m, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new RentalPlan { Id = 4, Days = 45, DailyCost = 20.00m, PenaltyPercentage = null, AdditionalDailyCost = 50.00m, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new RentalPlan { Id = 5, Days = 50, DailyCost = 18.00m, PenaltyPercentage = null, AdditionalDailyCost = 50.00m, Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
            );
        }
    }
}
