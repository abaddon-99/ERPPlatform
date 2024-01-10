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
        private readonly Lazy<IPurchaseOrderService> _orderService;

        public PurchaseOrdersController(Lazy<IPurchaseOrderService> orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrder>> Get(int id)
        {
            var isExist = await _orderService.Value.IsExistAsync(id);
            if (!isExist)
            {
                return NotFound();
            }
            
            var order = await _orderService.Value.GetByIdAsync(id);
            if (order is null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseOrder>> Create(PurchaseOrder order)
        {
            var newOrder = await _orderService.Value.CreateAsync(order);
            return Ok(newOrder);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PurchaseOrder>> Update(int id, PurchaseOrder order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            var isExist = await _orderService.Value.IsExistAsync(id);
            if (!isExist)
            {
                return NotFound();
            }
            _orderService.Value.Update(order);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var order = await _orderService.Value.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _orderService.Value.Remove(order);
            return NoContent();
        }
    }
}
