using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.CustomerService
{
    public class CloudCustomerService : ICustomerService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;


        public CloudCustomerService()
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
        
        
    }
}