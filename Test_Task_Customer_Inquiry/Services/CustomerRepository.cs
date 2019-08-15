using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Test_Task_Customer_Inquiry.DataContracts;

namespace Test_Task_Customer_Inquiry.Services
{
    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;

        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToArray();
        }

        public Customer GetCustomer(int Id)
        {
            return _context.Customers.Find(Id);
        }

        public Customer GetCustomer(Expression<Func<Customer, bool>> condition)
        {
            return _context.Customers.FirstOrDefault(condition);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void DeleteCustomer(int Id)
        {
            _context.Customers.Remove(_context.Customers.Find(Id));
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed;

        public void Dispose()
        {
            if(!this.disposed)
            {
                _context.Dispose();
                this.disposed = true;
            }
        }
    }
}
