using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.OrderService
{
    public interface IOrderServiceT2
    {
        Task<Order> AddOrderAsync(Order order);
    }
}