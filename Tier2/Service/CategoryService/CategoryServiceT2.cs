using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;
using Food4U_SEP3.SocketHandler.ItemHandler;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Service.CategoryService
{
    public class CategoryServiceT2 : ICategoryServiceT2
    {
        private readonly ICategoryHandlerT2 categoryHandlerT2;
        private readonly IItemHandlerT2 itemHandlerT2;

        public CategoryServiceT2(HandlerFactory handlerFactory)
        {
            categoryHandlerT2 = handlerFactory.GetCategoryHandlerT2();
            itemHandlerT2 = handlerFactory.GetItemHandlerT2();
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            try
            {
                Category categoryAdded = await categoryHandlerT2.AddCategory(category);
                if (category.Items.Count > 0)
                {
                    foreach (Item item in category.Items)
                    {
                        await itemHandlerT2.AddItem(item);
                    }
                }

                return categoryAdded;
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
                IList<Item> items = await itemHandlerT2.GetItems(categoryId);
                Category category = await categoryHandlerT2.GetCategory(categoryId);
                category.Items = items;
                return category;
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
                IList<Category> categories =  await categoryHandlerT2.GetCategories(menuId);
                foreach (Category category in categories)
                {
                    IList<Item> items = await itemHandlerT2.GetItems(category.CategoryId);
                    category.Items = items;
                }
                return categories;
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
                if (category.Items.Count > 0)
                {
                    foreach (Item item in category.Items)
                    {
                        await itemHandlerT2.UpdateItem(item);
                    }
                }
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