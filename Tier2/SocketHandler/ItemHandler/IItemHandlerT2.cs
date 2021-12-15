using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.ItemHandler
{
    public interface IItemHandlerT2
    {
        Task<Item> AddItem(Item item);
        Task<IList<Item>> GetItems(int categoryId);
        Task<Item> UpdateItem(Item item);
        Task<Item> DeleteItem(int itemId);
        Task<Item> GetItem(int itemId);
        Task<Order> OrderItems(Order order);
        Task<IList<Item>> GetOrderedItems(int orderId);
    }
}