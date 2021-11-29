using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler
{
    public interface ISocketMenuHandlerT2
    {
        Task<Menu> AddMenu(Menu menu);

    }
}