using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using System.Net;
using System.Net.Mail;

namespace Food4U_SEP3.SocketHandler.CustomerHandler
{
    public class CustomerSocketHandlerT2T2 :SocketHandler, ICustomerHandlerT2
    {
        public Task<Customer> AddCustomer(Customer customer)
        {
            string customerAsJson = JsonSerializer.Serialize(customer);
            SendToServer("AddCustomer",customerAsJson);
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

        public Task<Customer> UpdateCustomer(Customer customer)
        {
            string customerAsJson = JsonSerializer.Serialize(customer);
            SendToServer("UpdateCustomer",customerAsJson);
            return Task.FromResult(customer);
        }
        
        public Task<Customer> DeleteCustomer(string username)
        {
            SendToServer("DeleteCustomer",username);
            Customer deleteCustomer = JsonSerializer.Deserialize<Customer>(GetFromServer());
            return Task.FromResult(deleteCustomer);
        }
    }
}