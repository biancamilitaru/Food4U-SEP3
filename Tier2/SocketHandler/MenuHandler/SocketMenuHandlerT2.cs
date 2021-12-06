using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Models;
using Food4U_SEP3.Service.MenuService;

namespace Food4U_SEP3.SocketHandler
{
    public class SocketMenuHandlerT2 : SocketHandler, IMenuHandlerT2
    {
        public Task<Menu> AddMenu(Menu menu)
        {
            string serializedMenu = JsonSerializer.Serialize(menu);
            SendToServer("AddMenu", serializedMenu);
            return Task.FromResult(menu);
        }

        public Task<Menu> UpdateMenu(Menu menu)
        {
            string serialisedMenu = JsonSerializer.Serialize(menu);
            SendToServer("UpdateMenu",serialisedMenu);
            return Task.FromResult(menu);
        }
        
        public Task<Menu> GetMenu(int menuId)
        {
            SendToServer("GetMenu",menuId.ToString());
            Menu getMenu = JsonSerializer.Deserialize<Menu>(GetFromServer());
            return Task.FromResult(getMenu);
        }
    }
}