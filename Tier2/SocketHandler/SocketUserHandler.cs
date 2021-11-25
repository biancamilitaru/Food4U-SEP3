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
    public class SocketUserHandler : ISocketUserHandler
    {
        private readonly TcpClient _tcpClient = new ("127.0.0.1", 2910);
        private readonly NetworkStream _stream;

        public SocketUserHandler()
        {
            _stream = _tcpClient.GetStream();
        }
        
        public void SendToServer(string type, string context)
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

        public String GetFromServer()
        {
            byte[] fromServer = new byte[1024];
            int bytesRead = _stream.Read(fromServer, 0, fromServer.Length);
            string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            Console.WriteLine(response);
            return response;
        }
    

        public async Task<User> GetUser(string username)
        {
            SendToServer("ValidateUser",username);
            User getUser = JsonSerializer.Deserialize<User>(GetFromServer()); 
            //Shouldnt this be like this, instead of Task.fromResult(getuser)
            return getUser; 
        }

        public async Task<IList<Restaurant>> getRestaurants()
        {
            throw new System.NotImplementedException();
        }
    }
}