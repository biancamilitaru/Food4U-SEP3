using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Service.CategoryService
{
    public class CategoryServiceT2 : ICategoryServiceT2
    {
        private readonly ICategoryHandlerT2 categoryHandler;

        public CategoryServiceT2(ICategoryHandlerT2 categoryHandler)
        {
            this.categoryHandler = categoryHandler;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            try
            {
                return await categoryHandler.AddCategory(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Category> UpdateCategoryAsync(Category category, int categoryId)
        {
            try
            {
                return await categoryHandler.UpdateCategory(category, categoryId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task DeleteCategoryAsync(string categoryName)
        {
            try
            {
                await categoryHandler.DeleteCategory(categoryName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    }
