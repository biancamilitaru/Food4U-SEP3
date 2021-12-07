using System;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.OrderService
{
    public class OrderServiceT2 : IOrderServiceT2
    {
        private readonly IOrderServiceT2 orderServiceT2;
        
        public async Task<Order> AddOrderAsync(Order order)
        {
            try
            {
                return await orderServiceT2.AddOrderAsync(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}