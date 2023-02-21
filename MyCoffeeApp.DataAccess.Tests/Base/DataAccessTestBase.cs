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
        private Mock<CoffeeDbContextFactory> _mockFactory;
        private IGenericDataRepository<Coffee> _repository;

        [TestInitialize]
        public void Init()
        {
            _mockFactory = new Mock<CoffeeDbContextFactory>();
            _repository = new GenericDataRepository<Coffee>(_mockFactory.Object); 
        }

        [TestCleanup]
        public void Cleanup() 
        {
            
        }

        [TestMethod]
        public async Task DataAccessTest()
        {
            var test = await _repository.GetAllAsync();
            Assert.IsNotNull(test);
        }

    }
}
