using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Data.CustomerService;
using Client.Data.DriverService;
using Client.Data.RestaurantService;
using Client.Data.UserServices;
using Entities;
using Food4U_SEP3.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace Client.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        
        private readonly ICustomerServiceT1 customerService;
        private readonly IRestaurantService restaurantService;
        private readonly IDriverServiceT1 driverService;
        
        private Restaurant cachedRestaurant;
        private Customer cachedCustomer;
        private Driver cachedDriver;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IRestaurantService restaurantService, ICustomerServiceT1 customerService, IDriverServiceT1 driverService)
        {
            this.jsRuntime = jsRuntime;
            this.restaurantService = restaurantService;
            this.customerService = customerService;
            this.driverService = driverService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            
            //RESTAURANT
            if (cachedRestaurant == null)
            {
                string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentRestaurant");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    cachedRestaurant = JsonSerializer.Deserialize<Restaurant>(userAsJson);
                    identity = SetupClaimsForRestaurant(cachedRestaurant);
                }
            }
            else
            {
                identity = SetupClaimsForRestaurant(cachedRestaurant);
            }
            

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(string username, string password, string userType)
        {
            Console.WriteLine("Validating log in");
            if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
            ClaimsIdentity identity = new ClaimsIdentity();

            //RESTAURANT
            if (userType.Equals("Restaurant"))
            {
                try
                {
                    Restaurant user = await restaurantService.ValidateRestaurantAsync(username, password);
                    if (user.Name!=null)
                    {
                        identity = SetupClaimsForRestaurant(user);
                        string serialisedData = JsonSerializer.Serialize(user);
                        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentRestaurant", serialisedData);
                        cachedRestaurant = user;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            
            //CUSTOMER
            if (userType.Equals("Customer"))
            {
                try
                {
                    Customer customer = await customerService.ValidateCustomerAsync(username, password);
                    if (customer.Username!=null)
                    {
                        identity = SetupClaimsForCustomer(customer);
                        string serialisedData = JsonSerializer.Serialize(customer);
                        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentCustomer", serialisedData);
                        cachedCustomer = customer;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            
            //Driver
            if (userType.Equals("Driver"))
            {
                try
                {
                    Driver driver = new Driver(); //await driverService.ValidateDriverAsync(username, password);
                    if (driver.Username!=null)
                    {
                        identity = SetupClaimsForDriver(driver);
                        string serialisedData = JsonSerializer.Serialize(driver);
                        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentDriver", serialisedData);
                        cachedDriver = driver;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public async Task Logout()
        {
            cachedCustomer = null;
            cachedRestaurant = null;
            cachedDriver = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentRestaurant", "");
            await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentCustomer", "");
            await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentDriver", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity SetupClaimsForRestaurant(Restaurant user)
        {
            List<Claim> claims = new List<Claim>();
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
        
        private ClaimsIdentity SetupClaimsForCustomer(Customer user)
        {
            List<Claim> claims = new List<Claim>();
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
        
        private ClaimsIdentity SetupClaimsForDriver(Driver driver)
        {
            List<Claim> claims = new List<Claim>();
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}