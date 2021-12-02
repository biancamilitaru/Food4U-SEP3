using System.Threading.Tasks;
using Entities;

namespace Client.Data.ItemService
{
    public interface IItemServiceT1
    {
        Task AddItemAsync(Item item);
        
        Task EditItemAsync(Item item);

        Task DeleteItemAsync(Item item);

    }
}