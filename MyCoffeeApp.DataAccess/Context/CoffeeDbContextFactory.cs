using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace MyCoffeeApp.DataAccess.Context
{
    public class CoffeeDbContextFactory : IDbContextFactory<CoffeeDbContext>
    {
        public virtual CoffeeDbContext CreateDbContext()
        {
            return new CoffeeDbContext();
        }

        public virtual CoffeeDbContext CreateDbContext(DbContextOptions options)
        {
            return new CoffeeDbContext(options);
        }
    }
}
