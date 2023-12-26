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
        public ActionResult<IEnumerable<PurchaseOrder>> Get()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }

        // GET: api/PurchaseOrders/5
        [HttpGet("get/{id}")]
        public ActionResult<PurchaseOrder> Get(int id)
        {
            if (!_orderService.IsExist(id))
            {
                return NotFound();
            }
            return _orderService.GetById(id);
        }

        // POST: api/PurchaseOrders
        [HttpPost]
        public ActionResult<PurchaseOrder> Post(PurchaseOrder order)
        {
            var newOrder = _orderService.Create(order);
            return Ok(newOrder);
        }

        // PUT: api/PurchaseOrders/5
        [HttpPut("{id}")]
        public ActionResult<PurchaseOrder> Put(int id, PurchaseOrder order)
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

        // DELETE: api/PurchaseOrders/5
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
