using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test_Task_Customer_Inquiry.DataContracts;

namespace Test_Task_Customer_Inquiry.Services
{
    interface ICustomerRepository : IDisposable 
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int Id);
        Customer GetCustomer(Expression<Func<Customer, bool>> condition);
        void AddCustomer(Customer customer);
        void DeleteCustomer(int Id);
        void UpdateCustomer(Customer customer);
        void Save();
    }
}
