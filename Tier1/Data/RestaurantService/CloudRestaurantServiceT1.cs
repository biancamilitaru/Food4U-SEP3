using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Components.Authorization;

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
            
            Console.WriteLine(restaurantAsJson);

            HttpResponseMessage responseMessage = await client.PostAsync(uri+"/Restaurant", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");
            }
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            string restaurantAsJson = JsonSerializer.Serialize(restaurant);
            HttpContent content = new StringContent(restaurantAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync(uri+"/Restaurant", content);
        }

        public async Task<Restaurant> GetRestaurantAsync(string username)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri+"/Restaurant?username="+username);

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
            HttpResponseMessage response = await client.GetAsync(uri + "/Restaurant?username=" + username);
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
            await client.PatchAsync($"{uri}/Restaurant/{restaurant.Username}", content);

        }

        public async Task<IList<Restaurant>> GetRestaurantsAsync()
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/Restaurants");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
           IList<Restaurant> restaurants = JsonSerializer.Deserialize<IList<Restaurant>>(result,new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );
            return restaurants;
        }

        public async Task AcceptOrderAsync(Order order)
        {
            order.Status = "Accepted";
            string orderAsJson = JsonSerializer.Serialize(order);
            HttpContent content = new StringContent(orderAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Order/{order.OrderId}", content);
        }


        public async Task DeleteRestaurantAsync(string username)
        {
            Console.WriteLine(uri+"Restaurant?username="+username);
            await client.DeleteAsync(uri+"/Restaurant?username="+username);

        }
        
        public async Task RejectOrderAsync(Order order)
        {
            //TODO can someone check if this is okay? -Kyra
            order.Status = "Rejected";
            string orderAsJson = JsonSerializer.Serialize(order);
            HttpContent content = new StringContent(orderAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Order/{order.OrderId}", content);
        }
    }
}