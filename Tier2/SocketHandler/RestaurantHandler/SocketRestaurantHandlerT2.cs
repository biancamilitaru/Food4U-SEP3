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

        public Task<Restaurant> GetRestaurant(string username)
        {
            SendToServer("GetRestaurant",username);
            Restaurant getRestaurant = JsonSerializer.Deserialize<Restaurant>(GetFromServer());
            return Task.FromResult(getRestaurant);
        }

        public Task<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            string serialisedRestaurant = JsonSerializer.Serialize(restaurant);
            SendToServer("AddRestaurant",serialisedRestaurant);
            return Task.FromResult(restaurant);
        }

        public Task<Restaurant> UpdateRestaurant(Restaurant restaurant ,string username)
        {
            string serialisedRestaurant = JsonSerializer.Serialize(restaurant);
            SendToServer("UpdateRestaurant",serialisedRestaurant + username);
            return Task.FromResult(restaurant);
        }

        public Task<Restaurant> DeleteRestaurant(string username)
        {
            SendToServer("DeleteRestaurant",username.ToString());
            Restaurant deleteRestaurant = JsonSerializer.Deserialize<Restaurant>(GetFromServer());
            return Task.FromResult(deleteRestaurant);
        }

        public Task<Restaurant> ValidateLogin(string username)
        {
            SendToServer("ValidateRestaurant",username);
            Restaurant restaurant = JsonSerializer.Deserialize<Restaurant>(GetFromServer());
            return Task.FromResult(restaurant);
        }
        public Task<IList<Restaurant>> GetRestaurants()
        {
            SendToServer("GetRestaurants",null);
            IList<Restaurant> getRestaurants = JsonSerializer.Deserialize<IList<Restaurant>>(GetFromServer());
            return Task.FromResult(getRestaurants);
        }
        
    }
}