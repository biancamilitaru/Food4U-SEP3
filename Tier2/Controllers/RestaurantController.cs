using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Models;
using Food4U_SEP3.RestaurantServices;
using Food4U_SEP3.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService) => this.restaurantService = restaurantService;

        [HttpPost]
        public async Task<ActionResult<Restaurant>> AddRestaurantAsync([FromBody] Restaurant restaurant)
        {
            try
            {
                await restaurantService.AddRestaurantAsync(restaurant);
                return Created($"/{restaurant}", restaurant);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        public async Task<ActionResult> UpdateRestaurantAsync([FromBody] Restaurant restaurant)
        {
            try
            {
                await restaurantService.UpdateRestaurantAsync(restaurant);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<Restaurant>> GetRestaurantAsync([FromQuery] string username)
        {
            try
            {
                Restaurant restaurant = await restaurantService.ValidateLoginAsync(username);
                return Ok(restaurant);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteRestaurantAsync([FromQuery] string username)
        {
            try
            {
                await restaurantService.DeleteRestaurantAsync(username);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/Restaurants")]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurantsAsync()
        {
            try
            {
                List<Restaurant> restaurants = await restaurantService.GetRestaurantsAsync();
                return Ok(restaurants);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        





    }
}