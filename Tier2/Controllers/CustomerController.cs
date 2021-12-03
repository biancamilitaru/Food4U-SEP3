﻿using System;
using System.Threading.Tasks;
using Client.Data.CustomerService;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Food4U_SEP3.Controllers
{
    [Route("[controller")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceT1 customerServiceT1;


        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomerAsync([FromBody] Customer customer)
        {
            try
            {
                await customerServiceT1.AddCustomerAsync(customer);
                return Created($"/{customer}", customer);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}