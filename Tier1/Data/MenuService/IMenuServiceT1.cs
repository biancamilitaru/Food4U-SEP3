using System.Threading.Tasks;
using Entities;

namespace Client.Data.MenuService
{
    public interface IMenuServiceT1
    {
        Task AddMenuAsync(Menu menu);
        Task EditMenuAsync(Menu menu);
    }
}