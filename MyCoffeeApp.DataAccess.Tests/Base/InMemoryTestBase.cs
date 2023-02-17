using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCoffeeApp.DataAccess.Context;
using MyCoffeeApp.DataAccess.Entities;
using MyCoffeeApp.DataAccess.Interfaces;
using MyCoffeeApp.DataAccess.Repository;

namespace MyCoffeeApp.DataAccess.Tests.Base
{
    public class InMemoryTestBase
    {
        protected IDbContextFactory<CoffeeDbContext> contextFactory;
        protected IGenericDataRepository<Coffee> repository;


        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<CoffeeDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            contextFactory = new CoffeeDbContext(options);
            SeedDbWithMockTodoItems(context);
            repository = new GenericDataRepository<Coffee>(contextFactory); 
        }

        private void SeedDbWithMockTodoItems(CoffeeDbContext context)
        {
            throw new NotImplementedException();
        }

        [TestCleanup]
        public void TestCleanup()
        {
         /*   context.Database.EnsureDeleted(); // Remove from memory

            context.Dispose();*/
        }

    }
}
