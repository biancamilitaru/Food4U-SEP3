using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.DeliveryService
{
    public interface IDeliveryServiceT2
    {
        Task<Delivery> GetDeliveryAsync(int deliveryId);
    }
}