using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.ItemHandler
{
    public class SocketItemHandlerT2 : SocketHandler, IItemHandlerT2
    {
        public Task<Item> AddItem(Item item)
        {
            string serializedMenu = JsonSerializer.Serialize(item);
            SendToServer("AddItem", serializedMenu);
            return Task.FromResult(item);
        }
    }
}