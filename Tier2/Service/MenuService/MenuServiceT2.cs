using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;
using Food4U_SEP3.SocketHandler.ItemHandler;

namespace Food4U_SEP3.Service.MenuService
{
    public class MenuServiceT2 : IMenuServiceT2
    {
        private readonly IMenuHandlerT2 menuHandlerT2;
        private readonly ICategoryHandlerT2 categoryHandlerT2;
        private readonly IItemHandlerT2 itemHandlerT2;
        
        public MenuServiceT2(HandlerFactory handlerFactory)
        {
            menuHandlerT2 = handlerFactory.GetMenuHandlerT2();
            categoryHandlerT2 = handlerFactory.GetCategoryHandlerT2();
            itemHandlerT2 = handlerFactory.GetItemHandlerT2();
        }

        public async Task<Menu> AddMenuAsync(Menu menu)
        {
            try
            {
                Menu menuAdded = await menuHandlerT2.AddMenu(menu);
                if (menu.Categories.Count > 0)
                {
                    foreach (Category category in menu.Categories)
                    {
                        await categoryHandlerT2.AddCategory(category);
                        if (category.Items.Count > 0)
                        {
                            foreach (Item item in category.Items)
                            {
                                await itemHandlerT2.AddItem(item);
                            }
                        }
                    }
                }

                return menuAdded;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Menu> UpdateMenuAsync(Menu menu)
        {
            try
            {
                if (menu.Categories.Count > 0)
                {
                    foreach (Category category in menu.Categories)
                    {
                        await categoryHandlerT2.UpdateCategory(category);
                        if (category.Items.Count > 0)
                        {
                            foreach (Item item in category.Items)
                            {
                                await itemHandlerT2.UpdateItem(item);
                            }
                        }
                    }
                }
                return await menuHandlerT2.UpdateMenu(menu);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Menu> GetMenuAsync(int menuId)
        {
            try
            {
                Menu menu = await menuHandlerT2.GetMenu(menuId);
                IList<Category> categories =  await categoryHandlerT2.GetCategories(menuId);
                foreach (Category category in categories)
                {
                    IList<Item> items = await itemHandlerT2.GetItems(category.CategoryId);
                    category.Items = items;
                }
                menu.Categories = categories;
                return menu;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Menu> GetMenuByRestaurantAsync(string username)
        {
            try
            {
                Menu menu = await menuHandlerT2.GetMenuByRestaurant(username);
                IList<Category> categories = await categoryHandlerT2.GetCategories(menu.MenuId);
                foreach (Category category in categories)
                {
                    IList<Item> items = await itemHandlerT2.GetItems(category.CategoryId);
                    category.Items = items;
                }
                menu.Categories = categories;
                return menu;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}