using Dozen2Models;
using System.Collections.Generic;

namespace Dozen2BL
{
    public interface ICustomerBL
    {
         List <Customer> GetCustomers();
        void AddCustomer(Customer newCustomer);
    }
}