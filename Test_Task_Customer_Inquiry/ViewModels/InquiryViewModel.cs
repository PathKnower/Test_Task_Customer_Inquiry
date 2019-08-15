using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Task_Customer_Inquiry.ViewModels
{
    public class InquiryViewModel
    {
        /// <summary>
        /// Customer ID for searching
        /// </summary>
        [Range(1, 1000000000)]
        public int CustomerID { get; set; }


        /// <summary>
        /// Customer Email for searching
        /// </summary>
        [EmailAddress]
        [StringLength(25, MinimumLength = 3)]
        public string Email { get; set; }
    }
}
