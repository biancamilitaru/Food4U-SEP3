using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.DriverService
{
    public class CloudDriverServiceT1 : IDriverServiceT1
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudDriverServiceT1()
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

        public async Task<Driver> ValidateDriverAsync(string username, string password)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + "/Driver?username=" + username);
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                string driverAsJson = await responseMessage.Content.ReadAsStringAsync();
                Driver resultDriver = JsonSerializer.Deserialize<Driver>(driverAsJson);
                Console.WriteLine(driverAsJson);

                if (resultDriver.Password.Equals(password))
                {
                    return resultDriver;
                }
                else
                {
                    throw new Exception("Wrong password");
                }
            }

            throw new Exception("Driver not found");
        }

        public async Task UpdateDriverAsync(Driver driver)
        {
            string driverAsJson = JsonSerializer.Serialize(driver);
            HttpContent content = new StringContent(driverAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Driver/{driver.Username}", content);
        }

        public async Task DeleteDriverAsync(string username)
        {
            await client.DeleteAsync($"{uri}/Driver/{username}");
        }

        public async Task<IList<Order>> GetReadyForPickUpOrdersAsync()
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/ReadyForPickUpDriverOrders");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            IList<Order> orders = JsonSerializer.Deserialize<IList<Order>>(result,new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );
            return orders;
        }
    }
}