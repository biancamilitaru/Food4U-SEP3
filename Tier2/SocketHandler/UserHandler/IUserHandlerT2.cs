using System;
using System.Threading.Tasks;
using Food4U_SEP3.Models;

namespace Food4U_SEP3.SocketHandler
{
    public interface IUserHandlerT2
    {
        Task<User> GetUser(string username);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        

    }
}