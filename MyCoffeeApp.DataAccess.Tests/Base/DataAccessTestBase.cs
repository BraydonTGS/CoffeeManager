using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.Moq;
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
        protected CoffeeDbContextFactory _dbContextFactory;
        protected CoffeeDbContext _dbContext;
        protected IGenericDataRepository<Coffee> _genericDataRepository;

        [TestInitialize]
        public void Init()
        {
             _dbContextFactory = new CoffeeDbContextFactory();
            _dbContext = _dbContextFactory.CreateDbContext();
            _genericDataRepository = new GenericDataRepository<Coffee>(_dbContextFactory); 
        }

        [TestCleanup]
        public void Cleanup()
        {

        }
    }
}
