using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.OrderService
{
    public interface IOrderServiceT1
    {
        Task AddOrderAsync(Order order);
        Task<IList<Order>> GetIncomingOrdersAsync(string restaurantUsername);
        Task<IList<Order>> GetAcceptedOrdersAsync(string restaurantUsername);
        Task<IList<Order>> GetPreviousOrdersAsync(string customerUsername);
        Task<IList<Order>> GetReadyForPickUpOrdersAsync();

        Task<Order> GetOrderAsync(int orderId);

        Task DriverPickUpOrderAsync(Order order);

        Task DriverDeliversOrder(Order order);
        
        Task AcceptOrderAsync(Order order);
        
        Task RejectOrderAsync(Order order);
    }
}