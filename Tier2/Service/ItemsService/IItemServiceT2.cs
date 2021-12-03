using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.ItemsService
{
    public interface IItemServiceT2
    {
        Task<Item> AddItemAsync(Item item);
        Task<Item> UpdateItemAsync(Item item, int itemId);
        
        Task DeleteItemAsync(int itemId);

    }
}