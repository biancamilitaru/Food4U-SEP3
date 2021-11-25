using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler
{
    public interface ISocketRestaurantHandler
    {
        Task<Restaurant> GetRestaurant(int restaurantId); 
        Task<Restaurant> AddRestaurant(Restaurant restaurant);
        Task<Restaurant> UpdateRestaurant(Restaurant restaurant);
        

    }
}