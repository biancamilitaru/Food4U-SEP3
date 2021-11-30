using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using Entities;
using Food4U_SEP3.Models;

namespace Food4U_SEP3.SocketHandler
{
    public class SocketUserHandlerT2 : SocketHandler,IUserHandlerT2
    {
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