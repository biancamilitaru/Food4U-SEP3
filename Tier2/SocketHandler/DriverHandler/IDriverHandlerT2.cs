using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.DriverHandler
{
    public interface IDriverHandlerT2
    {
        Task<Driver> AddDriver(Driver driver);

        Task<Driver> ValidateLogin(string username);

        Task<Driver> UpdateDriver(Driver driver);

        Task<Driver> GetDriver(string username);

        Task<Driver> DeleteDriver(string username);
    }
}