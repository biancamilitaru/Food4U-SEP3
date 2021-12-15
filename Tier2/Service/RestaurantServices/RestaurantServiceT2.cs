using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Service.DeliveryService;
using Food4U_SEP3.SocketHandler;
using Food4U_SEP3.SocketHandler.DeliveryHandler;
using Food4U_SEP3.SocketHandler.ItemHandler;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.RestaurantServices
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantHandlerT2 restaurantHandlerT2;
        private readonly IDeliveryHandlerT2 deliveryHandlerT2;
        private readonly IMenuHandlerT2 menuHandlerT2;
        private readonly ICategoryHandlerT2 categoryHandlerT2;
        private readonly IItemHandlerT2 itemHandlerT2;

        public RestaurantService(HandlerFactory handlerFactory)
        {
            restaurantHandlerT2 = handlerFactory.GetRestaurantHandlerT2();
            deliveryHandlerT2 = handlerFactory.GetDeliveryHandlerT2();
            menuHandlerT2 = handlerFactory.GetMenuHandlerT2();
            categoryHandlerT2 = handlerFactory.GetCategoryHandlerT2();
            itemHandlerT2 = handlerFactory.GetItemHandlerT2();
        }

        public async Task<Restaurant> GetRestaurantAsync(string username)
        {
            try
            {
                Restaurant restaurant = await restaurantHandlerT2.GetRestaurant(username);
                IList<Delivery> deliveries = await deliveryHandlerT2.GetDeliveryOptionsByUsername(username);
                Menu menu = await menuHandlerT2.GetMenuByRestaurant(username);
                IList<Category> categories = await categoryHandlerT2.GetCategories(menu.MenuId);
                
                foreach (Category category in categories)
                {
                    IList<Item> items = await itemHandlerT2.GetItems(category.CategoryId);
                    category.Items = items;
                }

                menu.Categories = categories;
                restaurant.DeliveryOption1 = deliveries[0];
                restaurant.DeliveryOption2 = deliveries[2];
                restaurant.Menu = menu;
                return restaurant;
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
                Restaurant restaurantAdded = await restaurantHandlerT2.AddRestaurant(restaurant);
                if (restaurant.Menu != null)
                {
                    await menuHandlerT2.AddMenu(restaurant.Menu);
                    if (restaurant.Menu.Categories.Count > 0)
                    {
                        foreach (Category category in restaurant.Menu.Categories)
                        {
                            await categoryHandlerT2.AddCategory(category);
                            if (category.Items.Count > 0)
                            {
                                foreach (Item item in category.Items)
                                {
                                    await itemHandlerT2.AddItem(item);
                                }
                            }
                        }
                    }
                }
                if (restaurant.DeliveryOption1 != null)
                    await deliveryHandlerT2.AddDeliveryOption(restaurant.DeliveryOption1);
                if (restaurant.DeliveryOption2 != null)
                    await deliveryHandlerT2.AddDeliveryOption(restaurant.DeliveryOption2);
                return restaurantAdded;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteRestaurantAsync(string username)
        {
            try
            {
                await restaurantHandlerT2.DeleteRestaurant(username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant)
        {
            try
            {
                if (restaurant.Menu != null)
                {
                    await menuHandlerT2.UpdateMenu(restaurant.Menu);
                    if (restaurant.Menu.Categories.Count > 0)
                    {
                        foreach (Category category in restaurant.Menu.Categories)
                        {
                            await categoryHandlerT2.UpdateCategory(category);
                            if (category.Items.Count > 0)
                            {
                                foreach (Item item in category.Items)
                                {
                                    await itemHandlerT2.UpdateItem(item);
                                }
                            }
                        }
                    }
                }
                if (restaurant.DeliveryOption1 != null)
                    await deliveryHandlerT2.UpdateDeliveryOption(restaurant.DeliveryOption1);
                if (restaurant.DeliveryOption2 != null)
                    await deliveryHandlerT2.UpdateDeliveryOption(restaurant.DeliveryOption2);
                return await restaurantHandlerT2.UpdateRestaurant(restaurant);
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

        public async Task<IList<Restaurant>> GetRestaurantsAsync()
        {
            try
            {
                IList<Restaurant> restaurants = await restaurantHandlerT2.GetRestaurants();
                foreach (Restaurant restaurant in restaurants)
                {
                    IList<Delivery> deliveries = await deliveryHandlerT2.GetDeliveryOptionsByUsername(restaurant.Username);
                    Menu menu = await menuHandlerT2.GetMenuByRestaurant(restaurant.Username);
                    IList<Category> categories = await categoryHandlerT2.GetCategories(menu.MenuId);
                
                    foreach (Category category in categories)
                    {
                        IList<Item> items = await itemHandlerT2.GetItems(category.CategoryId);
                        category.Items = items;
                    }

                    menu.Categories = categories;
                    restaurant.DeliveryOption1 = deliveries[0];
                    restaurant.DeliveryOption2 = deliveries[2];
                    restaurant.Menu = menu;
                }
                return restaurants;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}