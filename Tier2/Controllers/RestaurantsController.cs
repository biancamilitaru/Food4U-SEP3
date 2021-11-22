using System;
using System.Threading.Tasks;
using Client.Data.RestaurantService;
using Entities;
using Food4U_SEP3.Models;
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
                Restaurant added = await restaurantService.AddRestaurantAsync(restaurant);
                return Created($"/{added.RestaurantId}", added);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}