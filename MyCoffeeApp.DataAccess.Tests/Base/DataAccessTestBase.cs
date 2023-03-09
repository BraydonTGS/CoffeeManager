using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyCoffeeApp.Application.Interfaces;
using MyCoffeeApp.DataAccess.Context;
using MyCoffeeApp.DataAccess.Repository;
using MyCoffeeApp.Domain.Entities;

namespace MyCoffeeApp.DataAccess.Tests.Base
{
    [TestClass]
    public abstract class DataAccessTestBase
    {
        protected CoffeeDbContext dbContext;
        protected IGenericDataRepository<Coffee> genericDataRepository;
        protected MockDbContext mockDbContext;

        [TestInitialize]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<MockDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            mockDbContext = new MockDbContext(options);
            SeedContextWithMockData();
            var mockFactory = new Mock<IDbContextFactory<CoffeeDbContext>>();
            mockFactory.Setup(x => x.CreateDbContext()).Returns(mockDbContext);
            genericDataRepository = new GenericDataRepository<Coffee>(mockFactory.Object);
        }
        protected abstract void SeedContextWithMockData();
    }
}
