using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OinkCoin.Views;

namespace OinkCoin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewPage : ContentPage
    {
        DateTime current = DateTime.Now;
        public OverviewPage()
        {
            InitializeComponent();
            

        }

        private async void AddTransaction_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewTransactionPage());
        }



        private async void IncreaseMonth_OnClicked(object sender, EventArgs e)
        {
            
            //current = current.AddMonths(1);
            //currentMonth.Text = current.ToString("MMMM yyyy");

            
                current = current.AddMonths(1);
                currentMonth.Text = current.ToString("MMMM yyyy");
           


        }

        private async void DecreaseMonth_OnClicked(Object sender, EventArgs e)
        {
            //if (current >= DateTime.Now) { 
            //    current = current.AddMonths(-1);
            //    currentMonth.Text = current.ToString("MMMM yyyy");
            //}

            //if (current >= DateTime.Now)
            //{
                current = current.AddMonths(-1);
                currentMonth.Text = current.ToString("MMMM yyyy");
            //}

        }
    }
}