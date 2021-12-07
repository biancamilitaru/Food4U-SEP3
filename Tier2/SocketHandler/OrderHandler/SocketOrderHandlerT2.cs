using System.Collections.Generic;
using System.Linq;
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

        public Task<List<Order>> GetIncomingOrders(string restaurantUsername)
        {
            SendToServer("GetIncomingOrders",restaurantUsername);
            IList<Order> orders = JsonSerializer.Deserialize<IList<Order>>(GetFromServer());
            
            return Task.FromResult(orders.ToList());
        }

        public Task<Order> UpdateOrder(Order order)
        {
            string serializedOrder = JsonSerializer.Serialize(order);
            SendToServer("UpdateCategory", serializedOrder);
            return Task.FromResult(order);
        }
    }
}