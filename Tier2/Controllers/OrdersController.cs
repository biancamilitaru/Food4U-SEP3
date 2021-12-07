using System;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServiceT2 orderService;
        
        public OrdersController(IOrderServiceT2 orderService) => this.orderService = orderService;
        
        [HttpPost]
        public async Task<ActionResult<Order>> AddOrderAsync([FromBody] Order order)
        {
            try
            {
                await orderService.AddOrderAsync(order);
                return Created($"/{order}", order);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}