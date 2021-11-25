using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler
{
    public interface ISocketRestaurantHandler
    {
        Task<Restaurant> GetRestaurant(string id); 
        Task<Restaurant> AddRestaurant(Restaurant restaurant);
    }
}