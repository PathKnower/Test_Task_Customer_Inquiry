using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Test_Task_Customer_Inquiry.DataContracts;

namespace Test_Task_Customer_Inquiry.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Status { get; set; }

        public TransactionViewModel(Transaction transaction)
        {
            Id = transaction.Id;
            Date = transaction.Date;
            Amount = transaction.Amount;
            Currency = transaction.Currency;
            Status = transaction.Status.ToString();
        }
    }
}
