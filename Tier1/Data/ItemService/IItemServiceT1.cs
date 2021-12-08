using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.ItemService
{
    public interface IItemServiceT1
    {
        Task AddItemAsync(Item item);
        
        Task<IList<Item>>  GetItemsAsync(int categoryId);
        
        Task UpdateItemAsync(Item item);

        Task DeleteItemAsync(int itemId);

        Task AddDiscountAsync(Item item,int discount);

    }
}