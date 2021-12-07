using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Service.OrderService;
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
        
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetIncomingOrders([FromQuery] string restaurantUsername)
        {
            try
            {
                List<Order> order = await orderService.GetIncomingOrdersAsync(restaurantUsername);
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateOrderAsync([FromBody] Order order)
        {
            try
            {
                //await orderService.UpdateOrderAsync(order);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}