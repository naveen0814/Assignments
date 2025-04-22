using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.entity;

namespace TechShop.dao
{
    public interface ICustomerRepository
    {
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int customerId);
        Customer GetCustomerById(int customerId);
        List<Customer> GetAllCustomers();
    }
}