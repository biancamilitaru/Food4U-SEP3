using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.CategoryService
{
    public interface ICategoryServiceT2
    {
        Task<Category> AddCategoryAsync(Category category);

        Task<Category> GetCategoryAsync(int categoryId);
        
        Task<IList<Category>> GetCategoriesAsync(int menuId);

        Task<Category> UpdateCategoryAsync(Category category);

        Task DeleteCategoryAsync(int categoryId);
    }
}