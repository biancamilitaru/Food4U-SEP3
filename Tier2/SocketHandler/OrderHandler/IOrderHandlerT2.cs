using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.OrderHandler
{
    public interface IOrderHandlerT2
    {
        Task<Order> AddOrder(Order order);

        Task<List<Order>> GetIncomingOrders(string restaurantUsername);

        Task<Order> UpdateOrder(Order order);
        
        Task<Order> DeleteOrder(int orderId);
    }
}