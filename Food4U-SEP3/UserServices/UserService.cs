using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Food4U_SEP3.Models;
using Food4U_SEP3.Permistences;


namespace Food4U_SEP3.UserServices
{
    public class UserService : IUserService
    {
        //public IList<User> Users { get; private set; }
        //private readonly FileContext fileContext;
        
        private string uri = "http://localhost:8080/api/v1/";

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

        public async Task <User> ValidateLogin(string username)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{uri}users/{username}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            }
            return null;
        
            /*
            User first = Users.FirstOrDefault(x => x.Username.Equals(username));
            if (first == null) throw new Exception("User not found");
            if (!first.Password.Equals(password)) throw new Exception("Invalid password");
            if (first != null) throw new Exception("User already exists");
            return first;
            */
        }
    }
    }

