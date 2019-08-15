using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Task_Customer_Inquiry.ViewModels
{
    public class InquiryViewModel
    {
        [Range(0, 1000000000)]
        public int CustomerID { get; set; } = -1;

        [EmailAddress]
        [StringLength(25, MinimumLength = 3)]
        public string Email { get; set; }
    }
}
