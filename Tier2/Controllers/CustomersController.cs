using System;
using System.Threading.Tasks;
using Entities;
using Food4U_SEP3.Service.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServiceT2 customerService;

        public CustomersController(ICustomerServiceT2 customerService) => this.customerService = customerService;

        [HttpPost]
        public async Task<ActionResult<Customer>> AddRestaurantAsync([FromBody] Customer customer)
        {
            try
            {
                await customerService.AddCustomerAsync(customer);
                return Created($"/{customer}", customer);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}