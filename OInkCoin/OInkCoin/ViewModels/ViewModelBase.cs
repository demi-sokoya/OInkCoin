using MvvmHelpers;
using OInkCoin.Models;
using OInkCoin.Services;
using Xamarin.Forms;

namespace OInkCoin.ViewModels
{
    class ViewModelBase : BaseViewModel
    {
        public ITransactionDataStore<Transaction> TransactionDataStore => DependencyService.Get<ITransactionDataStore<Transaction>>();

        public ICategoryDataStore<Category> CategoryDataStore => DependencyService.Get<ICategoryDataStore<Category>>();

    }
}
