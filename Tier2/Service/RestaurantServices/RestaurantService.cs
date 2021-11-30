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
        private readonly IRestaurantHandlerT2 restaurantHandlerT2;
        
        public RestaurantService(IRestaurantHandlerT2 restaurantHandlerT2)
        {
            this.restaurantHandlerT2 = restaurantHandlerT2;
        }

        public async Task<Restaurant> GetRestaurantAsync(int restaurantId)
        {
            try
            {
                return await restaurantHandlerT2.GetRestaurant(restaurantId);
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
                return await restaurantHandlerT2.AddRestaurant(restaurant);
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
                await restaurantHandlerT2.RemoveRestaurant(restaurantID);
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
                return await restaurantHandlerT2.UpdateRestaurant(restaurant , restaurantId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Restaurant> ValidateLoginAsync(string username)
        {
            return await restaurantHandlerT2.ValidateLogin(username);
        }
    }
}