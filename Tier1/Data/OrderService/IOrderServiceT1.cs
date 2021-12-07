using System.Threading.Tasks;
using Entities;

namespace Client.Data.OrderService
{
    public interface IOrderServiceT1
    {
        Task AddOrderAsync(Order order);
    }
}