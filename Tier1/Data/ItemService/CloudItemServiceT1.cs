using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.ItemService
{
    public class CloudItemServiceT1 : IItemServiceT1
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudItemServiceT1()
        {
            client = new HttpClient();
        }
        
        public async Task AddItemAsync(Item item)
        {
            string menuAsJson = JsonSerializer.Serialize(item);
            
            StringContent content = new StringContent(
                menuAsJson,
                Encoding.UTF8,
                "application/json");

            Console.WriteLine(content);

            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Items/{item.ItemId}", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");
            
        }
        public async Task EditItemAsync(Item item)
        {
            string categoryAsJson = JsonSerializer.Serialize(item);
            HttpContent content = new StringContent(categoryAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Items/{item.ItemId}", content);
        
        }
    }
}