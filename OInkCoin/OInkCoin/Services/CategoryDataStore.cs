using Newtonsoft.Json;
using OinkCoin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OinkCoin.Services
{
    class CategoryDataStore
    {
        public static string FilePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, "Categories.json");
            }
        }

        private List<Category> ReadFile()
        {
            File.Delete(FilePath);
            try
            {
                var jsonString = File.ReadAllText(FilePath);

                var categories = JsonConvert.DeserializeObject<List<Category>>(jsonString);

                return categories;
            }
            catch (Exception e)
            {
                var defaultCategories = GetDefaultCategories();

                WriteFile(defaultCategories);

                return defaultCategories;
            }
        }

        private List<Category> GetDefaultCategories()
        {
            var categories = new List<Category>()
            {
                //new Category { Id = 1, Name = "Category A Local Json File", Description = "This is Category a." },
                //new Category { Id = 2, Name = "Category B Local Json File", Description = "This is Category b." },
                //new Category { Id = 3, Name = "Category C Local Json File", Description = "This is Category c." },
                //new Category { Id = 4, Name = "Category D Local Json File", Description = "This is Category d." }

                new Category { CategoryId = 1, CategoryName = "Food & Drinks", Color ="#FFE98A" }
            };

            return categories;
        }

        private void WriteFile(List<Category> categorys)
        {
            var jsonString = JsonConvert.SerializeObject(categorys);

            File.WriteAllText(FilePath, jsonString);
        }

        public async Task<Category> GetCategory(int categoryId)
        {
            var categories = ReadFile();

            var Category = categories.Find(p => p.CategoryId == categoryId);

            return Category;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = ReadFile();

            return categories;
        }

        public async Task UpdateCategory(Category category)
        {
            var categories = ReadFile();
            categories[categories.FindIndex(p => p.CategoryId == category.CategoryId)] = category;

            WriteFile(categories);
        }

        public async Task AddCategory(Category category)
        {
            var categories = ReadFile();
            categories.Add(category);

            WriteFile(categories);
        }
    }
}

