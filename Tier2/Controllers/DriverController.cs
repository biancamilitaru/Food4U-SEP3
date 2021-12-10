using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Service.DriverService;
using Food4U_SEP3.SocketHandler.DriverHandler;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class DriverController : ControllerBase
    {
        private readonly IDriverServiceT2 driverService;
        
        public DriverController(IDriverServiceT2 driverService) => this.driverService = driverService;
        
        [HttpPost]
        public async Task<ActionResult<Driver>> AddDriverAsync([FromBody] Driver driver)
        {
            try
            {
                await driverService.AddDriverAsync(driver);
                return Created($"/{driver}", driver);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<Driver>> GetDriverAsync([FromQuery] string username)
        {
            try
            {
                Driver driver = await driverService.ValidateLoginAsync(username);
                return Ok(driver);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateDriverAsync([FromBody] Driver driver)
        {
            try
            {
                await driverService.UpdateDriverAsync(driver);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}