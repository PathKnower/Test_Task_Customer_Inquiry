using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Task_Customer_Inquiry.DataContracts;

namespace Test_Task_Customer_Inquiry.Services
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext() : base()
        {
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }


    }
}
