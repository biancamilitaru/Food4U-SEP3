using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Data.UserServices;
using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserServices _inMemoryUserService;

        public UserController(IUserServices inMemoryUserService)
        {
            _inMemoryUserService = inMemoryUserService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string userName, [FromQuery] string password)
        {
            try
            {
                //AWAIT recomm ?
                User user = await _inMemoryUserService.ValidateLoginAsync(userName, password);

                if (user == null)
                {
                    return NotFound();
                }

                if (!user.Password.Equals(password))
                {
                    return Unauthorized(password);
                }

                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}