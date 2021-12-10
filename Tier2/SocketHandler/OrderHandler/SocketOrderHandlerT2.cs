using System;
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

        public Task<IList<Order>> GetIncomingOrders(string restaurantUsername)
        {
            SendToServer("GetIncomingOrders",restaurantUsername);
            IList<Order> orders = JsonSerializer.Deserialize<IList<Order>>(GetFromServer());
            
            return Task.FromResult(orders);
        }
        
        public Task<IList<Order>> GetReadyForPickupOrders(string driverUsername)
        {
            SendToServer("GetReadyForPickupOrders",driverUsername);
            IList<Order> orders = JsonSerializer.Deserialize<IList<Order>>(GetFromServer());
            
            return Task.FromResult(orders);
        }

        public Task<Order> UpdateOrder(Order order)
        {
            string serializedOrder = JsonSerializer.Serialize(order);
            SendToServer("UpdateCategory", serializedOrder);
            return Task.FromResult(order);
        }
        public Task<Order> DeleteOrder(int orderId)
        {
            SendToServer("DeleteOrder",orderId.ToString());
            Order deleteOrder = JsonSerializer.Deserialize<Order>(GetFromServer());
            return Task.FromResult(deleteOrder);
        }

        public Task<IList<Order>> GetAcceptedOrders(string restaurantUsername)
        {
            SendToServer("GetAcceptedOrders",restaurantUsername);
            IList<Order> getOrders = JsonSerializer.Deserialize<IList<Order>>(GetFromServer());
            return Task.FromResult(getOrders);
        }
        
        public Task<IList<Order>> GetPreviousOrders(string customerUsername)
        {
            SendToServer("GetPreviousOrders",customerUsername);
            IList<Order> getOrders = JsonSerializer.Deserialize<IList<Order>>(GetFromServer());
            
            return Task.FromResult(getOrders);
        }
    }
}