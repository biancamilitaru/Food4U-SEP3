using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.DeliveryHandler
{
    public interface IDeliveryHandlerT2
    {
        Task<Delivery> GetDelivery(int deliveryId);
        Task<Delivery> AddDeliveryOption(Delivery delivery);
        Task<IList<Delivery>> GetDeliveryOptionsByUsername(string username);
        Task<Delivery> UpdateDeliveryOption(Delivery delivery);
        Task<Delivery> DeleteDeliveryOption(int deliveryId);

    }
}