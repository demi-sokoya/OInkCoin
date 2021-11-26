using MvvmHelpers;
using OinkCoin.Models;
using OinkCoin.Services;
using Xamarin.Forms;

namespace OinkCoin.ViewModels
{
    class ViewModelBase : BaseViewModel
    {
        public ITransactionDataStore<Transaction> TransactionDataStore => DependencyService.Get<ITransactionDataStore<Transaction>>();

        public ICategoryDataStore<Category> CategoryDataStore => DependencyService.Get<ICategoryDataStore<Category>>();

    }
}
