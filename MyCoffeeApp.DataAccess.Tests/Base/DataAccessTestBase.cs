using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyCoffeeApp.DataAccess.Context;
using MyCoffeeApp.DataAccess.Entities;
using MyCoffeeApp.DataAccess.Interfaces;
using MyCoffeeApp.DataAccess.Repository;

namespace MyCoffeeApp.DataAccess.Tests.Base
{
    [TestClass]
    public class DataAccessTestBase
    {
        protected CoffeeDbContextFactory dbContextFactory;
        protected CoffeeDbContext dbContext;
        protected IGenericDataRepository<Coffee> genericDataRepository;
        protected MockDbContext mockDbContext = new MockDbContext();

        [TestInitialize]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<CoffeeDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var mockFactory = new Mock<CoffeeDbContextFactory>();
            mockFactory.Setup(x => x.CreateDbContext()).Returns(mockDbContext);
            genericDataRepository = new GenericDataRepository<Coffee>(mockFactory.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetAllCoffee()
        {
            mockDbContext.SaveChanges();
            var sut = await genericDataRepository.GetAllAsync();
        }
    }
}
