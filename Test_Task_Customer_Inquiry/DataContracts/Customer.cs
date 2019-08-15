using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Task_Customer_Inquiry.DataContracts
{
    public class Customer
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// This and Id property should have a String type, but due the requirements (both of them must be numeric) these properties is int.
        /// </summary>
        public int Mobile { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
