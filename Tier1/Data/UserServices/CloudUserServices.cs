using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Food4U_SEP3.Models;

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
            HttpResponseMessage response = await client.GetAsync(uri + "/Users?username=" + username);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                Console.Write(userAsJson);

                if (resultUser.Password.Equals(password))
                {
                    return resultUser;
                }
                else
                {
                    throw new Exception("Wrong password");
                }
            }

            throw new Exception("User not found");
        }
    }
}