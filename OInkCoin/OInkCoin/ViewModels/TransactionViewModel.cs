using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.ObjectModel;
using OinkCoin.Models;
using static OinkCoin.Models.Transaction;
using OinkCoin.Views;

namespace OinkCoin.ViewModels
{
    class TransactionViewModel : ViewModelBase
    { 

        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public Category ChosenCategory { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public bool Recurring { get; set; }
        public int NumOfPayments { get; set; }
        public AccountType Account { get; set; }
        public Category PickedCategory { get; set; }

        

        //public string CategoryName { get; set; }
        //public string CategoryColor { get; set; }

        public AsyncCommand AddCommand { get; }
        //public AsyncCommand AddCategoryCommand { get; }

        

        public TransactionViewModel()
        {
            Categories = new MvvmHelpers.ObservableRangeCollection<Category>();

            //Set the defaults for new transactions.
            Amount = 50;
            Type = TransactionType.Expense;
            Date = DateTime.Now;
            Notes = "";
            Recurring = false;
            NumOfPayments = 1;
            Account = AccountType.Debit;
            PickedCategory = null;
            AddCommand = new AsyncCommand(Add);
            //AddCategoryCommand = new AsyncCommand(AddCategory);
            Load();
        }

        public async void Load()
        {
            IEnumerable<Category> categories = await CategoryDataStore.GetCategories();
            Categories.AddRange(categories);
        }

        async Task Add()
        {
            var newTransaction = new Transaction { Account = Account, Amount = Amount, ChosenCategory = PickedCategory, Date = Date, Notes = Notes, Recurring = Recurring, NumOfPayments = NumOfPayments };
            await TransactionDataStore.AddTransaction(newTransaction);
            
            //Break just below this line to see a list of all transactions.
            IEnumerable<Transaction> transactions = await TransactionDataStore.GetTransactions();

           
        }
        //async Task AddCategory()
        //{
        //    var newCategory = new Category { CategoryName = CategoryName, Color = CategoryColor };
        //    await CategoryDataStore.AddCategory(newCategory);

        //    IEnumerable<Category> categories = await CategoryDataStore.GetCategories();
        //}
    }
}
