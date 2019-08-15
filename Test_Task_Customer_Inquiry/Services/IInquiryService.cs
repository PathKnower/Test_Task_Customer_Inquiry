using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Task_Customer_Inquiry.ViewModels;

namespace Test_Task_Customer_Inquiry.Services
{
    public interface IInquiryService
    {
        CustomerViewModel GetCustomer(int Id);
        CustomerViewModel GetCustomer(string email);
        CustomerViewModel GetCustomer(int Id, string email);
    }
}
