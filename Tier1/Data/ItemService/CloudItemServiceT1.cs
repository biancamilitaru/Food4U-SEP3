using System;
using System.IO;
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
            //Is this okay?
            client = new HttpClient();
        }


        public async Task AddItemToCategoryAsync(Item item)
        {
            string itemAsJson = JsonSerializer.Serialize(item);
            
            StringContent content = new StringContent(
                itemAsJson,
                Encoding.UTF8,
                "application/json");

            Console.WriteLine(content);

            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Menus", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");

        }
    }
}