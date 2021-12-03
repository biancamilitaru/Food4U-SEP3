﻿using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.SocketHandler.CustomerHandler
{
    public interface ICustomerHandlerT2
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> ValidateLogin(string username);
    }
}