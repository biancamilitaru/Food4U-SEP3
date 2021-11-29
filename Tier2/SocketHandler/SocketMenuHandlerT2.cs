using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Models;
using Food4U_SEP3.Service.MenuService;

namespace Food4U_SEP3.SocketHandler
{
    public class SocketMenuHandlerT2 : ISocketMenuHandlerT2
    {
        private readonly TcpClient tcpClient = new ("127.0.0.1", 2910);
        private readonly NetworkStream stream;

        public SocketMenuHandlerT2()
        {
            stream = tcpClient.GetStream();
        }
        
        private void SendToServer(string type, string context)
        {
            Request newRequest = new Request
            {
                Type = type,
                Context = context
            };
            string serialisedRequest = JsonSerializer.Serialize(newRequest);
            byte[] dataToServer = Encoding.ASCII.GetBytes(serialisedRequest);
            stream.Write(dataToServer, 0, dataToServer.Length);
        }


        public Task<Menu> AddMenu(Menu menu)
        {
            string serializedMenu = JsonSerializer.Serialize(menu);
            SendToServer("AddMenu", serializedMenu);
            return Task.FromResult(menu);
        }

        public Task<Menu> UpdateMenu(Menu menu, int menuId)
        {
            string serialisedMenu = JsonSerializer.Serialize(menu);
            SendToServer("UpdateMenu",serialisedMenu + menuId);
            return Task.FromResult(menu);
        }
    }
}