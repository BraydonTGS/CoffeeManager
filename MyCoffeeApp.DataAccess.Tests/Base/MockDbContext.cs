using Microsoft.EntityFrameworkCore;
using MyCoffeeApp.DataAccess.Context;

namespace MyCoffeeApp.DataAccess.Tests.Base
{
    public class MockDbContext : CoffeeDbContext
    {
        public MockDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
