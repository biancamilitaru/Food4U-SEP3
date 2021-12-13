using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.OrderService
{
    public interface IOrderServiceT2
    {
        Task<Order> AddOrderAsync(Order order);

        Task<IList<Order>> GetIncomingOrdersAsync(string restaurantUsername);
        
        Task<IList<Order>> GetAcceptedOrdersAsync(string restaurantUsername);

        Task<IList<Order>> GetPreviousOrdersAsync(string customerUsername);
        Task<IList<Order>> GetOrderAsync(int orderId);
        Task<Order> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);

        Task<IList<Order>> GetReadyForPickUpOrdersAsync();
        
    }
}