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

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarInfo> CarInfo { get; set; }
        public DbSet<Favourite> Favourites { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}