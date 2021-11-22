using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Food4U_SEP3.Models;
using Food4U_SEP3.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService) => this.userService = userService;

       
        
        [HttpGet]
        public async Task<ActionResult<User>> GetUser([FromQuery] string? username)
        {
            try
            {
                User user = await userService.ValidateLogin(username);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}