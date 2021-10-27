using System.Threading.Tasks;
using Client.Models;

namespace Client.Data.UserServices
{
    public interface IUserServices
    {
        Task<User> ValidateLoginAsync(string username, string password);
    }
}