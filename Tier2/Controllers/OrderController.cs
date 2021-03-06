using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Service.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceT2 orderService;

        public OrderController(IOrderServiceT2 orderService) => this.orderService = orderService;

        [HttpPost]
        public async Task<ActionResult<Order>> AddOrderAsync([FromBody] Order order)
        {
            try
            {
                await orderService.AddOrderAsync(order);
                return Created($"/{order}", order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOrderAsync([FromQuery] int orderId)
        {
            try
            {
                await orderService.DeleteOrderAsync(orderId);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/Orders/Incoming")]
        public async Task<ActionResult<IList<Order>>> GetIncomingOrdersAsync([FromQuery] string restaurantUsername)
        {
            try
            {
                IList<Order> order = await orderService.GetIncomingOrdersAsync(restaurantUsername);
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
                await orderService.UpdateOrderAsync(order);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/Orders/Accepted")]
        public async Task<ActionResult<IList<Order>>> GetAcceptedOrdersAsync([FromQuery] string restaurantUsername)
        {
            try
            {
                IList<Order> order = await orderService.GetAcceptedOrdersAsync(restaurantUsername);
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/Orders/Previous")]
        public async Task<ActionResult<IList<Order>>> GetPreviousOrdersAsync([FromQuery] string customerUsername)
        {
            try
            {
                IList<Order> order = await orderService.GetPreviousOrdersAsync(customerUsername);
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Order>> GetOrderAsync([FromQuery] int orderId)
        {
            try
            {
                Order order = await orderService.GetOrderAsync(orderId);
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/Orders/ReadyForPickup")]
        public async Task<ActionResult<IList<Order>>> GetReadyForPickupOrdersAsync()
        {
            try
            {
                IList<Order> order = await orderService.GetReadyForPickUpOrdersAsync();
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
