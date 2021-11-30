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
            string restaurantAsJson =JsonSerializer.Serialize(restaurant);

            StringContent content = new StringContent(
                restaurantAsJson,
                Encoding.UTF8,
                "application/json");
            
            Console.WriteLine(content);

            HttpResponseMessage responseMessage = await client.PostAsync(uri+"/Restaurants", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");
            }
        }

        public async Task EditRestaurantAsync(Restaurant restaurant)
        {
            string restaurantAsJson = JsonSerializer.Serialize(restaurant);
            HttpContent content = new StringContent(restaurantAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Restaurants/{restaurant.Username}", content);
        }

        public async Task<Restaurant> GetRestaurantsAsync(string username)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/Restaurants?restaurantId={username}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            Restaurant restaurant = JsonSerializer.Deserialize<Restaurant>(result,new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }
                );
            return restaurant;
        }

        public async Task RemoveRestaurantAsync(string username)
        {
            await client.DeleteAsync($"{uri}/Restaurants/{username}");
        }
    }
}