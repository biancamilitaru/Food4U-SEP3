using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler
{
    public interface IRestaurantHandlerT2
    {
        Task<Restaurant> GetRestaurant(string username); 
        Task<Restaurant> AddRestaurant(Restaurant restaurant);
        Task<Restaurant> UpdateRestaurant(Restaurant restaurant, string username);
        Task<Restaurant> RemoveRestaurant(string username);
        Task<Restaurant> ValidateLogin(string username);


    }
}