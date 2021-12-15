using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.DeliveryService
{
    public interface IDeliveryServiceT2
    {
        Task<Delivery> GetDeliveryAsync(int deliveryId);
        Task<Delivery> AddDeliveryOptionAsync(Delivery delivery);
        Task<IList<Delivery>> GetDeliveryOptionsByUsernameAsync(string username);
        Task<Delivery> UpdateDeliveryOptionAsync(Delivery delivery);
        Task<Delivery> DeleteDeliveryOptionAsync(int deliveryId);
    }
}