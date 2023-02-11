

using Xamarin.CommunityToolkit.ObjectModel;

namespace MyCoffeeApp.Mobile.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
       
        private string _title;
        private bool _isBusy;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public bool IsBusy 
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }


    }
}
