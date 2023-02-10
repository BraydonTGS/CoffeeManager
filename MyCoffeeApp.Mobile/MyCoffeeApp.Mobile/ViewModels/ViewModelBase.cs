

using Xamarin.CommunityToolkit.ObjectModel;

namespace MyCoffeeApp.Mobile.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        public string Title { get; set; }   
        public bool IsBusy { get; set; }
    }
}
