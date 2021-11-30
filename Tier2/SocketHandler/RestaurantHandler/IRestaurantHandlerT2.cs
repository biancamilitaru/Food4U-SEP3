using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler
{
    public interface IRestaurantHandlerT2
    {
        Task<Restaurant> GetRestaurant(int restaurantId); 
        Task<Restaurant> AddRestaurant(Restaurant restaurant);
        Task<Restaurant> UpdateRestaurant(Restaurant restaurant, int restaurantId);
        Task<Restaurant> RemoveRestaurant(int restaurantId);
        Task<Restaurant> ValidateLogin(string username);


    }
}