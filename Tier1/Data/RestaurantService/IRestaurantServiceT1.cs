using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.RestaurantService
{
    public interface IRestaurantService
    {
        Task AddRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantAsync(Restaurant restaurant);

        Task<Restaurant> GetRestaurantAsync(string username);
        Task DeleteRestaurantAsync(string username);

        Task<Restaurant> ValidateRestaurantAsync(string username, string password);

        Task MakeRestaurantPublicAsync(Restaurant restaurant);

        Task<IList<Restaurant>> GetRestaurantsAsync();

        Task AcceptOrderAsync(Order order);
        
        Task RejectOrderAsync(Order order);
    }
}