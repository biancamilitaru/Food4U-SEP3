using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Entities;
using Food4U_SEP3.SocketHandler;
using Food4U_SEP3.SocketHandler.DeliveryHandler;

namespace Food4U_SEP3.Service.DeliveryService
{
    public class DeliveryServiceT2 : IDeliveryServiceT2
    {
        private readonly IDeliveryHandlerT2 deliveryHandlerT2;
        
        public DeliveryServiceT2(HandlerFactory handlerFactory)
        {
            deliveryHandlerT2 = handlerFactory.GetDeliveryHandlerT2();
        }
        
        public async Task<Delivery> GetDeliveryAsync(int deliveryId)
        {
            try
            {
                return await deliveryHandlerT2.GetDelivery(deliveryId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Delivery> AddDeliveryOptionAsync(Delivery delivery)
        {
            try
            {
                return await deliveryHandlerT2.AddDeliveryOption(delivery);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<Delivery>> GetDeliveryOptionsByUsernameAsync(string username)
        {
            try
            {
                return await deliveryHandlerT2.GetDeliveryOptionsByUsername(username);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Delivery> UpdateDeliveryOptionAsync(Delivery delivery)
        {
            try
            {
                return await deliveryHandlerT2.UpdateDeliveryOption(delivery);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Delivery> DeleteDeliveryOptionAsync(int deliveryId)
        {
            try
            {
                return await deliveryHandlerT2.DeleteDeliveryOption(deliveryId);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}