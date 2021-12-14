using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Service.DeliveryService;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers

{
    [Route("[controller]")]
    [ApiController]
    
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryServiceT2 deliveryServiceT2;
        
        public DeliveryController(IDeliveryServiceT2 deliveryServiceT2) => this.deliveryServiceT2 = deliveryServiceT2;
        
        [HttpGet]
        public async Task<ActionResult<Delivery>> GetDeliveryAsync([FromQuery] int deliveryId)
        {
            try
            {
                Delivery delivery = await deliveryServiceT2.GetDeliveryAsync(deliveryId);
                return Ok(delivery);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
    
    
    
}