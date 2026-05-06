using Microsoft.AspNetCore.Mvc;
using CustomersCRUD.Data;
using CustomersCRUD.Models;
using CustomersCRUD.Repositories;

namespace CustomersCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersRepository _customersRepository;

        public CustomersController(CustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customersRepository.GetAll();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customersRepository.GetById(id);
            if (customer == null) 
            return NotFound();
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            customer.CreatedOn = DateTime.UtcNow;
            var result = await _customersRepository.AddAsync(customer);
            
            return Ok(result);    
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id, Customer customer)
        {
            var Update = await _customersRepository.UpdateAsync(id, customer);   
            if (!Update) 
            return NotFound();
             return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Delete = await _customersRepository.Delete(id);
            if (!Delete)            
            return NotFound();
            return NoContent();    
        }
    }
}