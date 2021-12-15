using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.ObjectModel;
using OinkCoin.Models;
using static OinkCoin.Models.Category;

namespace OinkCoin.ViewModels
{
    class CategoryViewModel: ViewModelBase
    {
        

        public Category SelectedCategory { get; set; }

        public string CategoryName { get; set; }
        public string CategoryColor { get; set; }

        public AsyncCommand AddCommand { get; }
        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand RemoveCommand { get; }

        

        public CategoryViewModel()
        {
            Categories = new MvvmHelpers.ObservableRangeCollection<Category>();
            AddCommand = new AsyncCommand(Add);
            Load();
            RefreshCommand = new AsyncCommand(Refresh);
            RemoveCommand = new AsyncCommand(Remove);


        }

        public async void Load()
        {
            IEnumerable<Category> categories = await CategoryDataStore.GetCategories();
            Categories.AddRange(categories);
        }

        async Task Add()
        {
            var newCategory = new Category { CategoryName = CategoryName, Color = CategoryColor };
            await CategoryDataStore.AddCategory(newCategory);
            

            IEnumerable<Category> categories = await CategoryDataStore.GetCategories();

            Refresh();
        }

        async Task Remove()
        {
            Categories.Remove(SelectedCategory);
            await CategoryDataStore.RemoveCategory(SelectedCategory);
        }

        private async Task Refresh()
        {
            IsBusy = true;

            Categories.Clear();
            Load();

            IsBusy = false;
        }

        

    }

    
}
