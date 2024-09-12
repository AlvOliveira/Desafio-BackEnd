using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Motto.MR.DataAccess.Mappings;
using Motto.MR.Shared.Models;

namespace Motto.MR.DataAccess.Contexts
{
    public class MottoMRContext : DbContext
    {
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<DeliveryPerson> DeliveryPersons { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalPlan> RentalPlans { get; set; }
        public DbSet<MotorcycleRegisterLog> MotorcycleRegisterLogs { get; set; }

        public MottoMRContext(DbContextOptions<MottoMRContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MotorcycleMap());
            modelBuilder.ApplyConfiguration(new MotorcycleRegisterLogMap());
            modelBuilder.ApplyConfiguration(new DeliveryPersonMap());
            modelBuilder.ApplyConfiguration(new RentalMap());
            modelBuilder.ApplyConfiguration(new RentalPlanMap());
        }
    }
}
