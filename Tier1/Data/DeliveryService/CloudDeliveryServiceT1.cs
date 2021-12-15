using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.DeliveryService
{
    public class CloudDeliveryServiceT1 : IDeliveryServiceT1
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;


        public CloudDeliveryServiceT1()
        {
            client = new HttpClient();
        }
        
        public async Task<Delivery> GetDeliveryAsync(int deliveryId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + "/Delivery?deliveryId=" + deliveryId);

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            Delivery delivery = JsonSerializer.Deserialize<Delivery>(result,new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );
            return delivery;
        }
    }
}