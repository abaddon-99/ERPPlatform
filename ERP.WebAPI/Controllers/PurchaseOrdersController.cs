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
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IPurchaseOrderService _orderService;

        public PurchaseOrdersController(IPurchaseOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/PurchaseOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrder>>> Get()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        // GET: api/PurchaseOrders/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<PurchaseOrder>> Get(int id)
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

        // POST: api/PurchaseOrders
        [HttpPost]
        public async Task<ActionResult<PurchaseOrder>> Post(PurchaseOrder order)
        {
            var newOrder = await _orderService.CreateAsync(order);
            return Ok(newOrder);
        }

        // PUT: api/PurchaseOrders/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PurchaseOrder>> Put(int id, PurchaseOrder order)
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

        // DELETE: api/PurchaseOrders/5
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
