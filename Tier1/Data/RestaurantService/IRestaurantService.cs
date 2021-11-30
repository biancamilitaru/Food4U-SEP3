using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.RestaurantService
{
    public interface IRestaurantService
    {
        Task AddRestaurantAsync(Restaurant restaurant);
        Task EditRestaurantAsync(Restaurant restaurant);

        Task<Restaurant> GetRestaurantsAsync(int restaurantID);
        Task RemoveRestaurantAsync(int restaurantId);
        
        Task<Restaurant> ValidateRestaurantAsync(string username, string password);
    }
}