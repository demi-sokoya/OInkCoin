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

        private ObservableRangeCollection<Category> _Categories;
        public ObservableRangeCollection<Category> Categories
        {
            get { return _Categories; }
            set
            {
                _Categories = value;
                OnPropertyChanged();
            }
        }

    }
}
