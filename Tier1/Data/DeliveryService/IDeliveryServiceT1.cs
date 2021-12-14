using System.Threading.Tasks;
using Entities;

namespace Client.Data.DeliveryService
{
    public interface IDeliveryServiceT1
    {
        Task<Delivery> GetDeliveryAsync(int deliveryId);
    }
}