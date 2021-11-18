using System.Collections.Generic;
using System.Threading.Tasks;
using Food4U_SEP3.Models;
using Food4U_SEP3.SocketHandler;

namespace Food4U_SEP3.UserServices
{
    public interface IUserService
    {
        Task <User> ValidateLogin(string username);
        Task<User> Add(User user);
    }
}