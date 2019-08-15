using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Task_Customer_Inquiry.ViewModels
{
    public class CustomerViewModel
    {
        [MaxLength(10)]
        public int CustomerID { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [EmailAddress]
        [MaxLength(25)]
        public string Email { get; set; }

        [MaxLength(10)]
        public int Mobile { get; set; }

        public IEnumerable<TransactionViewModel> Transactions { get; set; }
    }
}
