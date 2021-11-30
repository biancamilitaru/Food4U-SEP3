using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Food4U_SEP3.Models;

namespace Food4U_SEP3.SocketHandler
{
    public abstract class SocketHandler
    {
        protected readonly TcpClient tcpClient = new("127.0.0.1", 2910);
        protected readonly NetworkStream stream;

        protected SocketHandler()
        {
            stream = tcpClient.GetStream();
        }
        
        protected void SendToServer(string type, string context)
        {
            Request newRequest = new Request
            {
                Type = type,
                Context = context
            };
            string serialisedRequest = JsonSerializer.Serialize(newRequest);
            byte[] dataToServer = Encoding.ASCII.GetBytes(serialisedRequest);
            stream.Write(dataToServer, 0, dataToServer.Length);
            stream.Close();
        }
        
        protected string GetFromServer()
        {
            byte[] fromServer = new byte[1024];
            int bytesRead = stream.Read(fromServer, 0, fromServer.Length);
            string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            Console.WriteLine(response);
            stream.Close();
            return response;
        }
    }
}