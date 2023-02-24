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

        #region GenerateMockData
        private void SeedContextWithMockData()
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
                CoffeeId = Guid.NewGuid(),
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
