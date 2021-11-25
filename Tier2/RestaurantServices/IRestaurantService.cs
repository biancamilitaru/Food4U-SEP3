using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.RestaurantServices
{
    public interface IRestaurantService
    {
        Task<Restaurant> GetRestaurantAsync(int restaurantId);
        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);
        Task RemoveRestaurantAsync(int restaurantID);
        Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant);

    }
}