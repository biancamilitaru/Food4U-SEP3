using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Service.MenuService;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class MenusController : ControllerBase
    {
        private readonly IMenuServiceT2 menuService;

        public MenusController(IMenuServiceT2 menuService) => this.menuService = menuService;
        
        [HttpPost]
        public async Task<ActionResult<Menu>> AddMenuAsync([FromBody] Menu menu)
        {
            try
            {
                await menuService.AddMenuAsync(menu);
                return Created($"/{menu}", menu);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPatch]
        [Route("{menuID:int}")]
        public async Task<ActionResult> UpdatemenuAsync([FromBody] Menu menu, int menuId)
        {
            try
            {
                await menuService.UpdateMenuAsync(menu, menuId);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        

    }
}