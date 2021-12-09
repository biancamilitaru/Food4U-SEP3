using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;
using Food4U_SEP3.SocketHandler.CustomerHandler;
using Food4U_SEP3.SocketHandler.OrderHandler;

namespace Food4U_SEP3.Service.OrderService
{
    public class OrderServiceT2 : IOrderServiceT2
    {
        private readonly IOrderHandlerT2 orderHandlerT2;
        private readonly ICustomerHandlerT2 customerHandlerT2;
        private readonly IEmailService emailService;
        private readonly IRestaurantHandlerT2 restaurantHandlerT2;
        
        public OrderServiceT2(IOrderHandlerT2 orderHandlerT2, IEmailService emailService, ICustomerHandlerT2 customerHandlerT2, IRestaurantHandlerT2 restaurantHandlerT2)
        {
            this.orderHandlerT2 = orderHandlerT2;
            this.emailService = emailService;
            this.customerHandlerT2 = customerHandlerT2;
            this.restaurantHandlerT2 = restaurantHandlerT2;
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

        public async Task<IList<Order>> GetIncomingOrdersAsync(string restaurantUsername)
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

        public async Task<IList<Order>> GetPreviousOrderAsync(string customerUsername)
        {
            try
            {
               return await orderHandlerT2.GetPreviousOrders(customerUsername);
               
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
                Order editedOrder = await orderHandlerT2.UpdateOrder(order);
                Customer customer = await customerHandlerT2.GetCustomer(order.CustomerUsername);
                Restaurant restaurant = await restaurantHandlerT2.GetRestaurant(order.RestaurantUsername);
                if (editedOrder != null)
                {
                    emailService.SendEmail("Order info - " + restaurant.Name, 
                        "There is a change in your order. Your status has been updated to,<\\br>"+
                        "Status of your order: " +order.Status,
                        customer.Email);    
                }
                return editedOrder;
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