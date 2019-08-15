using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Task_Customer_Inquiry.DataContracts;
using Test_Task_Customer_Inquiry.ViewModels;

namespace Test_Task_Customer_Inquiry.Services
{
    internal sealed class InquiryService : IInquiryService
    {
        private readonly ICustomerRepository _customerRepository;

        public InquiryService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerViewModel GetCustomer(int Id)
        {
            Customer customer = _customerRepository.GetCustomer(Id);
            return customer == null ? null : PrepareModel(customer);
        }

        public CustomerViewModel GetCustomer(string email)
        {
            Customer customer = _customerRepository.GetCustomer(x => x.Email == email);
            return customer == null ? null : PrepareModel(customer);
        }

        public CustomerViewModel GetCustomer(int Id, string email)
        {
            Customer customer = _customerRepository.GetCustomer(x => x.Id == Id && x.Email == email);
            return customer == null ? null : PrepareModel(customer);
        }

        private CustomerViewModel PrepareModel(Customer customer)
        {
            CustomerViewModel result = new CustomerViewModel
            {
                CustomerID = customer.Id,
                Email = customer.Email,
                Mobile = customer.Mobile,
                Name = customer.Name
            };

            if(customer.Transactions.Count() > 0)
            {
                List<TransactionViewModel> list = new List<TransactionViewModel>();
                foreach (var transaction in customer.Transactions)
                    list.Add(new TransactionViewModel(transaction));

                result.Transactions = list;
            }

            return result;
        }
    }
}
