using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyCoffeeApp.DataAccess.Entities;

namespace MyCoffeeApp.DataAccess.Tests.Context
{
    public class MockDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Coffee> Coffees { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            }
        }
    }
}
