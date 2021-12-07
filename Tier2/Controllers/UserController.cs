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

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUserAsync([FromQuery] string? username)
        {
            try
            {
                User user = await userService.ValidateLoginAsync(username);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync([FromBody] User user)
        {
            try
            {
                await userService.AddUserAsync(user);
                return Created($"/{user}", user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{username}")]
        public async Task<ActionResult> UpdateUserAsync([FromBody] User user)
        {
            try
            {
                await userService.UpdateUserAsync(user);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /*
        [HttpDelete]
        [Route("{username:string}")]
        public async Task<ActionResult> DeleteUser()
        {
            try
            {
                await userService.DeleteUserAsync(username);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        */
    }
}