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

            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Menus", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");
            
        }
        public async Task EditMenuAsync(Menu menu)
        {
            string todoAsJson = JsonSerializer.Serialize(menu);
            HttpContent content = new StringContent(todoAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Restaurants/{menu.MenuId}", content);
        }
    }
}