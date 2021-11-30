using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.RestaurantService
{
    public interface IRestaurantService
    {
        Task AddRestaurantAsync(Restaurant restaurant);
        Task EditRestaurantAsync(Restaurant restaurant);

        Task<Restaurant> GetRestaurantsAsync(string username);
        Task RemoveRestaurantAsync(string username);
    }
}