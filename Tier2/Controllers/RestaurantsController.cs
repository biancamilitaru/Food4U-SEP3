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
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantsController(IRestaurantService restaurantService) => this.restaurantService = restaurantService;

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
        [Route("{restaurantID:int}")]
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
        public async Task<ActionResult<Restaurant>> GetRestaurantAsync([FromQuery] int restaurantId)
        {
            try
            {
                Restaurant restaurant = await restaurantService.GetRestaurantAsync(restaurantId);
                return Ok(restaurant);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{restaurantID:int}")]
        public async Task<ActionResult> DeleteRestaurantAsync([FromQuery] int restaurantId)
        {
            try
            {
                await restaurantService.RemoveRestaurantAsync(restaurantId);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        

    }
}