using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.ObjectModel;
using OinkCoin.Models;

namespace OinkCoin.ViewModels
{
    class OinkViewModel: ViewModelBase
    {
        
        public ObservableRangeCollection<Transaction> Transactions { get; set; }
       
        public ObservableRangeCollection<Category> Categories { get; set; }

        public decimal Amount { get; set; }
        public Transaction.TransactionType Type { get; set; }
        public Category PickedCategory { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public bool Recurring { get; set; }
        public int NumOfPayments { get; set; }
        public Transaction.AccountType Account { get; set; }

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Transaction> SelectedCommand { get; }

        public AsyncCommand<Transaction> AddCommand { get; }

        public AsyncCommand<Transaction> RemoveCommand { get; }

        Transaction selectedTransaction;

        public Transaction SelectedTransaction
        {
            get => selectedTransaction;
            set => SetProperty(ref selectedTransaction, value);
        }

        public OinkViewModel()
        {
            Title = "Transactions";

            Transactions = new ObservableRangeCollection<Transaction>();
            Categories = new ObservableRangeCollection<Category>();


            Load();

            RefreshCommand = new AsyncCommand(Refresh);

            //SelectedCommand = new AsyncCommand<Transaction>(Selected);

            AddCommand = new AsyncCommand<Transaction>(Add);

            //RemoveCommand = new AsyncCommand<Transaction>(Remove);
        }

        //async Task Selected(Transaction Transaction)
        //{
        //    string route = $"{nameof(Views.TransactionDetailPage)}?TransactionId={Transaction.Id}";
        //    await Shell.Current.GoToAsync(route);
        //}

        async Task Add(Transaction transaction)
        {
            await TransactionDataStore.AddTransaction(transaction);
            new Transaction { Account = Account, Amount = Amount, ChosenCategory = PickedCategory, Date = Date, Notes = Notes, Recurring = Recurring, NumOfPayments = NumOfPayments };

            IEnumerable<Transaction> transactions = await TransactionDataStore.GetTransactions();
            Transactions.AddRange(transactions);
        }

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

            IEnumerable<Category> categories = await CategoryDataStore.GetCategories();
            Categories.AddRange(categories);

        }

        async Task Remove()
        {
            //await TransactionDataStore.RemoveSelectedTransaction;
        }
    }
}
