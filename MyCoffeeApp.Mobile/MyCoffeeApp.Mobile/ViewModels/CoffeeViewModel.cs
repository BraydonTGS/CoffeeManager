
using MyCoffeeApp.Mobile.Models;
using MyCoffeeApp.Mobile.Service;
using MyCoffeeApp.Mobile.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace MyCoffeeApp.Mobile.ViewModels
{
    public class CoffeeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public IAsyncCommand RefreshCommand { get; }
        public IAsyncCommand AddCommand { get; }
        public IAsyncCommand<Coffee> DeleteCommand { get; }

        public IRestService _service { get; set; }



        public CoffeeViewModel()
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(AddNewCoffee);
            DeleteCommand = new AsyncCommand<Coffee>(DeleteCoffee); 
            _service = new RestService();   
        }

        private async Task DeleteCoffee(Coffee coffee)
        {
            await _service.DeleteAsync(coffee.CoffeeId);
            await Refresh(); 
        }

        private async Task AddNewCoffee()
        {
            var name =  await App.Current.MainPage.DisplayPromptAsync("Name", "Name of coffee");
            var roaster = await  App.Current.MainPage.DisplayPromptAsync("Roaster", "Roaster of coffee");
            await _service.CreateAsync(name, roaster);
            await Refresh();
        }

        private async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Coffee.Clear();
            var coffees = await _service.GetAllAsync();
            Coffee.AddRange(coffees); 
            IsBusy = false;
        }

    }
}

