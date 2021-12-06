using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.CustomerService
{
    public class CloudCustomerServiceT1 : ICustomerServiceT1
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;


        public CloudCustomerServiceT1()
        {
            client = new HttpClient();
        }
        
        public async Task AddCustomerAsync(Customer customer)
        {
            string customerAsJson = JsonSerializer.Serialize(customer);

            StringContent content = new StringContent(
                customerAsJson,
                Encoding.UTF8,
                "application/json");

            Console.WriteLine(content);

            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Customers", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task<Customer> ValidateCustomerAsync(string username, string password)
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/Customers?username=" + username);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string customerAsJson = await response.Content.ReadAsStringAsync();
                Customer resultCustomer = JsonSerializer.Deserialize<Customer>(customerAsJson);
                
                if (resultCustomer.Password.Equals(password))
                {
                    return resultCustomer;
                }
                else
                {
                    throw new Exception("Wrong password");
                }
            }

            throw new Exception("Customer not found");
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            string customerAsJson = JsonSerializer.Serialize(customer);
            HttpContent content = new StringContent(customerAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Customer/{customer.Username}", content);
        }

        public async Task DeleteCustomerAsync(string username)
        {
            //TODO need to check the uri
            await client.DeleteAsync($"{uri}/Customer?customer="+username);
        }
    }
}