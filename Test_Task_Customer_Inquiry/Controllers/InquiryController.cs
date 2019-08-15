using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        /// <summary>
        /// WARNING: Due the unknown reason for me, swagger provide invalid value to here (Postman was used for test). Main endpoint to get info about the Customer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns ></returns>
        [HttpGet]
        public IActionResult Get([FromForm]InquiryViewModel model)
        {
            var validationOfID = ModelState.GetFieldValidationState("CustomerID");
            var validationOfEmail = ModelState.GetFieldValidationState("Email");

            if(validationOfEmail != ModelValidationState.Valid && validationOfID != ModelValidationState.Valid)
                return BadRequest();

            CustomerViewModel result = null;

            if (validationOfID == ModelValidationState.Valid && validationOfEmail == ModelValidationState.Valid)
                result = _inquiryService.GetCustomer(model.CustomerID, model.Email);
            else if (validationOfEmail == ModelValidationState.Valid)
                result = _inquiryService.GetCustomer(model.Email);
            else if (validationOfID == ModelValidationState.Valid)
                result = _inquiryService.GetCustomer(model.CustomerID);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

    }
}
