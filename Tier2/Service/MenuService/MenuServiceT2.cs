using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;

namespace Food4U_SEP3.Service.MenuService
{
    public class MenuServiceT2 : IMenuServiceT2
    {
        private readonly ISocketMenuHandlerT2 menuHandler;

        public MenuServiceT2()
        {
            menuHandler = new SocketMenuHandlerT2();
        }


        public async Task<Menu> AddMenuAsync(Menu menu)
        {
            try
            {
                return await menuHandler.AddMenu(menu);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Menu> UpdateMenuAsync(Menu menu, int menuId)
        {
            try
            {
                return await menuHandler.UpdateMenu(menu , menuId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}