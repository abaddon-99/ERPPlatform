using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrdersController : ControllerBase
    {
        private readonly ISalesOrderService _orderService;

        public SalesOrdersController(ISalesOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/SalesOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrder>>> Get()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        // GET: api/SalesOrders/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<SalesOrder>> Get(int id)
        {
            var isExist = await _orderService.IsExistAsync(id);
            if (!isExist)
            {
                return NotFound();
            }

            var order = await _orderService.GetByIdAsync(id);
            if (order is null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/SalesOrders
        [HttpPost]
        public async Task<ActionResult<SalesOrder>> Post(SalesOrder order)
        {
            var newOrder = await _orderService.CreateAsync(order);
            return Ok(newOrder);
        }

        // PUT: api/SalesOrders/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SalesOrder>> Put(int id, SalesOrder order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            var isExist = await _orderService.IsExistAsync(id);
            if (!isExist)
            {
                return NotFound();
            }

            _orderService.Update(order);
            return Ok(order);
        }

        // DELETE: api/SalesOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _orderService.Remove(order);
            return NoContent();
        }
    }
}