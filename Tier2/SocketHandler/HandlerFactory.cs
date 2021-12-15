using Food4U_SEP3.SocketHandler.CustomerHandler;
using Food4U_SEP3.SocketHandler.DeliveryHandler;
using Food4U_SEP3.SocketHandler.DriverHandler;
using Food4U_SEP3.SocketHandler.ItemHandler;
using Food4U_SEP3.SocketHandler.OrderHandler;

namespace Food4U_SEP3.SocketHandler
{
    public class HandlerFactory
    {
        private static HandlerFactory instance;
        private CategorySocketHandlerT2 categorySocketHandlerT2;
        private CustomerSocketHandlerT2 customerSocketHandlerT2;
        private DeliverySocketHandlerT2 deliverySocketHandlerT2;
        private DriverSocketHandlerT2 driverSocketHandlerT2;
        private ItemSocketHandlerT2 itemSocketHandlerT2;
        private MenuSocketHandlerT2 menuSocketHandlerT2;
        private OrderSocketHandlerT2 orderSocketHandlerT2;
        private RestaurantSocketHandlerT2 restaurantSocketHandlerT2;

        public static HandlerFactory GetInstance()
        {
            if (instance == null)
                instance = new HandlerFactory();
            return instance;
        }
        
        public HandlerFactory(){}

        public CategorySocketHandlerT2 GetCategoryHandlerT2()
        {
            if (categorySocketHandlerT2 == null)
                categorySocketHandlerT2 = new CategorySocketHandlerT2();
            return categorySocketHandlerT2;
        }

        public CustomerSocketHandlerT2 GetCustomerHandlerT2()
        {
            if (customerSocketHandlerT2 == null)
                customerSocketHandlerT2 = new CustomerSocketHandlerT2();
            return customerSocketHandlerT2;
        }

        public DeliverySocketHandlerT2 GetDeliveryHandlerT2()
        {
            if (deliverySocketHandlerT2 == null)
                deliverySocketHandlerT2 = new DeliverySocketHandlerT2();
            return deliverySocketHandlerT2;
        }

        public DriverSocketHandlerT2 GetDriverHandlerT2()
        {
            if (driverSocketHandlerT2 == null)
                driverSocketHandlerT2 = new DriverSocketHandlerT2();
            return driverSocketHandlerT2;
        }

        public ItemSocketHandlerT2 GetItemHandlerT2()
        {
            if (itemSocketHandlerT2 == null)
                itemSocketHandlerT2 = new ItemSocketHandlerT2();
            return itemSocketHandlerT2;
        }

        public MenuSocketHandlerT2 GetMenuHandlerT2()
        {
            if (menuSocketHandlerT2 == null)
                menuSocketHandlerT2 = new MenuSocketHandlerT2();
            return menuSocketHandlerT2;
        }

        public OrderSocketHandlerT2 GetOrderHandlerT2()
        {
            if (orderSocketHandlerT2 == null)
                orderSocketHandlerT2 = new OrderSocketHandlerT2();
            return orderSocketHandlerT2;
        }

        public RestaurantSocketHandlerT2 GetRestaurantHandlerT2()
        {
            if (restaurantSocketHandlerT2 == null)
                restaurantSocketHandlerT2 = new RestaurantSocketHandlerT2();
            return restaurantSocketHandlerT2;
        }
    }
}