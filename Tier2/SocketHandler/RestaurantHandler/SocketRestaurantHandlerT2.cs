using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Models;

namespace Food4U_SEP3.SocketHandler
{
    public class SocketRestaurantHandlerT2 : SocketHandler,IRestaurantHandlerT2
    {

        public SocketRestaurantHandlerT2()
        {
        }

        public Task<Restaurant> GetRestaurant(int restaurantId)
        {
            SendToServer("GetRestaurant",restaurantId.ToString());
            Restaurant getRestaurant = JsonSerializer.Deserialize<Restaurant>(GetFromServer());
            return Task.FromResult(getRestaurant);
        }

        public Task<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            string serialisedRestaurant = JsonSerializer.Serialize(restaurant);
            SendToServer("AddRestaurant",serialisedRestaurant);
            return Task.FromResult(restaurant);
        }

        public Task<Restaurant> UpdateRestaurant(Restaurant restaurant ,int restaurantId)
        {
            string serialisedRestaurant = JsonSerializer.Serialize(restaurant);
            SendToServer("UpdateRestaurant",serialisedRestaurant + restaurantId);
            return Task.FromResult(restaurant);
        }

        public Task<Restaurant> RemoveRestaurant(int restaurantId)
        {
            SendToServer("RemoveRestaurant",restaurantId.ToString());
            Restaurant removeRestaurant = JsonSerializer.Deserialize<Restaurant>(GetFromServer());
            return Task.FromResult(removeRestaurant);
        }
    }
}