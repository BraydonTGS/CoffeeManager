using Microsoft.EntityFrameworkCore;
using MyCoffeeApp.DataAccess.Context;

namespace MyCoffeeApp.DataAccess.Tests.Base
{
    public class MockDbContext : CoffeeDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
        }
    }
}
