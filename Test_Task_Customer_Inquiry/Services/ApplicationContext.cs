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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var transactionOfUser1 = new Transaction[]
            {
                new Transaction { Id = 1, Amount = 1234, Currency = "USD", Date = new DateTime(2018, 10, 20, 15, 35, 23), Status = TransactionStatus.Success},
                new Transaction { Id = 2, Amount = 623, Currency = "USD", Date = new DateTime(2018, 10, 20, 15, 36, 23), Status = TransactionStatus.Cancelled},
                new Transaction { Id = 3, Amount = 5456, Currency = "RU", Date = new DateTime(2018, 10, 20, 15, 37, 23), Status = TransactionStatus.Success},
                new Transaction { Id = 4, Amount = 1524, Currency = "EUR", Date = new DateTime(2018, 10, 20, 15, 38, 23), Status = TransactionStatus.Failed}
            };

            var transactionOfUser2 = new Transaction[]
            {
                new Transaction { Id = 5, Amount = 1234, Currency = "USD", Date = new DateTime(2018, 10, 11, 17, 39, 27), Status = TransactionStatus.Success}
                //new Transaction { Id = 6, Amount = 1524, Currency = "EUR", Date = new DateTime(2018, 10, 27, 13, 35, 23), Status = TransactionStatus.Failed}
            };


            modelBuilder.Entity<Transaction>().HasData(transactionOfUser1, transactionOfUser2);


            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Email = "sample@email.com", Mobile = 46843214, Name = "Temp Customer", Transactions = transactionOfUser1},
                new Customer { Id = 2, Email = "anothersample@email.com", Mobile = 125124, Name = "Firstname Lastname", Transactions = transactionOfUser2},
                new Customer { Id = 3, Email = "somemail@mail.com", Mobile = 684321, Name = "Some Customer"});
        }
    }
}
