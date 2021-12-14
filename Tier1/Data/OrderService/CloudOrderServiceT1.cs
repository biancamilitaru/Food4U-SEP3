using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.OrderService
{
    public class CloudOrderServiceT1 : IOrderServiceT1
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudOrderServiceT1()
        {
            client = new HttpClient();
        }
        
        
        public async Task AddOrderAsync(Order order)
        {
            string orderAsJson = JsonSerializer.Serialize(order);
            
            StringContent content = new StringContent(
                orderAsJson,
                Encoding.UTF8,
                "application/json");

            Console.WriteLine(content);

            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Order", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");
            
        }

        public async Task <IList<Order>> GetIncomingOrdersAsync(string restaurantUsername)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/Orders/Incoming?restaurantUsername={restaurantUsername}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            IList<Order> order = JsonSerializer.Deserialize<IList<Order>>(result, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );
            return order;
        }

        public async Task<IList<Order>> GetAcceptedOrdersAsync(string restaurantUsername)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/Orders/Accepted?restaurantUsername={restaurantUsername}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            IList<Order> order = JsonSerializer.Deserialize<IList<Order>>(result, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );
            return order;
        }
        
        public async Task <IList<Order>> GetPreviousOrdersAsync(string customerUsername)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/Orders/Previous?customerUsername={customerUsername}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            List<Order> order = JsonSerializer.Deserialize<List<Order>>(result, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );
            return order;
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

        public async Task<Order> GetOrderAsync(int orderId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + "/Order?orderId=" + orderId);

            if (responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            Order order = JsonSerializer.Deserialize<Order>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            return order;
        }

        public async Task DriverPickUpOrderAsync(Order order)
        {
            order.Status = "Out for delivery";
            string orderAsJson = JsonSerializer.Serialize(order);
            HttpContent content = new StringContent(orderAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Order/{order.OrderId}", content);
        }

        public async Task DriverDeliversOrder(Order order)
        {
            order.Status = "Delivered";
            string orderAsJson = JsonSerializer.Serialize(order);
            HttpContent content = new StringContent(orderAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Order/{order.OrderId}", content);
        }

        public async Task AcceptOrderAsync(Order order)
        {
            order.Status = "Accepted";
            string orderAsJson = JsonSerializer.Serialize(order);
            HttpContent content = new StringContent(orderAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Order/{order.OrderId}", content);
        }
        
        public async Task RejectOrderAsync(Order order)
        {
            //TODO can someone check if this is okay? -Kyra
            order.Status = "Rejected";
            string orderAsJson = JsonSerializer.Serialize(order);
            HttpContent content = new StringContent(orderAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/Order/{order.OrderId}", content);
        }
    }
}