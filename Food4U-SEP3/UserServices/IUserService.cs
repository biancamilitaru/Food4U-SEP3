using System.Collections.Generic;
using System.Threading.Tasks;
using Food4U_SEP3.Models;

namespace Food4U_SEP3.UserServices
{
    public interface IUserService
    {
        User ValidateLogin(string username, string password);
        Task<IList<User>> GetUsers();
    }
}