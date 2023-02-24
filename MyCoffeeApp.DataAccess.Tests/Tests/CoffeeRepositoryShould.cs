using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCoffeeApp.DataAccess.Tests.Base;

namespace MyCoffeeApp.DataAccess.Tests.Tests
{
    [TestClass]
    public class CoffeeRepositoryShould : DataAccessTestBase
    {

        [TestMethod]
        public async Task ReturnCoffeesInCollectionNotNullAsync()
        {
            var sut = await genericDataRepository.GetAllAsync();
            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public async Task ReturnAllCoffeesInCollectionAsync()
        {
            var sut = await genericDataRepository.GetAllAsync();
            Assert.IsNotNull(sut);
            Assert.AreEqual(3, sut.Count());
        }

        [TestMethod]
        public async Task ReturnAllCoffeesInCollection_CheckFirstCoffee()
        {
            var sut = await genericDataRepository.GetAllAsync();
            var coffee = sut.First();

            Assert.IsNotNull(coffee);
            Assert.AreEqual("Toasted Hazelnut", coffee.CoffeeName);
            Assert.AreEqual("Community Coffee", coffee.CoffeeRoaster);
            Assert.AreEqual("https://images.prismic.io/yesplz/75c1e42d-4bcc-40e1-abec-bf35816c088b_Group+2471.png?auto=compress,format&rect=0,0,870,1341&w=870&h=1341", coffee.ImagePath);
            Assert.AreEqual(new Guid("67d28458-b179-48a1-bf96-71d9140a14ad"), coffee.UserId);
        }

    }
}
