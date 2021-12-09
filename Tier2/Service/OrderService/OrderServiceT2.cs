using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler.OrderHandler;

namespace Food4U_SEP3.Service.OrderService
{
    public class OrderServiceT2 : IOrderServiceT2
    {
        private readonly IOrderHandlerT2 orderHandlerT2;
        
        public OrderServiceT2(IOrderHandlerT2 orderHandlerT2)
        {
            this.orderHandlerT2 = orderHandlerT2;
        }
        
        public async Task<Order> AddOrderAsync(Order order)
        {
            try
            {
                return await orderHandlerT2.AddOrder(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Order>> GetIncomingOrdersAsync(string restaurantUsername)
        {
            try
            {
                return await orderHandlerT2.GetIncomingOrders(restaurantUsername);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<IList<Order>> GetAcceptedOrdersAsync(string restaurantUsername)
        {
            try
            {
                return await orderHandlerT2.GetAcceptedOrders(restaurantUsername);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<Order> UpdateOrderAsync(Order order)
        {
            try
            {
                return await orderHandlerT2.UpdateOrder(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task DeleteOrderAsync(int orderId)
        {
            try
            {
                await orderHandlerT2.DeleteOrder(orderId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}