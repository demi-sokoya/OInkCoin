using Xamarin.Forms;
using OinkCoin.Views;

namespace OinkCoin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new OverviewPage());
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
