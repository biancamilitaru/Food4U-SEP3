using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Models;

namespace Food4U_SEP3.RestaurantServices
{
    public interface IRestaurantService
    {
        Task<Restaurant> GetRestaurantAsync(string username);
        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(string username);
        Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant);
        Task <Restaurant> ValidateLoginAsync(string username);
        Task<List<Restaurant>> GetRestaurantsAsync();

    }
}