using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.DeliveryHandler
{
    public class DeliverySocketHandlerT2 : SocketHandler, IDeliveryHandlerT2
    {
        public Task<Delivery> GetDelivery(int deliveryId)
        {
            SendToServer("GetDelivery", deliveryId.ToString());
            Delivery getDelivery = JsonSerializer.Deserialize<Delivery>(GetFromServer());
            return Task.FromResult(getDelivery);
        }
    }
}