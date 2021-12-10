using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler.DriverHandler;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class DriverController : ControllerBase
    {
        private readonly IDriverHandlerT2 driverHandlerT2;
        
        [HttpPost]
        public async Task<ActionResult<Driver>> AddDriverAsync([FromBody] Driver driver)
        {
            try
            {
                await driverHandlerT2.AddDriver(driver);
                return Created($"/{driver}", driver);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}