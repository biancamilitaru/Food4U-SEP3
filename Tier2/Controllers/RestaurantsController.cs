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
        public async Task<ActionResult<Restaurant>> AddRestaurant([FromBody] Restaurant restaurant)
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
        public async Task<ActionResult> UpdateRestaurant([FromBody] Restaurant restaurant)
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
        public async Task<ActionResult<IList<Restaurant>>> GetRestaurants()
        {
            try
            {
                IList<Restaurant> adults = await restaurantService.GetRestaurantsAsync();
                return Ok(adults);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}