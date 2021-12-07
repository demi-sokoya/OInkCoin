using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OinkCoin.Services;
using OinkCoin.Views;

namespace OinkCoin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCategoriesPage : ContentPage
    {
        

        public EditCategoriesPage()
        {
            InitializeComponent();
        }

        private async void AddCategories_OnCLicked(object sender, EventArgs e)
        {
            var newCategory = await DisplayPromptAsync("Add New Category", "What's the Category?");

            if (newCategory != null)
            {
                await DisplayAlert("Alert", "No Category entered", "OK");
            }

            
        }
    }
}