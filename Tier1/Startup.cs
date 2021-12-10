using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Authentication;
using Client.Data.CategoryService;
using Client.Data.CustomerService;
using Client.Data.DriverService;
using Client.Data.ItemService;
using Client.Data.MenuService;
using Client.Data.OrderService;
using Client.Data.RestaurantService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Client.Data.UserServices;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<IUserServices, CloudUserServices>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddScoped<IRestaurantService, CloudRestaurantService>();
            services.AddScoped<ICustomerServiceT1, CloudCustomerServiceT1>();
            services.AddScoped<IMenuServiceT1, CloudMenuServiceT1>();
            services.AddScoped<ICategoryServiceT1,CloudCategoryServiceT1>();
            services.AddScoped<IItemServiceT1, CloudItemServiceT1>();
            services.AddScoped<IOrderServiceT1, CloudOrderServiceT1>();
            services.AddScoped<IDriverServiceT1, CloudDriverServiceT1>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}