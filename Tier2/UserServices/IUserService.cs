using System.Collections.Generic;
using System.Threading.Tasks;
using Food4U_SEP3.Models;
using Food4U_SEP3.SocketHandler;

namespace Food4U_SEP3.UserServices
{
    public interface IUserService
    {
        Task <User> ValidateLoginAsync(string username);
        Task<User> AddUserAsync(User user);

    }
}