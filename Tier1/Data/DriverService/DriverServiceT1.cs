using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.DriverService
{
    public class DriverServiceT1 : IDriverServiceT1
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public DriverServiceT1()
        {
            client = new HttpClient();
        }
        
        public async Task AddDriverAsync(Driver driver)
        {
            string driverAsJson = JsonSerializer.Serialize(driver);

            StringContent content = new StringContent(
                driverAsJson,
                Encoding.UTF8,
                "application/json");

            Console.WriteLine(content);

            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Customer", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }
    }
}