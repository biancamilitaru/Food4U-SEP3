using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler
{
    public interface ISocketCategoryHandlerT2
    {
        Task<Category> AddCategory(Category category);

        Task<Category> UpdateCategory(Category category, int categoryId);
    }
}