using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler
{
    public interface ICategoryHandlerT2
    {
        Task<Category> AddCategory(Category category);

        Task<Category> UpdateCategory(Category category, int categoryId);
        
        Task<Category> RemoveCategory(string categoryId);
    }
}