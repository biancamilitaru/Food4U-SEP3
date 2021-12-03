using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.CustomerHandler
{
    public interface ICustomerHandler
    {
        Task<Customer> AddCustomer(Customer customer);
    }
}