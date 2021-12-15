using System;
using System.Collections.Generic;
using System.Text;
using OinkCoin.Models;
using System.Threading.Tasks;


namespace OinkCoin.Services
{
    
        public interface ICategoryDataStore<T>
        {
            Task<IEnumerable<Category>> GetCategories();
            Task<Category> GetCategory(int categoryId);
            Task AddCategory(Category category);
            Task UpdateCategory(Category category);
            Task RemoveCategory(Category category);


        }
    }

