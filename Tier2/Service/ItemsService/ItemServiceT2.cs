using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler.ItemHandler;

namespace Food4U_SEP3.Service.ItemsService
{
    public class ItemServiceT2 : IItemServiceT2
    {
        private readonly IItemHandlerT2 itemHandlerT2;

        public ItemServiceT2(IItemHandlerT2 itemHandler)
        {
            this.itemHandlerT2 = itemHandler;
        }

        public async Task<Item> AddItemAsync(Item item)
        {
            try
            {
                return await itemHandlerT2.AddItem(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<Item>> GetItemsAsync(int categoryId)
        {
            try
            {
                return await itemHandlerT2.GetItems(categoryId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Item> UpdateItemAsync(Item item)
        {
            try
            {
                return await itemHandlerT2.UpdateItem(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteItemAsync(int itemId)
        {
            try
            {
                await itemHandlerT2.DeleteItem(itemId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Item> GetItemAsync(int itemId)
        {
            try
            {
                return await itemHandlerT2.GetItem(itemId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}