using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.OrderService
{
    public interface IOrderServiceT1
    {
        Task AddOrderAsync(Order order);
        Task<List<Order>> GetIncomingOrdersAsync(string restaurantUsername);

        Task<List<Order>> GetAcceptedOrdersAsync(string restaurantUsername);
        Task<List<Order>> GetPreviousOrdersAsync(string customerUsername);
    }
}