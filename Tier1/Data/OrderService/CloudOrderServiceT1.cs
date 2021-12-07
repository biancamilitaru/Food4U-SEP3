using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.OrderService
{
    public class CloudOrderServiceT1 : IOrderServiceT1
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudOrderServiceT1()
        {
            client = new HttpClient();
        }
        
        
        public async Task AddOrderAsync(Order order)
        {
            string orderAsJson = JsonSerializer.Serialize(order);
            
            StringContent content = new StringContent(
                orderAsJson,
                Encoding.UTF8,
                "application/json");

            Console.WriteLine(content);

            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Orders", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");
            
        }
    }
}