using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Service.CategoryService;
using Food4U_SEP3.Service.MenuService;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServiceT2 categoryService;

        public CategoriesController(ICategoryServiceT2 categoryService) => this.categoryService = categoryService;

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategoryAsync([FromBody] Category category)
        {
            try
            {
                await categoryService.AddCategoryAsync(category);
                return Created($"/{category}", category);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPatch]
       // [Route("{name:string}")]
        public async Task<ActionResult> UpdateCategoryAsync([FromBody] Category category, int categoryid)
        {
            try
            {
                await categoryService.UpdateCategoryAsync(category, categoryid);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
       

    }
}