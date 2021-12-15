using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Service.CategoryService;
using Food4U_SEP3.Service.MenuService;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServiceT2 categoryService;

        public CategoryController(ICategoryServiceT2 categoryService) => this.categoryService = categoryService;

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategoryAsync([FromBody] Category category)
        {
            try
            {
                await categoryService.AddCategoryAsync(category);
                return Created($"/{category}", category);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Category>> GetCategoryAsync([FromQuery] int categoryId)
        {
            try
            {
                Category category = await categoryService.GetCategoryAsync(categoryId);
                return Ok(category);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/Categories")]
        public async Task<ActionResult<IList<Category>>> GetCategoryByMenuIdAsync([FromQuery] int menuId)
        {
            try
            {
                IList<Category> categories = await categoryService.GetCategoriesAsync(menuId);
                return Ok(categories);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        // [Route("{name:string}")]
        public async Task<ActionResult> UpdateCategoryAsync([FromBody] Category category)
        {
            try
            {
                await categoryService.UpdateCategoryAsync(category);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategoriesAsync([FromQuery] int categoryId)
        
        {
            try
            {
                await categoryService.DeleteCategoryAsync(categoryId);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}