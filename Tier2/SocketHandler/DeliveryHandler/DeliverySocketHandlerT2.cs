using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.DeliveryHandler
{
    public class DeliverySocketHandlerT2 : SocketHandler, IDeliveryHandlerT2
    {
        public Task<Delivery> GetDelivery(int deliveryId)
        {
            SendToServer("GetDeliveryOption", deliveryId.ToString());
            Delivery getDelivery = JsonSerializer.Deserialize<Delivery>(GetFromServer());
            return Task.FromResult(getDelivery);
        }

        public Task<Delivery> AddDeliveryOption(Delivery delivery)
        {
            string deliveryAsJson = JsonSerializer.Serialize(delivery);
            SendToServer("AddDeliveryOption",deliveryAsJson);
            return Task.FromResult(delivery);
        }

        public Task<IList<Delivery>> GetDeliveryOptionsByUsername(string username)
        {
            SendToServer("GetDeliveryOptionsByUsername", username);
            IList<Delivery> getDeliveries = JsonSerializer.Deserialize<IList<Delivery>>(GetFromServer());
            return Task.FromResult(getDeliveries);
        }

        public Task<Delivery> UpdateDeliveryOption(Delivery delivery)
        {
            string serializedDriver = JsonSerializer.Serialize(delivery);
            SendToServer("UpdateDeliveryOption", serializedDriver);
            return Task.FromResult(delivery);
        }

        public Task<Delivery> DeleteDeliveryOption(int deliveryId)
        {
            SendToServer("DeleteDeliveryOption", deliveryId.ToString());
            Delivery deletedDelivery = JsonSerializer.Deserialize<Delivery>(GetFromServer());
            return Task.FromResult(deletedDelivery);
        }
    }
}