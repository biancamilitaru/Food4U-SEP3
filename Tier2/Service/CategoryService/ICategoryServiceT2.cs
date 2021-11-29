using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.CategoryService
{
    public interface ICategoryServiceT2
    {
        Task<Category> AddCategoryAsync(Category category);

        Task<Category> UpdateCategoryAsync(Category category, int categoryId);
    }
}