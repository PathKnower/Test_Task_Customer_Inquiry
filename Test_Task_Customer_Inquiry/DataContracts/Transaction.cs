using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Test_Task_Customer_Inquiry.DataContracts
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public TransactionStatus Status { get; set; }
    }

    public enum TransactionStatus
    {
        Success,
        Failed,
        Cancelled
    }
}
