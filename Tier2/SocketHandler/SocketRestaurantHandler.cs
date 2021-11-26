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
    public class SocketRestaurantHandler : ISocketRestaurantHandler
    {
        private readonly TcpClient _tcpClient = new ("127.0.0.1", 2910);
        private readonly NetworkStream _stream;

        public SocketRestaurantHandler()
        {
            _stream = _tcpClient.GetStream();
        }
        
        private void SendToServer(string type, string context)
        {
            Request newRequest = new Request
            {
                Type = type,
                Context = context
            };
            string serialisedRequest = JsonSerializer.Serialize(newRequest);
            byte[] dataToServer = Encoding.ASCII.GetBytes(serialisedRequest);
            _stream.Write(dataToServer, 0, dataToServer.Length);
        }

        private string GetFromServer()
        {
            byte[] fromServer = new byte[1024];
            int bytesRead = _stream.Read(fromServer, 0, fromServer.Length);
            string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            Console.WriteLine(response);
            return response;
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

        public Task<Restaurant> UpdateRestaurant(Restaurant restaurant)
        {
            string serialisedRestaurant = JsonSerializer.Serialize(restaurant);
            SendToServer("UpdateRestaurant",serialisedRestaurant);
            return Task.FromResult(restaurant);
        }

        
    }
}