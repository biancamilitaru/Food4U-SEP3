using System.Threading.Tasks;
using Entities;

namespace Client.Data.CategoryService
{
    public interface ICategoryServiceT1
    {
        Task AddCategoryAsync(Category category);

        Task UpdateCategoryAsync(Category category);

        Task RemoveCategoryAsync(int categoryId);



    }
}