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
        private readonly Lazy<ISalesOrderService> _orderService;

        public SalesOrdersController(Lazy<ISalesOrderService> orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesOrder>> Get(int id)
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
        public async Task<ActionResult<SalesOrder>> Create(SalesOrder order)
        {
            var newOrder = await _orderService.Value.CreateAsync(order);
            return Ok(newOrder);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SalesOrder>> Update(int id, SalesOrder order)
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