using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;
using Food4U_SEP3.SocketHandler.CustomerHandler;
using Food4U_SEP3.SocketHandler.DriverHandler;
using Food4U_SEP3.SocketHandler.DriverHandler;
using Food4U_SEP3.SocketHandler.ItemHandler;
using Food4U_SEP3.SocketHandler.OrderHandler;

namespace Food4U_SEP3.Service.OrderService
{
    public class OrderServiceT2 : IOrderServiceT2
    {
        private readonly IOrderHandlerT2 orderHandlerT2;
        private readonly ICustomerHandlerT2 customerHandlerT2;
        private readonly IEmailService emailService;
        private readonly IRestaurantHandlerT2 restaurantHandlerT2;
        private readonly IDriverHandlerT2 driverHandlerT2;
        private readonly IItemHandlerT2 itemHandlerT2;
        
        public OrderServiceT2(IOrderHandlerT2 orderHandlerT2, IEmailService emailService,
            ICustomerHandlerT2 customerHandlerT2, IRestaurantHandlerT2 restaurantHandlerT2, IItemHandlerT2 itemHandlerT2)
        {
            this.orderHandlerT2 = orderHandlerT2;
            this.emailService = emailService;
            this.customerHandlerT2 = customerHandlerT2;
            this.restaurantHandlerT2 = restaurantHandlerT2;
            this.itemHandlerT2 = itemHandlerT2;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            try
            {
                Order orderAdded = await orderHandlerT2.AddOrder(order);
                await itemHandlerT2.OrderItems(order);
                return orderAdded;
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

        public async Task<IList<Order>> GetPreviousOrdersAsync(string customerUsername)
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
                await orderHandlerT2.UpdateOrder(order);
                Order editedOrder = await orderHandlerT2.UpdateOrder(order);
                Customer customer = await customerHandlerT2.GetCustomer(order.CustomerUsername);
                Driver driver = await driverHandlerT2.GetDriver(order.DriverUsername);
                Restaurant restaurant = await restaurantHandlerT2.GetRestaurant(order.RestaurantUsername);
                if (editedOrder != null)
                {
                    if (editedOrder.TimeEstimation!=0)
                    {
                        emailService.SendEmail("Order info - " + restaurant.Name, 
                            "There is a change in your order. Estimation time for preparation is " +order.TimeEstimation+ " minutes",
                            customer.Email);
                    }
                    else
                    {
                       emailService.SendEmail("Order info - " + restaurant.Name, 
                                               "There is a change in your order. Your status has been updated to " +order.Status,
                                               customer.Email);     
                    }
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

        public async Task<IList<Order>> GetReadyForPickUpOrdersAsync()
        {
            try
            {
                return await orderHandlerT2.GetReadyForPickupOrders();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            try
            {
                Order order = await orderHandlerT2.GetOrder(orderId);
                order.Items = await itemHandlerT2.GetOrderedItems(orderId);
                return order;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}