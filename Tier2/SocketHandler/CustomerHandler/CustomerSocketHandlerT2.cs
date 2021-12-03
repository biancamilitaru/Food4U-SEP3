using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.CustomerHandler
{
    public class CustomerSocketHandlerT2 :SocketHandler, ICustomerHandler
    {
        public Task<Customer> AddCustomer(Customer customer)
        {
            string customerAsJson = JsonSerializer.Serialize(customer);
            SendToServer("AddRestaurant",customerAsJson);
            return Task.FromResult(customer);
        }
    }
}