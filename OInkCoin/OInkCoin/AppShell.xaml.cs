using System;
using Xamarin.Forms;
using OinkCoin.Views;
namespace OinkCoin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(OverviewPage), typeof(OverviewPage));
            Routing.RegisterRoute(nameof(AddNewTransactionPage), typeof(AddNewTransactionPage));
        }

    }
}
