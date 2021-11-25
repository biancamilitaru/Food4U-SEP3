using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.RestaurantServices
{
    public class RestaurantService : IRestaurantService
    {
        private readonly ISocketRestaurantHandler _restaurantHandler;
        
        public RestaurantService()
        {
            _restaurantHandler = new SocketRestaurantHandler();
        }

        public async Task<IList<Restaurant>> GetRestaurantsAsync()
        {
            throw new System.NotImplementedException();
        }
        
        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            try
            {
                return await _restaurantHandler.AddRestaurant(restaurant);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task RemoveRestaurantAsync(int restaurantID)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant)
        {
            throw new System.NotImplementedException();
        }
    }
}