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

using Food4U_SEP3.SocketHandler;


namespace Food4U_SEP3.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserHandlerT2 userHandlerT2;


        public UserService(IUserHandlerT2 userHandlerT2)
        {
            this.userHandlerT2 = userHandlerT2;
        }
        
        public async Task <User> ValidateLoginAsync(string username)
        {
            return await userHandlerT2.GetUser(username);
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                return await userHandlerT2.AddUser(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<User> UpdateUserAsync(User user, string username)
        {
            try
            {
                return await userHandlerT2.UpdateUser(user, username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    }

