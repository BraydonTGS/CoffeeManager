using Microsoft.EntityFrameworkCore;

namespace MyCoffeeApp.DataAccess.Context
{
    public class CoffeeDbContextFactory : IDbContextFactory<CoffeeDbContext>
    {
        public CoffeeDbContext CreateDbContext()
        {
            return new CoffeeDbContext();
        }
    }
}
