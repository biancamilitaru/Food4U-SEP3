﻿using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.CustomerService
{
    public interface ICustomerServiceT2
    {
        Task<Customer> AddCustomerAsync(Customer customer);
    }
}