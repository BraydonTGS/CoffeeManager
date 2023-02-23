using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyCoffeeApp.DataAccess.Context;
using MyCoffeeApp.DataAccess.Entities;
using MyCoffeeApp.DataAccess.Interfaces;
using MyCoffeeApp.DataAccess.Repository;
using MyCoffeeApp.DataAccess.Tests.Base;

namespace MyCoffeeApp.DataAccess.Tests.Tests
{
    [TestClass]
    public class CoffeeRepositoryShould : DataAccessTestBase
    {
   
        [TestMethod]
        public async Task GetAllCoffee()
        {
            var sut = await genericDataRepository.GetAllAsync();
        }
    }
}
