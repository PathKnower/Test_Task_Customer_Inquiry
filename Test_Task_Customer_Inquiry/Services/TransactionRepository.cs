using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Test_Task_Customer_Inquiry.DataContracts;

namespace Test_Task_Customer_Inquiry.Services
{
    public sealed class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationContext _context; 

        public TransactionRepository(ApplicationContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public Transaction GetTransaction(int Id)
        {
            return _context.Transactions.Find(Id);
        }

        public Transaction GetTransaction(Expression<Func<Transaction, bool>> condition)
        {
            return _context.Transactions.FirstOrDefault(condition);
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _context.Transactions.ToArray();
        }


        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
        }

        public void DeleteTransaction(int Id)
        {
            _context.Transactions.Remove(_context.Transactions.Find(Id));
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