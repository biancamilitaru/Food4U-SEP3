using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.ItemHandler
{
    public interface IItemHandlerT2
    {
        Task<Item> AddItem(Item item, string categoryName);
    }
}