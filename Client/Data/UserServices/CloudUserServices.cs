using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Data.UserServices
{
    public class CloudUserServices : IUserServices
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;
        
        public CloudUserServices()
        {
            client = new HttpClient();
        }
        
        public async Task<User> ValidateLoginAsync(string username, string password)
        {
            HttpResponseMessage response = await client.GetAsync(uri+"/users?username={username}&password={password}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            } 
            throw new Exception("User not found");
        }
    }
}