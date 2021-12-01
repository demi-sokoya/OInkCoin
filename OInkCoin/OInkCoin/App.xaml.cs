using Xamarin.Forms;
using OinkCoin.Views;
using OinkCoin.Services;

namespace OinkCoin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new OverviewPage());
            DependencyService.Register<TransactionDataStore>();
            DependencyService.Register<CategoryDataStore>();
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
