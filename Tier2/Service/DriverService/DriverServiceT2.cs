using System;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.DriverService
{
    public class DriverServiceT2 : IDriverServiceT2
    {
        private readonly IDriverHandlerT2 driverHandlerT2;
        
        public DriverServiceT2(IDriverHandlerT2 driverHandlerT2)
        {
            this.driverHandlerT2 = driverHandlerT2;
          
        }
        
        public async Task<Driver> AddDriverAsync(Driver driver)
        {
            try
            {
                Driver addedDriver = await driverHandlerT2.AddDriver(driver);
               
                return addedDriver;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}