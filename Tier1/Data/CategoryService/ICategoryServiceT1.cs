using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.CategoryService
{
    public interface ICategoryServiceT1
    {
        Task AddCategoryAsync(Category category);

        Task<Category>  GetCategoryAsync(int categoryId);
        
        Task<IList<Category>>  GetCategoriesAsync(int menuId);

        Task UpdateCategoryAsync(Category category);

        Task RemoveCategoryAsync(int categoryId);



    }
}