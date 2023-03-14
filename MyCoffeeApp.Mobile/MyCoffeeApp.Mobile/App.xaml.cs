using Xamarin.Forms;

namespace MyCoffeeApp.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            // Monkey Cache => Creates a Folder to put the data into //
            // Barrel.ApplicationId = AppInfo.PackageName; 
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
