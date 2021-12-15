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
        
        public OrderServiceT2(HandlerFactory handlerFactory, IEmailService emailService)
        {
            orderHandlerT2 = handlerFactory.GetOrderHandlerT2();
            customerHandlerT2 = handlerFactory.GetCustomerHandlerT2();
            restaurantHandlerT2 = handlerFactory.GetRestaurantHandlerT2();
            itemHandlerT2 = handlerFactory.GetItemHandlerT2();
            this.emailService = emailService;
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
                IList<Order> incomingOrders = await orderHandlerT2.GetIncomingOrders(restaurantUsername);
                foreach (Order order in incomingOrders)
                {
                    order.Items = await itemHandlerT2.GetOrderedItems(order.OrderId);
                }
                return incomingOrders;
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
                IList<Order> acceptedOrders = await orderHandlerT2.GetAcceptedOrders(restaurantUsername);
                foreach (Order order in acceptedOrders)
                {
                    order.Items = await itemHandlerT2.GetOrderedItems(order.OrderId);
                }
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
                IList<Order> previousOrders = await orderHandlerT2.GetPreviousOrders(customerUsername);
                foreach (Order order in previousOrders)
                {
                    order.Items = await itemHandlerT2.GetOrderedItems(order.OrderId);
                }
                return previousOrders;
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
                //Driver driver = await driverHandlerT2.GetDriver(order.DriverUsername);
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
                IList<Order> readyForPickupOrders = await orderHandlerT2.GetReadyForPickupOrders();
                foreach (Order order in readyForPickupOrders)
                {
                    order.Items = await itemHandlerT2.GetOrderedItems(order.OrderId);
                }
                return readyForPickupOrders;
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