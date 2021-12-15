using System;
using System.Threading.Tasks;

using Entities;
using Food4U_SEP3.SocketHandler.DeliveryHandler;

namespace Food4U_SEP3.Service.DeliveryService
{
    public class DeliveryServiceT2 : IDeliveryServiceT2
    {
        private readonly IDeliveryHandlerT2 deliveryHandlerT2;
        
        public DeliveryServiceT2(IDeliveryHandlerT2 deliveryHandler)
        {
            this.deliveryHandlerT2 = deliveryHandler;
          
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
    }
}