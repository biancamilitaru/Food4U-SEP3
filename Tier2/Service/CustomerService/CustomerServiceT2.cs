using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler.CustomerHandler;

namespace Food4U_SEP3.Service.CustomerService
{
    public class CustomerServiceT2 : ICustomerServiceT2
    {
        private readonly ICustomerHandlerT2 customerHandlerT2;
        private readonly IEmailService emailService;

        public CustomerServiceT2(ICustomerHandlerT2 customerHandlerT2, IEmailService emailService)
        {
            this.customerHandlerT2 = customerHandlerT2;
            this.emailService = emailService;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            try
            {
                Customer addedCustomer = await customerHandlerT2.AddCustomer(customer);
                if (addedCustomer != null)
                {
                    string htmlBody = "Welcome " + customer.FirstName + " , you are now able to sign in!";

                    emailService.SendEmail("Welcome to Food4U", htmlBody,
                        addedCustomer.Email);
                }

                return addedCustomer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Customer> ValidateLoginAsync(string username)
        {
            return await customerHandlerT2.ValidateLogin(username);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                return await customerHandlerT2.UpdateCustomer(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteCustomerAsync(string username)
        {
            try
            {
                await customerHandlerT2.DeleteCustomer(username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}