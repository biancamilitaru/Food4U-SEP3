 using System;
 using System.Collections.Generic;
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

            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Item/{item.ItemId}", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");
            
        }

        public async Task<IList<Item>> GetItemsAsync(int categoryId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri+"/Items?categoryId="+categoryId);

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            IList<Item> items = JsonSerializer.Deserialize<IList<Item>>(result,new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );
            return items;
        }

        public async Task UpdateItemAsync(Item item)
        {
            string categoryAsJson = JsonSerializer.Serialize(item);
            HttpContent content = new StringContent(categoryAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Item/{item.ItemId}", content);
        
        }

        public async Task DeleteItemAsync(int itemId)
        {
            await client.DeleteAsync($"{uri}/Item/{itemId}");
        }

        public async Task AddDiscountAsync(Item item, int discount)
        {
            item.Discount = discount;
            string itemAsJson = JsonSerializer.Serialize(item);
            HttpContent content = new StringContent(itemAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Item/{item.ItemId}", content);
        }
        
        public async Task<Item> GetItemAsync(int itemId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri+"/Item?itemId="+itemId);

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            Item item = JsonSerializer.Deserialize<Item>(result,new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );
            return item;
        }
    }
}