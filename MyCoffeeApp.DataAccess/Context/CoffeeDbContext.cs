using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyCoffeeApp.DataAccess.Entities;

namespace MyCoffeeApp.DataAccess.Context
{
    public class CoffeeDbContext : DbContext
    {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Coffee> Coffees { get; set; }

        // Until API is Connected //
        private static string GetConnectionString()
        {
            string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("C:\\Users\\brayd\\Documents\\repos\\MyCoffeeApp\\MyCoffeeApp.DataAccess\\AppSettings.json").Build();
            string? connectionStringIs = configuration.GetConnectionString("CoffeeIsGood");
            if (connectionStringIs != null)
            {
                return connectionStringIs;
            }
            throw new ArgumentNullException(nameof(connectionStringIs));
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
    }

}
