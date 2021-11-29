using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Food4U_SEP3.Models;

namespace Food4U_SEP3.SocketHandler
{
    public abstract class SocketHandler
    {
        private readonly TcpClient tcpClient = new("127.0.0.1", 2910);
        private readonly NetworkStream stream;

        public SocketHandler()
        {
            stream = tcpClient.GetStream();
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
            stream.Write(dataToServer, 0, dataToServer.Length);
        }
        
        public string GetFromServer()
        {
            byte[] fromServer = new byte[1024];
            int bytesRead = stream.Read(fromServer, 0, fromServer.Length);
            string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            Console.WriteLine(response);
            return response;
        }
    }
}