using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Lazy<IProductService> _productService;

        public ProductsController(Lazy<IProductService> productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var isExist = await _productService.Value.IsExistAsync(id);
            if (!isExist)
            {
                return NotFound();
            }

            var product = await _productService.Value.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            return Ok(await _productService.Value.CreateAsync(product));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var idIsExist = await _productService.Value.IsExistAsync(id);
            if (!idIsExist)
            {
                return NotFound();
            }
            
            return Ok(_productService.Value.Update(product));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.Value.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.Value.Remove(product);
            return NoContent();
        }
    }
}
