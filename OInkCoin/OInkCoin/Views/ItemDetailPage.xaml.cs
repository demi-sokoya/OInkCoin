using OInkCoin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace OInkCoin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}