using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;

namespace Food4U_SEP3.Service.MenuService
{
    public class MenuServiceT2 : IMenuServiceT2
    {
        private readonly IMenuHandlerT2 menuHandlerT2;

        public MenuServiceT2(IMenuHandlerT2 menuHandler)
        {
            this.menuHandlerT2 = menuHandler;
        }

        public async Task<Menu> AddMenuAsync(Menu menu)
        {
            try
            {
                return await menuHandlerT2.AddMenu(menu);
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
                return await menuHandlerT2.GetMenu(menuId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}