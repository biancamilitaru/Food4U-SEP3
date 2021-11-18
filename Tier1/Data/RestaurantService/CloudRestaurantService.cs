using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Models;

namespace Client.Data.RestaurantService
{
    public class CloudRestaurantService : IRestaurantService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudRestaurantService()
        {
            client = new HttpClient();
        }

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            string restaurantAsJson = JsonSerializer.Serialize(restaurant);

            StringContent content = new StringContent(
                restaurantAsJson,
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage responseMessage = await client.PostAsync(uri, content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");
            }
        }
    }
}