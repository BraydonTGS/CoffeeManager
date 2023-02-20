using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCoffeeApp.DataAccess.Context;
using MyCoffeeApp.DataAccess.Entities;
using MyCoffeeApp.DataAccess.Repository;
using MyCoffeeApp.DataAccess.Tests.Context;

namespace MyCoffeeApp.DataAccess.Tests.Base
{
    public class InMemoryTestBase
    {
        protected CoffeeDbContextFactory contextFactory;
        protected MockDbContext mockDbContext;
        protected GenericDataRepository<MockDbContext> repository;


        [TestInitialize]
        public void TestInitialize()
        {
            contextFactory = new CoffeeDbContextFactory();
            SeedDbWithMockData(contextFactory); 
            repository = new GenericDataRepository<MockDbContext>(contextFactory);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            contextFactory.CreateDbContext().Database.EnsureDeleted(); // Remove from memory

            contextFactory.CreateDbContext().Dispose();
        }

        private void SeedDbWithMockData(CoffeeDbContextFactory contextFactory)
        {
            var dataToSeed = GenerateMockItems();
            var userToSeed = GenerateMockUser();
            var context = contextFactory.CreateDbContext(); 
            context.Users.Add(userToSeed);

            foreach(var coffee in dataToSeed)
            {
                context.Coffees.Add(coffee);
            }
        }

        private User GenerateMockUser()
        {
            throw new NotImplementedException();
        }

        private List<Coffee> GenerateMockItems()
        {
            throw new NotImplementedException();
        }
    }
}
