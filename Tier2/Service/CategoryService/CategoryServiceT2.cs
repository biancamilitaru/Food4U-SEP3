using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;

namespace Food4U_SEP3.Service.CategoryService
{
    public class CategoryServiceT2 : ICategoryServiceT2
    {
        private readonly ISocketCategoryHandlerT2 socketCategoryHandler;

        public CategoryServiceT2()
        {
           socketCategoryHandler = new SocketCategoryHandlerT2();
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            try
            {
                return await socketCategoryHandler.AddCategory(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Category> UpdateCategoryAsync(Category category, int categoryId)
        {
            try
            {
                return await socketCategoryHandler.UpdateCategory(category, categoryId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        }
    }
