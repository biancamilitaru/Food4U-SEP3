using System.Threading.Tasks;
using Entities;

namespace Client.Data.ItemService
{
    public interface IItemServiceT1
    {
        Task AddItemAsync(Item item);
        
        Task UpdateItemAsync(Item item);

        Task DeleteItemAsync(int itemId);

        Task AddDiscountAsync(Item item,int discount);

    }
}