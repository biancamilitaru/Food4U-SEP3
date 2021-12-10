using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.DriverService
{
    public interface IDriverServiceT2
    {
        Task<Driver> AddDriverAsync(Driver driver);

        Task<Driver> ValidateLoginAsync(string username);

        Task<Driver> UpdateDriverAsync(Driver driver);

        Task DeleteDriverAsync(string username);
        

    }
}