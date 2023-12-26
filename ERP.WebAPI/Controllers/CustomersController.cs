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
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(_customerService.GetAll());
        }

        // GET: api/Customers/5
        [HttpGet("get/{id}")]
        public ActionResult<Customer> Get(int id)
        {
            if (!_customerService.IsExist(id))
            {
                return NotFound();
            }
            return _customerService.GetById(id);
        }

        // POST: api/Customers
        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            return Ok(_customerService.Create(customer));
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            if (!_customerService.IsExist(id))
            {
                return NotFound();
            }
            _customerService.Update(customer);
            return Ok(customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            var isDeleted = _customerService.Remove(customer);
            return Ok(isDeleted);
        }
    }
}
