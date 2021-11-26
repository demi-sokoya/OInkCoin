using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.ObjectModel;
using OInkCoin.Models;

namespace OInkCoin.ViewModels
{
    class OinkViewModel: ViewModelBase
    {
        public ObservableRangeCollection<Transaction> Transactions { get; set; }
        public ObservableRangeCollection<Category> Categories { get; set; }

        public AsyncCommand RefreshCommand { get; }
        //public AsyncCommand<Transaction> SelectedCommand { get; }

        //Transaction selectedTransaction;

        //public Transaction SelectedTransaction
        //{
        //    get => selectedTransaction;
        //    set => SetProperty(ref selectedTransaction, value);
        //}

        public OinkViewModel()
        {
            Title = "Transactions";

            Transactions = new ObservableRangeCollection<Transaction>();
            Categories = new ObservableRangeCollection<Category>();


            Load();

            RefreshCommand = new AsyncCommand(Refresh);
            //SelectedCommand = new AsyncCommand<Transaction>(Selected);
        }

        //async Task Selected(Transaction Transaction)
        //{
        //    string route = $"{nameof(Views.TransactionDetailPage)}?TransactionId={Transaction.Id}";
        //    await Shell.Current.GoToAsync(route);
        //}

        private async Task Refresh()
        {
            IsBusy = true;

            Transactions.Clear();
            Load();

            IsBusy = false;
        }

        public async void Load()
        {
            IEnumerable<Transaction> transactions = await TransactionDataStore.GetTransactions();
            Transactions.AddRange(transactions);

        }
    }
}
