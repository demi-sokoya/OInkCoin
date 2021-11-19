using System;
using Xamarin.Forms;
using OInkCoin.Views;
namespace OInkCoin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(OverviewPage), typeof(OverviewPage));
        }

    }
}
