using System.Threading.Tasks;
using Entities;

namespace Client.Data.CustomerService
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(Customer customer);
    }
}