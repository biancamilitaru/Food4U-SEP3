﻿using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.DriverHandler
{
    public class DriverSocketHandlerT2 : SocketHandler,IDriverHandlerT2
    {
        public Task<Driver> AddDriver(Driver driver)
        {
            string driverAsJson = JsonSerializer.Serialize(driver);
            SendToServer("AddDriver",driverAsJson);
            return Task.FromResult(driver);
        }

        public Task<Driver> ValidateLogin(string username)
        {
            SendToServer("ValidateDriver", username);
            Driver driver = JsonSerializer.Deserialize<Driver>(GetFromServer());
            return Task.FromResult<Driver>(driver);
        }
    }
}