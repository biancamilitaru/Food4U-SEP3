using System.Threading.Tasks;
using Entities;

namespace Client.Data.DriverService
{
    public interface IDriverServiceT1
    {
        Task AddDriverAsync(Driver driver);

    }
}