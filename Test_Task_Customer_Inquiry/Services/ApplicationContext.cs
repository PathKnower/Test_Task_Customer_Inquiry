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
            Database.Migrate();
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var transactionsOfUsers = new Transaction[]
            {
                new Transaction { Id = 1, CustomerId = 1, Amount = 1234, Currency = "USD", Date = new DateTime(2018, 10, 20, 15, 35, 23), Status = TransactionStatus.Success},
                new Transaction { Id = 2, CustomerId = 1, Amount = 623, Currency = "USD", Date = new DateTime(2018, 10, 20, 15, 36, 23), Status = TransactionStatus.Cancelled},
                new Transaction { Id = 3, CustomerId = 1, Amount = 5456, Currency = "RU", Date = new DateTime(2018, 10, 20, 15, 37, 23), Status = TransactionStatus.Success},
                new Transaction { Id = 4, CustomerId = 1, Amount = 1524, Currency = "EUR", Date = new DateTime(2018, 10, 20, 15, 38, 23), Status = TransactionStatus.Failed},
                new Transaction { Id = 5, CustomerId = 2, Amount = 1234, Currency = "USD", Date = new DateTime(2018, 10, 11, 17, 39, 27), Status = TransactionStatus.Success}
            };

            modelBuilder.Entity<Transaction>().HasData(transactionsOfUsers);

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Email = "sample@email.com", Mobile = 46843214, Name = "Temp Customer"},
                new Customer { Id = 2, Email = "anothersample@email.com", Mobile = 125124, Name = "Firstname Lastname"},
                new Customer { Id = 3, Email = "somemail@mail.com", Mobile = 684321, Name = "Some Customer"});
        }
    }
}
