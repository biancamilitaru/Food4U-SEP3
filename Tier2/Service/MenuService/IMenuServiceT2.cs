using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.MenuService
{
    public interface IMenuServiceT2 
    {
        Task<Menu> AddMenuAsync(Menu menu);
        Task<Menu> UpdateMenuAsync(Menu menu, int menuId);
        Task<Menu> GetMenuAsync(int menuId);
    }
}