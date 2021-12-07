using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.OrderHandler
{
    public interface IOrderHandlerT2
    {
        Task<Order> AddOrder(Order order);
    }
}