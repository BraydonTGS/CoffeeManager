
using MyCoffeeApp.Mobile.Models;
using MyCoffeeApp.Mobile.Service;
using MyCoffeeApp.Mobile.Services;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace MyCoffeeApp.Mobile.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; set; }
        public IAsyncCommand RefreshCommand { get; }
        public IAsyncCommand<Coffee> FavoriteCommand { get; }
        public IAsyncCommand<object> SelectedCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command LoadMoreCommand { get; }
        public Command ClearCommand { get; }
        public IRestService _service { get; set; }



        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            LoadMore();

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            DelayLoadMoreCommand = new Command(Delay);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            _service = new RestService();   
        }

        private void LoadMore()
        {
            var image = "https://images.prismic.io/yesplz/75c1e42d-4bcc-40e1-abec-bf35816c088b_Group+2471.png?auto=compress,format&rect=0,0,870,1341&w=870&h=1341";
            if (Coffee.Count >= 20)
                return;

            Coffee.Add(new Coffee { CoffeeRoaster = "Yes Plz", CoffeeName = "Sip of Sunshine", ImagePath = image });
            Coffee.Add(new Coffee { CoffeeRoaster = "Blue Bottle", CoffeeName = "Feeling Blue", ImagePath = image });
            Coffee.Add(new Coffee { CoffeeRoaster = "Cotume", CoffeeName = "Rags and Rain", ImagePath = image });
            Coffee.Add(new Coffee { CoffeeRoaster = "Yes Plz", CoffeeName = "Sip of Sunshine", ImagePath = image });
            Coffee.Add(new Coffee { CoffeeRoaster = "Blue Bottle", CoffeeName = "Feeling Blue", ImagePath = image });
            Coffee.Add(new Coffee { CoffeeRoaster = "Cotume", CoffeeName = "Rags and Rain", ImagePath = image });

            CoffeeGroups.Clear();

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", Coffee.Where(c => c.CoffeeRoaster == "Blue Bottle")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Where(c => c.CoffeeRoaster == "Yes Plz")));

        }

        private Coffee _selectedCoffee;

        public Coffee SelectedCoffee
        {
            get { return _selectedCoffee; }
            set { SetProperty(ref _selectedCoffee, value); }
        }

        private async Task Selected(object args)
        {
            var coffee = args as Coffee;
            if (coffee == null)
            {
                return;
            }
            SelectedCoffee = null; 
            await Application.Current.MainPage.DisplayAlert("Selected", coffee.CoffeeName, "OK");
        }

        private async Task Favorite(Coffee coffee)
        {
            if (coffee == null)
            {
                return;
            }
            await Application.Current.MainPage.DisplayAlert("Favorite", coffee.CoffeeName, "OK");
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

        private void Clear(object obj)
        {
            Coffee.Clear();
            CoffeeGroups.Clear();

        }

        private void Delay()
        {
            if (Coffee.Count <= 10)
                return;

            LoadMore();
        }
    }
}

