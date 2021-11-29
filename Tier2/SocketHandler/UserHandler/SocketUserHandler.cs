using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Models;

namespace Food4U_SEP3.SocketHandler
{
    public class SocketUserHandler : SocketHandler,ISocketUserHandler
    {
        private readonly TcpClient _tcpClient = new ("127.0.0.1", 2910);
        private readonly NetworkStream _stream;

        public SocketUserHandler()
        {
            _stream = _tcpClient.GetStream();
        }

        public Task<User> GetUser(string username)
        {
            SendToServer("ValidateUser",username);
            User getUser = JsonSerializer.Deserialize<User>(GetFromServer());
            return Task.FromResult(getUser); 
        }

        public Task<User> AddUser(User user)
        {
            string serialisedUser = JsonSerializer.Serialize(user);
            SendToServer("AddUser",serialisedUser);
            return Task.FromResult(user);
        }

        public Task<User> UpdateUser(User user, string username)
        {
            string serialisedUser = JsonSerializer.Serialize(user);
            SendToServer("UpdateUser",serialisedUser + username);
            return Task.FromResult(user);
        }
    }
}