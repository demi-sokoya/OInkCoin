using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OinkCoin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewPage : ContentPage
    {
        public OverviewPage()
        {
            InitializeComponent();
        }

        private async void AddTransaction_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewTransactionPage());
        }
    }
}