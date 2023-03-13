using MyCoffeeApp.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCoffeeApp.Mobile.Services
{
    public interface IRestService
    {
        Task<IEnumerable<Coffee>> GetAllAsync();
        Task<Coffee> GetByIdAsync(Guid Id);
        Task<Coffee> CreateAsync(string name, string roaster);
        Task<Coffee> UpdateAsync(Coffee entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
