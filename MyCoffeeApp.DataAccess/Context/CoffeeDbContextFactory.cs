using Microsoft.EntityFrameworkCore;

namespace MyCoffeeApp.DataAccess.Context
{
    public class CoffeeDbContextFactory : IDbContextFactory<CoffeeDbContext>
    {
        public virtual CoffeeDbContext CreateDbContext()
        {
            return new CoffeeDbContext();
        }
    }
}
