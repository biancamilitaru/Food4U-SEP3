﻿using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Client.Data.CategoryService
{
    public class CloudCategoryServiceT1 : ICategoryServiceT1
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudCategoryServiceT1()
        {
            client = new HttpClient();
        }
        
        public async Task AddCategoryAsync(Category category)
        {
            string categoryAsJson = JsonSerializer.Serialize(category);
            
            StringContent content = new StringContent(
                categoryAsJson,
                Encoding.UTF8,
                "application/json");

            Console.WriteLine(content);

            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Categories", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");

        }
    }
}