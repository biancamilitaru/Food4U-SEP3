using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        
        private readonly ISocketUserHandler _userHandler;
        
        public async Task<IList<Restaurant>> GetRestaurantsAsync()
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            throw new System.NotImplementedException();
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