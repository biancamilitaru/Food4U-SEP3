using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.DeliveryHandler
{
    public interface IDeliveryHandlerT2
    {
        Task<Delivery> GetDelivery(int deliveryId);
    }
}