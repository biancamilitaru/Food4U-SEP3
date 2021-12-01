using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Service.CategoryService;
using Food4U_SEP3.Service.ItemsService;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    
    public class ItemsController : ControllerBase
    {
        private readonly IItemServiceT2 itemService;

        public ItemsController(IItemServiceT2 itemService) => this.itemService = itemService;
        
        
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
    }
}