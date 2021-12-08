using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.ObjectModel;
using OinkCoin.Models;
using static OinkCoin.Models.Transaction;

namespace OinkCoin.ViewModels
{
    class OverviewViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Category> Categories { get; set; }
        public ObservableRangeCollection<Transaction> Transactions { get; set; }


        public AsyncCommand AddCommand { get; }
        public OverviewViewModel()
        {
            Categories = new ObservableRangeCollection<Category>();
            Transactions = new ObservableRangeCollection<Transaction>();


            Load();
        }

        public async void Load()
        {
            IEnumerable<Category> categories = await CategoryDataStore.GetCategories();
            Categories.AddRange(categories);

            IEnumerable<Transaction> transactions = await TransactionDataStore.GetTransactions();
            Transactions.AddRange(transactions);
        }

        
    }
}

