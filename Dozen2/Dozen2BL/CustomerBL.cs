using System;
using Dozen2DL;
using Dozen2Models;
using System.Collections.Generic;
using Dozen2BL;


/// <summary>
/// CustomerBL applies the business logic for the customers
/// </summary>

namespace DozenBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepository _repo;
        public CustomerBL(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public void AddCustomer(Customer newCustomer)
        {
            _repo.AddCustomer(newCustomer);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }
    }
}
