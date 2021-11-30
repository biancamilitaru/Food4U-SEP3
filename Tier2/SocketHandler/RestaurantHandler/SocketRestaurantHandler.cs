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
    public class SocketRestaurantHandler : SocketHandler,ISocketRestaurantHandler
    {
        private readonly TcpClient tcpClient = new ("127.0.0.1", 2910);
        private readonly NetworkStream stream;

        public SocketRestaurantHandler()
        {
            stream = tcpClient.GetStream();
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
            SendToServer("UpdateRestaurant",serialisedRestaurant);
            return Task.FromResult(restaurant);
        }

        public Task<Restaurant> RemoveRestaurant(int restaurantId)
        {
            SendToServer("RemoveRestaurant",restaurantId.ToString());
            Restaurant removeRestaurant = JsonSerializer.Deserialize<Restaurant>(GetFromServer());
            return Task.FromResult(removeRestaurant);
        }

        public Task<Restaurant> ValidateLogin(string username)
        {
            SendToServer("ValidateRestaurant",username);
            Restaurant restaurant = JsonSerializer.Deserialize<Restaurant>(GetFromServer());
            return Task.FromResult(restaurant);
        }
    }
}