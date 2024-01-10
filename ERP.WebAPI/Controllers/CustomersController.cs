using ERP.Application.Interfaces;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Orders;
using Microsoft.AspNetCore.Mvc;

namespace ERP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Lazy<ICustomerService> _customerService;

        public CustomersController(Lazy<ICustomerService> customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var idIsExist = await _customerService.Value.IsExistAsync(id);
            if (!idIsExist)
            {
                return NotFound();
            }
            var customer = await _customerService.Value.GetByIdAsync(id);
            if (customer is null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create(Customer customer)
        {
            return Ok(await _customerService.Value.CreateAsync(customer));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Update(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            var idIsExist = await _customerService.Value.IsExistAsync(id);
            if (!idIsExist)
            {
                return NotFound();
            }
            
            return Ok(_customerService.Value.Update(customer));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _customerService.Value.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerService.Value.Remove(customer);
            return NoContent();
        }
    }
}
