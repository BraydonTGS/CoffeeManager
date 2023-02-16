namespace MyCoffeeApp.DataAccess.Context
{
    public class DbContextFactory
    {
        public virtual CoffeeDbContext CreateDbContext()
        {
            return new CoffeeDbContext();
        }
    }
}
