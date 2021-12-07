using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.OrderHandler
{
    public class SocketOrderHandlerT2 : SocketHandler ,IOrderHandlerT2
    {
        public Task<Order> AddOrder(Order order)
        {
            string serializedOrder = JsonSerializer.Serialize(order);
            SendToServer("AddOrder", serializedOrder);
            return Task.FromResult(order);
        }
        
    }
}