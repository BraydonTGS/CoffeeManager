
using MyCoffeeApp.Mobile.Models;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace MyCoffeeApp.Mobile.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public string image = "https://images.prismic.io/yesplz/75c1e42d-4bcc-40e1-abec-bf35816c088b_Group+2471.png?auto=compress,format&rect=0,0,870,1341&w=870&h=1341";

        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; set; }
        public IAsyncCommand RefreshCommand { get; }
        public IAsyncCommand<Coffee> FavoriteCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command LoadMoreCommand { get; }
        public Command ClearCommand { get; }



        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            LoadMore();

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);
            DelayLoadMoreCommand = new Command(Delay);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
        }

        private void LoadMore()
        {
            if (Coffee.Count >= 20)
                return;

            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Feeling Blue", Image = image });
            Coffee.Add(new Coffee { Roaster = "Cotume", Name = "Rags and Rain", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Feeling Blue", Image = image });
            Coffee.Add(new Coffee { Roaster = "Cotume", Name = "Rags and Rain", Image = image });

            CoffeeGroups.Clear();

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", Coffee.Where(c => c.Roaster == "Blue Bottle")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Where(c => c.Roaster == "Yes Plz")));

        }

        private Coffee _selectedCoffee; 
        public Coffee SelectedCoffee
        {
            get { return _selectedCoffee; }
            set
            {
                if(value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Selected", value.Name, "OK");
                    value = null; 
                }
                _selectedCoffee = value;
                OnPropertyChanged(); 
            }
        }

        private async Task Favorite(Coffee coffee)
        {
            if(coffee == null)
            {
                return; 
            }
            await Application.Current.MainPage.DisplayAlert("Favorite", coffee.Name, "OK");
        }
        private async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Coffee.Clear();
            LoadMore();

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

