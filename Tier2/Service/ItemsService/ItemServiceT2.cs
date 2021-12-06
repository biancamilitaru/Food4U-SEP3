using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.SocketHandler.ItemHandler;

namespace Food4U_SEP3.Service.ItemsService
{
    public class ItemServiceT2 : IItemServiceT2
    {
        
        private readonly IItemHandlerT2 itemHandler;

        public ItemServiceT2(IItemHandlerT2 itemHandler)
        {
            this.itemHandler = itemHandler;
        }
        
        public async Task<Item> AddItemAsync(Item item)
        {
            try
            {
                return await itemHandler.AddItem(item);
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
                return await itemHandler.UpdateItem(item);
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
                await itemHandler.DeleteItem(itemId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
    }
}