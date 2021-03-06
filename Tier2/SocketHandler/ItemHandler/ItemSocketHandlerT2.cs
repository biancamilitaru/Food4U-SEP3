using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.ItemHandler
{
    public class ItemSocketHandlerT2 : SocketHandler, IItemHandlerT2
    {
        public Task<Item> AddItem(Item item)
        {
            string serializedItem = JsonSerializer.Serialize(item);
            SendToServer("AddItem", serializedItem);
            return Task.FromResult(item);
        }

        public Task<IList<Item>> GetItems(int categoryId)
        {
            SendToServer("GetItems", categoryId.ToString());
            IList<Item> items = JsonSerializer.Deserialize<IList<Item>>(GetFromServer());
            return Task.FromResult(items);
        }

        public Task<Item> UpdateItem(Item item)
        {
            string serialisedItem = JsonSerializer.Serialize(item);
            SendToServer("UpdateItem", serialisedItem);
            return Task.FromResult(item);
        }

        public Task<Item> DeleteItem(int itemId)
        {
            SendToServer("DeleteItem", itemId.ToString());
            Item deleteItem = JsonSerializer.Deserialize<Item>(GetFromServer());
            return Task.FromResult(deleteItem);
        }

        public Task<Item> GetItem(int itemId)
        {
            SendToServer("GetItem", itemId.ToString());
            Item getItem = JsonSerializer.Deserialize<Item>(GetFromServer());
            return Task.FromResult(getItem);
        }

        public Task<Order> OrderItems(Order order)
        {
            string serializedOrder = JsonSerializer.Serialize(order);
            SendToServer("OrderItems", serializedOrder);
            return Task.FromResult(order);
        }

        public Task<IList<Item>> GetOrderedItems(int orderId)
        {
            SendToServer("GetOrderedItems", orderId.ToString());
            IList<Item> items = JsonSerializer.Deserialize<IList<Item>>(GetFromServer());
            return Task.FromResult(items);
        }
    }
}