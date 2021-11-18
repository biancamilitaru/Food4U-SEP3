using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Food4U_SEP3.Models;
using Food4U_SEP3.Permistences;


namespace Food4U_SEP3.UserServices
{
    public class UserService : IUserService
    {
        private FileContext fileContext;
        public IList<User> Users { get; private set; }
        
        
        private string uri = "http://localhost:8080/api/v1/";
        
        private TcpClient tcpClient = new TcpClient("127.0.0.1", 2910);

        public UserService()
        {
            //fileContext = new FileContext();
            //Users = fileContext.Users;
        }

        /*
        public async Task<IList<User>> GetUsers()
        {
            //return Users;
        }
        */
        public async Task<User> Add(User user)
        {
            await Task.Run(() =>
            {
                
                Users.Add(user);
                SaveChanges();
            });

            return user;
        }
        public void SaveChanges()
        {
            fileContext.SaveChanges();
        }

        public async Task <User> ValidateLogin(string username)
        {
            /*
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{uri}users/{username}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            }
            return null;
            */
        
            /*
            User first = Users.FirstOrDefault(x => x.Username.Equals(username));
            if (first == null) throw new Exception("User not found");
            if (!first.Password.Equals(password)) throw new Exception("Invalid password");
            if (first != null) throw new Exception("User already exists");
            return first;
            */
            
            NetworkStream stream = tcpClient.GetStream();
            
            Request newRequest = new Request
            {
                Type = "ValidateUser",
                Context = username
            };
            
            string serialisedRequest = JsonSerializer.Serialize(newRequest);
            byte[] dataToServer = Encoding.ASCII.GetBytes(serialisedRequest);
            stream.Write(dataToServer, 0, dataToServer.Length);
            
            byte[] fromServer = new byte[1024];
            int bytesRead = stream.Read(fromServer, 0, fromServer.Length);
            string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            Console.WriteLine(response);
            
            User resultUser = JsonSerializer.Deserialize<User>(response);
            return resultUser;
            
            
        }
    }
    }

