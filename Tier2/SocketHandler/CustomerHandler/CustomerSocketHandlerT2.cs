using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.CustomerHandler
{
    public class CustomerSocketHandlerT2T2 :SocketHandler, ICustomerHandlerT2
    {
        public Task<Customer> AddCustomer(Customer customer)
        {
            string customerAsJson = JsonSerializer.Serialize(customer);
            SendToServer("AddRestaurant",customerAsJson);
            return Task.FromResult(customer);
        }
        public Task<Customer> ValidateLogin(string username)
        {
            SendToServer("ValidateCustomer",username);
            Customer customer = JsonSerializer.Deserialize<Customer>(GetFromServer());
            return Task.FromResult(customer);
        }
        

        public Task<Customer> GetCustomer(string username)
        {
            SendToServer("GetCustomer",username);
            Customer getCustomer = JsonSerializer.Deserialize<Customer>(GetFromServer());
            return Task.FromResult(getCustomer);
        }
    }
}