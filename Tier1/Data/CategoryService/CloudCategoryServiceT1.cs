using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.CategoryService
{
    public class CloudCategoryServiceT1 : ICategoryServiceT1
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudCategoryServiceT1()
        {
            client = new HttpClient();
        }
        
        //TODO fix this method and the rest
        public async Task AddCategoryAsync(Category category)
        {
            string categoryAsJson = JsonSerializer.Serialize(category);
            
            StringContent content = new StringContent(
                categoryAsJson,
                Encoding.UTF8,
                "application/json");

            Console.WriteLine(content);

            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Category/{category.Name}", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");

        }

        public async Task<Category>  GetCategoryAsync(int categoryId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri+"/Category?categoryId="+categoryId.ToString());

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            Category category = JsonSerializer.Deserialize<Category>(result,new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );
            return category;
        }

        public async Task<IList<Category>> GetCategoriesAsync(int menuId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri+"/Categories?menuId="+menuId);

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            IList<Category> categories = JsonSerializer.Deserialize<IList<Category>>(result,new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );
            return categories;
        }


        public async Task UpdateCategoryAsync(Category category)
        {
            string categoryAsJson = JsonSerializer.Serialize(category);
            HttpContent content = new StringContent(categoryAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Category/{category.Name}", content);
        
        }

        public async Task RemoveCategoryAsync(int categoryId)
        {
            await client.DeleteAsync($"{uri}/Category/{categoryId}");
        }
    }
}