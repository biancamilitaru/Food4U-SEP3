using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler.DriverHandler;

namespace Food4U_SEP3.Service.DriverService
{
    public class DriverServiceT2 : IDriverServiceT2
    {
        private readonly IDriverHandlerT2 driverHandlerT2;

        public DriverServiceT2(IDriverHandlerT2 driverHandlerT2)
        {
            this.driverHandlerT2 = driverHandlerT2;
        }
        
        public async Task<Driver> GetDriverAsync(string username)
        {
            try
            {
                return await driverHandlerT2.GetDriver(username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<Driver> AddDriverAsync(Driver driver)
        {
            try
            {
                return await driverHandlerT2.AddDriver(driver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Driver> ValidateLoginAsync(string username)
        {
            return await driverHandlerT2.ValidateLogin(username);
        }

        public async Task<Driver> UpdateDriverAsync(Driver driver)
        {
            try
            {
                return await driverHandlerT2.UpdateDriver(driver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteDriverAsync(string username)
        {
            try
            {
                await driverHandlerT2.DeleteDriver(username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}