using Microsoft.EntityFrameworkCore;
using MyCoffeeApp.DataAccess.Context;
using MyCoffeeApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeApp.DataAccess.Repository
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
 
        public GenericDataRepository(CoffeeDbContext context)
        {
            
        }
        public async Task<T> CreateAsync(T args)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(Guid id, T args)
        {
            throw new NotImplementedException();
        }
    }
}
