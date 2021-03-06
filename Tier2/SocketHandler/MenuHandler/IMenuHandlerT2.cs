using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler
{
    public interface IMenuHandlerT2
    {
        Task<Menu> AddMenu(Menu menu);
        Task<Menu> UpdateMenu(Menu menu);
        Task<Menu> GetMenu(int menuId);
        Task<Menu> GetMenuByRestaurant(string username);
    }
}