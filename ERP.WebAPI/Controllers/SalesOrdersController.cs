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
        public ActionResult<IEnumerable<SalesOrder>> Get()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }

        // GET: api/SalesOrders/5
        [HttpGet("get/{id}")]
        public ActionResult<SalesOrder?> Get(int id)
        {
            if (!_orderService.IsExist(id))
            {
                return NotFound();
            }

            return _orderService.GetById(id);
        }

        // POST: api/SalesOrders
        [HttpPost]
        public ActionResult<SalesOrder> Post(SalesOrder order)
        {
            var newOrder = _orderService.Create(order);
            return Ok(newOrder);
        }

        // PUT: api/SalesOrders/5
        [HttpPut("{id}")]
        public ActionResult<SalesOrder> Put(int id, SalesOrder order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            if (!_orderService.IsExist(id))
            {
                return NotFound();
            }

            _orderService.Update(order);
            return Ok(order);
        }

        // DELETE: api/SalesOrders/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            var isDeleted = _orderService.Remove(order);
            return Ok(isDeleted);
        }
    }
}