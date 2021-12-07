using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.OrderService
{
    public interface IOrderServiceT1
    {
        Task AddOrderAsync(Order order);
        Task<List<Order>> GetIncomingOrders(string restaurantUsername);

    }
}