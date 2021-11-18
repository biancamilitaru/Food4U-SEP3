using System.Threading.Tasks;
using Food4U_SEP3.Models;

namespace Client.Data.UserServices
{
    public interface IUserServices
    {
        Task<User> ValidateLoginAsync(string username, string password);
    }
}