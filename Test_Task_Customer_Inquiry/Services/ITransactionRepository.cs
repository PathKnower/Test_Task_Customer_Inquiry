using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Test_Task_Customer_Inquiry.DataContracts;

namespace Test_Task_Customer_Inquiry.Services
{
    interface ITransactionRepository : IDisposable 
    {
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransaction(int Id);
        Transaction GetTransaction(Expression<Func<Transaction, bool>> condition);
        void AddTransaction(Transaction transaction);
        void DeleteTransaction(int Id);
        void UpdateTransaction(Transaction transaction);
        void Save();
    }
}