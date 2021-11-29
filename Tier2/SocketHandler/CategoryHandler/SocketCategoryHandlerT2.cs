using System.Globalization;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using Entities;
using Food4U_SEP3.Models;

namespace Food4U_SEP3.SocketHandler
{
    public class SocketCategoryHandlerT2 : SocketHandler, ISocketCategoryHandlerT2
    {
        private readonly TcpClient tcpClient = new("127.0.0.1", 2910);
        private readonly NetworkStream stream;

        public SocketCategoryHandlerT2()
        {
            stream = tcpClient.GetStream();
        }


        public Task<Category> AddCategory(Category category)
        {
            string serializedCategory = JsonSerializer.Serialize(category);
            SendToServer("AddCategory", serializedCategory);
            return Task.FromResult(category);
        }

        public Task<Category> UpdateCategory(Category category, int categoryId)
        {
            string serializedCategory = JsonSerializer.Serialize(category);
            SendToServer("UpdateCategory", serializedCategory + categoryId);
            return Task.FromResult(category);
        }
    }
}