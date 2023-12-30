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
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return Ok(await _customerService.GetAllAsync());
        }

        // GET: api/Customers/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var idIsExist = await _customerService.IsExistAsync(id);
            if (!idIsExist)
            {
                return NotFound();
            }
            var customer = await _customerService.GetByIdAsync(id);
            if (customer is null)
            {
                return NotFound();
            }

            return customer;
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            return Ok(await _customerService.CreateAsync(customer));
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Put(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            var idIsExist = await _customerService.IsExistAsync(id);
            if (!idIsExist)
            {
                return NotFound();
            }
            _customerService.Update(customer);
            return Ok(customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerService.Remove(customer);
            return NoContent();
        }
    }
}
