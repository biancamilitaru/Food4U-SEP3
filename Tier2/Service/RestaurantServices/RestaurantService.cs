using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.RestaurantServices
{
    public class RestaurantService : IRestaurantService
    {
        private readonly ISocketRestaurantHandler restaurantHandler;
        
        public RestaurantService()
        {
            restaurantHandler = new SocketRestaurantHandler();
        }

        public async Task<Restaurant> GetRestaurantAsync(int restaurantId)
        {
            try
            {
                return await restaurantHandler.GetRestaurant(restaurantId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        

        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            try
            {
                return await restaurantHandler.AddRestaurant(restaurant);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task RemoveRestaurantAsync(int restaurantID)
        {
            try
            {
                await restaurantHandler.RemoveRestaurant(restaurantID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant, int restaurantId)
        {
            try
            {
                return await restaurantHandler.UpdateRestaurant(restaurant , restaurantId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Restaurant> ValidateLoginAsync(string username)
        {
            return await restaurantHandler.ValidateLogin(username);
        }
    }
}