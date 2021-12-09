using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.ItemsService
{
    public interface IItemServiceT2
    {
        Task<Item> AddItemAsync(Item item);
        Task<IList<Item>> GetItemsAsync(int categoryId);
        Task<Item> UpdateItemAsync(Item item);
        Task DeleteItemAsync(int itemId);
        Task<Item> GetItemAsync(int itemId);

    }
}