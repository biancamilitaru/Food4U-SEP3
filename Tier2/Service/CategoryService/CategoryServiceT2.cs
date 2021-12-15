using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Service.CategoryService
{
    public class CategoryServiceT2 : ICategoryServiceT2
    {
        private readonly ICategoryHandlerT2 categoryHandlerT2;

        public CategoryServiceT2(ICategoryHandlerT2 categoryHandlerT2)
        {
            this.categoryHandlerT2 = categoryHandlerT2;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            try
            {
                return await categoryHandlerT2.AddCategory(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            try
            {
                return await categoryHandlerT2.GetCategory(categoryId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<Category>> GetCategoriesAsync(int menuId)
        {
            try
            {
                return await categoryHandlerT2.GetCategories(menuId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            try
            {
                return await categoryHandlerT2.UpdateCategory(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            try
            {
                await categoryHandlerT2.DeleteCategory(categoryId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}