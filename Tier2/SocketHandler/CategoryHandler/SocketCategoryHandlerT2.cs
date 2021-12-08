using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using Entities;
using Food4U_SEP3.Models;

namespace Food4U_SEP3.SocketHandler
{
    public class SocketCategoryHandlerT2 : SocketHandler, ICategoryHandlerT2
    {

        public Task<Category> AddCategory(Category category)
        {
            string serializedCategory = JsonSerializer.Serialize(category);
            SendToServer("AddCategory", serializedCategory);
            return Task.FromResult(category);
        }

        public Task<Category> GetCategory(int categoryId)
        {
            SendToServer("GetCategory",categoryId.ToString());
            Category getCategory = JsonSerializer.Deserialize<Category>(GetFromServer());
            return Task.FromResult(getCategory);
        }

        public Task<IList<Category>> GetCategories(int menuId)
        {
            SendToServer("GetCategories",menuId.ToString());
            IList<Category> categories = JsonSerializer.Deserialize<IList<Category>>(GetFromServer());
            return Task.FromResult(categories);
        }

        public Task<Category> UpdateCategory(Category category)
        {
            string serializedCategory = JsonSerializer.Serialize(category);
            SendToServer("UpdateCategory", serializedCategory);
            return Task.FromResult(category);
        }

        public Task<Category> DeleteCategory(int categoryId)
        {
            string categoryID = JsonSerializer.Serialize(categoryId);
            SendToServer("DeleteCategory",categoryID);
            Category deleteCategory = JsonSerializer.Deserialize<Category>(GetFromServer());
            return Task.FromResult(deleteCategory);
        }
    }
}