using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCoffeeApp.DataAccess.Entities;
using MyCoffeeApp.DataAccess.Tests.Base;

namespace MyCoffeeApp.DataAccess.Tests.Tests
{
    [TestClass]
    public class CoffeeRepositoryShould : DataAccessTestBase
    {
        [TestMethod]
        public async Task ReturnCoffeesInCollection_NotReturnNullAsync()
        {
            var sut = await genericDataRepository.GetAllAsync();
            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public async Task ReturnAllCoffeesInCollection_Async()
        {
            var sut = await genericDataRepository.GetAllAsync();
            Assert.IsNotNull(sut);
            Assert.AreEqual(3, sut.Count());
        }

        [TestMethod]
        public async Task ReturnAllCoffeesInCollection_CheckFirstCoffeeAsync()
        {
            var sut = await genericDataRepository.GetAllAsync();
            var coffee = sut.First();

            Assert.IsNotNull(coffee);
            Assert.AreEqual("Toasted Hazelnut", coffee.CoffeeName);
            Assert.AreEqual("Community Coffee", coffee.CoffeeRoaster);
            Assert.AreEqual("https://images.prismic.io/yesplz/75c1e42d-4bcc-40e1-abec-bf35816c088b_Group+2471.png?auto=compress,format&rect=0,0,870,1341&w=870&h=1341", coffee.ImagePath);
            Assert.AreEqual(new Guid("67d28458-b179-48a1-bf96-71d9140a14ad"), coffee.UserId);
        }

        [TestMethod]
        public async Task GetCoffeeByGuid_AndNotReturnNullAsync()
        {
            var sut = await genericDataRepository.GetByIdAsync(new Guid("7d187a7f-d717-45f3-ba15-3bd20b84fba2"));
            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public async Task GetCoffeeByGuid_AndCheckInputAsync()
        {
            var sut = await genericDataRepository.GetByIdAsync(new Guid("7d187a7f-d717-45f3-ba15-3bd20b84fba2"));

            Assert.IsNotNull(sut);
            Assert.AreEqual("Toasted Hazelnut", sut.CoffeeName);
            Assert.AreEqual("Community Coffee", sut.CoffeeRoaster);
            Assert.AreEqual("https://images.prismic.io/yesplz/75c1e42d-4bcc-40e1-abec-bf35816c088b_Group+2471.png?auto=compress,format&rect=0,0,870,1341&w=870&h=1341", sut.ImagePath);
            Assert.AreEqual(new Guid("67d28458-b179-48a1-bf96-71d9140a14ad"), sut.UserId);
        }

        [TestMethod]
        public async Task UpdateCoffee_andReturnUpdatedCoffeeAsync()
        {
            var coffeeToUpdate = await genericDataRepository.GetByIdAsync(new Guid("7d187a7f-d717-45f3-ba15-3bd20b84fba2"));
            coffeeToUpdate.CoffeeName = "Pecan Praline";
            coffeeToUpdate.CoffeeRoaster = "Yes Please";
            coffeeToUpdate.ImagePath = "https://images.prismic.io/yesplz/75c1e42d-4bcc-40e1-abec-bf35816c088b_Group+2471.png?auto=compress,format&rect=0,0,870,1341&w=870&h=1341";
            var sut = await genericDataRepository.UpdateAsync(coffeeToUpdate);
            Assert.IsNotNull(sut);
        }

        #region SeedContextWithMockData
        protected override void SeedContextWithMockData()
        {
            if (mockDbContext != null)
            {
                var coffees = GenerateMockCoffees();
                var user = GenerateMockUser();
                user.Coffees = coffees;
                mockDbContext.Users.Add(user);
                foreach (var coffee in coffees)
                {
                    mockDbContext.Coffees.Add(coffee);
                }
                mockDbContext.SaveChanges();
            }
        }
        private List<Coffee> GenerateMockCoffees()
        {
            var coffeeList = new List<Coffee>()
            {
               new Coffee()
               {
                CoffeeId = new Guid("7d187a7f-d717-45f3-ba15-3bd20b84fba2"),
                CoffeeName = "Toasted Hazelnut",
                CoffeeRoaster = "Community Coffee",
                ImagePath = "https://images.prismic.io/yesplz/75c1e42d-4bcc-40e1-abec-bf35816c088b_Group+2471.png?auto=compress,format&rect=0,0,870,1341&w=870&h=1341",
                UserId = new Guid("67d28458-b179-48a1-bf96-71d9140a14ad")
                },
               new Coffee()
               {
                CoffeeId = Guid.NewGuid(),
                CoffeeName = "Morning Blend",
                CoffeeRoaster = "Trader Joes",
                ImagePath = "https://images.prismic.io/yesplz/75c1e42d-4bcc-40e1-abec-bf35816c088b_Group+2471.png?auto=compress,format&rect=0,0,870,1341&w=870&h=1341",
                UserId = new Guid("67d28458-b179-48a1-bf96-71d9140a14ad")
                },
                new Coffee()
                {
                CoffeeId = Guid.NewGuid(),
                CoffeeName = "Vista",
                CoffeeRoaster = "Counter Culture",
                ImagePath = "https://images.prismic.io/yesplz/75c1e42d-4bcc-40e1-abec-bf35816c088b_Group+2471.png?auto=compress,format&rect=0,0,870,1341&w=870&h=1341",
                UserId = new Guid("67d28458-b179-48a1-bf96-71d9140a14ad")
                }
            };

            return coffeeList;
        }
        private User GenerateMockUser()
        {
            var user = new User()
            {
                UserId = new Guid("67d28458-b179-48a1-bf96-71d9140a14ad"),
                FirstName = "Braydon",
                LastName = "Sutherland",
                Email = "BraydonSutherland@gmail.com",
                Password = "TryAndGuess",
                Username = "Geo"

            };

            return user;
        }
        #endregion
    }
}
