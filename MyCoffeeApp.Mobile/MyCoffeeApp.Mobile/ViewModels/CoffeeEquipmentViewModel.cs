
using MyCoffeeApp.Mobile.Models;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MyCoffeeApp.Mobile.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {

        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; set; }

        public AsyncCommand RefreshCommand { get;}


        public CoffeeEquipmentViewModel() 
        {
            Title = "Coffee Equipment"; 
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            var image = "https://images.prismic.io/yesplz/75c1e42d-4bcc-40e1-abec-bf35816c088b_Group+2471.png?auto=compress,format&rect=0,0,870,1341&w=870&h=1341"
            Coffee.Add(new Models.Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image= image });
            Coffee.Add(new Models.Coffee { Roaster = "Blue Bottle", Name = "Feeling Blue", Image = image });
            Coffee.Add(new Models.Coffee { Roaster = "Cotume", Name = "Rags and Rain", Image = image });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", new[] { Coffee[2] })); 
            CoffeeGroups.Add(new Grouping<string, Coffee> ("Yes Please", Coffee.Take(2))); 

            RefreshCommand = new AsyncCommand(Refresh); 
        }

        private async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000); 
            IsBusy= false;
        }
    }
}

