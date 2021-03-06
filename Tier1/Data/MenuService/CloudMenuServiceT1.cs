using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.MenuService
{
    public class CloudMenuServiceT1 : IMenuServiceT1
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudMenuServiceT1()
        {
            client = new HttpClient();
        }
        
        public async Task AddMenuAsync(Menu menu)
        {
            string menuAsJson = JsonSerializer.Serialize(menu);
            
            StringContent content = new StringContent(
                menuAsJson,
                Encoding.UTF8,
                "application/json");

            Console.WriteLine(content);

            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Menu", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");
            
        }
        public async Task UpdateMenuAsync(Menu menu)
        {
            string menuAsJson = JsonSerializer.Serialize(menu);
            HttpContent content = new StringContent(menuAsJson, Encoding.UTF8, "application/json");
            Console.WriteLine(uri+"/Menu/"+menu.MenuId);
            await client.PatchAsync(uri+"/Menu/"+menu.MenuId, content);
        }

        public async Task<Menu> GetMenuAsync(int restaurantId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/Menu?menuId={restaurantId}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            Menu menu = JsonSerializer.Deserialize<Menu>(result,new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );
            return menu;
        }
    }
}