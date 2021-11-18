using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.RestaurantService
{
    public interface IRestaurantService
    {
        Task<IList<Restaurant>> GetRestaurantsAsync();
        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);
        Task RemoveRestaurantAsync(int restaurantID);
        Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant);

    }
}