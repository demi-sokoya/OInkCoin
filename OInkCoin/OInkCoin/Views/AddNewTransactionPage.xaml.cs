using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OinkCoin.ViewModels;
using OinkCoin.Views;
using OinkCoin.Services;

namespace OinkCoin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewTransactionPage : ContentPage
    {
        public AddNewTransactionPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }

        private async void SaveTransaction_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OverviewPage());
            

            
        }

        private async void EditCategories_OnCLicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCategoriesPage());
        }
    }
}