using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler.CustomerHandler;

namespace Food4U_SEP3.Service.CustomerService
{
    public class CustomerServiceT2 : ICustomerServiceT2
    {
        private readonly ICustomerHandlerT2 customerHandlerT2;

        public CustomerServiceT2(ICustomerHandlerT2 customerHandlerT2)
        {
            this.customerHandlerT2 = customerHandlerT2;
        }
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            try
            {
                return await customerHandlerT2.AddCustomer(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}