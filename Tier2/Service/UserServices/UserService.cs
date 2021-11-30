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
        private readonly ISocketUserHandler _userHandler;
        
        public UserService()
        {
            _userHandler = new SocketUserHandler();
        }
        
        public async Task <User> ValidateLoginAsync(string username)
        {
            return await _userHandler.GetUser(username);
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                return await _userHandler.AddUser(user);
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
                return await _userHandler.UpdateUser(user, username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    }

