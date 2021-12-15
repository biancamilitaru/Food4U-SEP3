using Food4U_SEP3.RestaurantServices;
using Food4U_SEP3.Service;
using Food4U_SEP3.Service.CategoryService;
using Food4U_SEP3.Service.CustomerService;
using Food4U_SEP3.Service.DeliveryService;
using Food4U_SEP3.Service.DriverService;
using Food4U_SEP3.Service.ItemsService;
using Food4U_SEP3.SocketHandler;
using Food4U_SEP3.Service.MenuService;
using Food4U_SEP3.Service.OrderService;
using Food4U_SEP3.SocketHandler.CustomerHandler;
using Food4U_SEP3.SocketHandler.DeliveryHandler;
using Food4U_SEP3.SocketHandler.DriverHandler;
using Food4U_SEP3.SocketHandler.ItemHandler;
using Food4U_SEP3.SocketHandler.OrderHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace Food4U_SEP3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Food4U_SEP3", Version = "v1"});
            });
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IMenuServiceT2, MenuServiceT2>();
            services.AddScoped<IRestaurantHandlerT2, RestaurantSocketHandlerT2>();
            services.AddScoped<IMenuServiceT2, MenuServiceT2>();
            services.AddScoped<IMenuHandlerT2, MenuSocketHandlerT2>();
            services.AddScoped<ICustomerHandlerT2, CustomerSocketHandlerT2>();
            services.AddScoped<ICustomerServiceT2, CustomerServiceT2>();
            services.AddScoped<ICategoryHandlerT2, CategorySocketHandlerT2>();
            services.AddScoped<ICategoryServiceT2, CategoryServiceT2>();
            services.AddScoped<IOrderServiceT2, OrderServiceT2>();
            services.AddScoped<IOrderHandlerT2, OrderSocketHandlerT2>();
            services.AddScoped<IItemServiceT2, ItemServiceT2>();
            services.AddScoped<IItemHandlerT2, ItemSocketHandlerT2>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IDriverHandlerT2, DriverSocketHandlerT2>();
            services.AddScoped<IDriverServiceT2, DriverServiceT2>();
            services.AddScoped<IDeliveryHandlerT2, DeliverySocketHandlerT2>();
            services.AddScoped<IDeliveryServiceT2, DeliveryServiceT2>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Food4U_SEP3 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}