using System.Data.Entity;
using AstRentals.Data.Entities;

namespace AstRentals.Data.Infrastructure
{
    public class AstRentalsContext : DbContext
    {
        public AstRentalsContext() : base("AstRentalsConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AstRentalsContext>());
        }

        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(c => c.Vehicles);

            base.OnModelCreating(modelBuilder);
        }
    }
}