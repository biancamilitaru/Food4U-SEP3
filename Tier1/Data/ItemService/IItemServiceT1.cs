using System.Threading.Tasks;
using Entities;

namespace Client.Data.ItemService
{
    public interface IItemServiceT1
    {
        Task AddItemToCategoryAsync(Item item);
    }
}