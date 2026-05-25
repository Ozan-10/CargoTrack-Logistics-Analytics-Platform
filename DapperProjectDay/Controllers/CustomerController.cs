using DapperProjectDay.Dtos;
using DapperProjectDay.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperProjectDay.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> CustomerList()
        {
            var values = await _customerService.GetAllCustomerAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            await _customerService.CreateCustomerAsync(createCustomerDto);
            return RedirectToAction("CustomerList");
        }
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCustomer (int id)
        {
            var value =await _customerService.GetCustomerByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            await _customerService.UpdateCustomerAsync(updateCustomerDto);
            return RedirectToAction("CustomerList");
        }
    }
}
