using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Test_Task_Customer_Inquiry.Services;
using Test_Task_Customer_Inquiry.ViewModels;

namespace Test_Task_Customer_Inquiry.Controllers
{
    [Route("api/[controller]")]
    public sealed class InquiryController : Controller
    {
        private readonly IInquiryService _inquiryService;

        public InquiryController(IInquiryService inquiryService)
        {
            _inquiryService = inquiryService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            InquiryViewModel model = new InquiryViewModel
            {
                Email = string.Empty,
                CustomerID = id
            };

            if (id < 0 || id > 1000000000)
            {
                ModelState.AddModelError("id", "\'id\' Cannot be less than 0 and more than 1000000000");
                return BadRequest(ModelState);
            }

            var result = _inquiryService.GetCustomer(id);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            InquiryViewModel model = new InquiryViewModel
            {
                Email = email,
                CustomerID = -1
            };

            TryValidateModel(model);
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("Email", "\'email\' is not valid");
                return BadRequest(ModelState);
            }

            var result = _inquiryService.GetCustomer(email);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromForm]InquiryViewModel model)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(model.Email))
            {
                return BadRequest();
            }

            var result = _inquiryService.GetCustomer(model.CustomerID, model.Email);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

    }
}
