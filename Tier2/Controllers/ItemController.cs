using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Service.CategoryService;
using Food4U_SEP3.Service.ItemsService;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    //TODO GetItem by itemID
    
    [Route("[controller]")]
    [ApiController]
    
    public class ItemController : ControllerBase
    {
        private readonly IItemServiceT2 itemService;

        public ItemController(IItemServiceT2 itemService) => this.itemService = itemService;
        
        
        [HttpPost]
        public async Task<ActionResult<Item>> AddItemAsync([FromBody] Item item)
        {
            try
            {
                await itemService.AddItemAsync(item);
                return Created($"/{item}", item);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("/Items")]
        public async Task<ActionResult<IList<Item>>> GetCategoryByMenuIdAsync([FromQuery] int categoryId)
        {
            try
            {
                IList<Item> items = await itemService.GetItemsAsync(categoryId);
                return Ok(items);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        [Route("{itemID:int}")]
        public async Task<ActionResult> UpdateItemAsync([FromBody] Item item)
        {
            try
            {
                await itemService.UpdateItemAsync(item);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItemAsync([FromQuery] int itemId)
        {
            try
            {
               await itemService.DeleteItemAsync(itemId);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}