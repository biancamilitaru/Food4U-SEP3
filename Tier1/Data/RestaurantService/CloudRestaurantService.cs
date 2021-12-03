using System;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

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

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
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
        
        public async Task<Restaurant> ValidateRestaurantAsync(string username, string password)
        {
            // TODO Change the uri if the Restaurant Controller is updated
            HttpResponseMessage response = await client.GetAsync(uri + "" + username);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string restaurantAsJson = await response.Content.ReadAsStringAsync();
                Restaurant resultRestaurant = JsonSerializer.Deserialize<Restaurant>(restaurantAsJson);
                Console.Write(restaurantAsJson);

                if (resultRestaurant.Password.Equals(password))
                {
                    return resultRestaurant;
                }
                else
                {
                    throw new Exception("Wrong password");
                }
            }

            throw new Exception("Restaurant not found");
        }

        public async Task MakeRestaurantPublicAsync(Restaurant restaurant)
        {
            restaurant.Visibility = true;
            string restaurantAsJson = JsonSerializer.Serialize(restaurant);
            HttpContent content = new StringContent(restaurantAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Restaurants/{restaurant.Username}", content);

        }

        public async Task DeleteRestaurantAsync(string username)
        {
            await client.DeleteAsync($"{uri}/Restaurants/{username}");
        }
    }
}