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
        protected MockDbContext mockDbContext;

        [TestInitialize]
        public void Init()
        {
            mockDbContext = new MockDbContext();
            SeedContextWithMockData(); 
            var mockFactory = new Mock<CoffeeDbContextFactory>();
            mockFactory.Setup(x => x.CreateDbContext()).Returns(mockDbContext);
            genericDataRepository = new GenericDataRepository<Coffee>(mockFactory.Object);
        }

        private void SeedContextWithMockData()
        {
            var coffee = new Coffee()
            {
                CoffeeId = Guid.NewGuid(),
                CoffeeName = "Test",
                CoffeeRoaster = "Roaster"
            }; 
            mockDbContext.Coffees.Add(coffee);
            mockDbContext.SaveChanges();
        }
    }
}
