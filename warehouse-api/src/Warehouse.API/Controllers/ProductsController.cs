using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Entities.Models;
using Warehouse.Services;
using Warehouse.Services.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductService productService
            , ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        // GET: api/<ProductController>
        // get all the products (be aware of the performance)
        [HttpGet]
        public IEnumerable<ProductModel> GetProducts()
        {
            return _productService.GetProducts();
        }

        // GET api/<ProductController>/5
        // get a product by product Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // get all the product stock info
        [HttpGet("stocks")]
        public IEnumerable<ProductStock> GetProductStocks()
        {
            return _productService.GetAllProductStocks();
        }

        // get a product stock info
        [HttpGet("stocks/{id}")]
        public async Task<IActionResult> GetProductStockById(int id)
        {
            var productStock = await _productService.GetProductStokById(id);
            if(productStock == null) return NotFound();
            return Ok(productStock);
        }

        [HttpPost("sell")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SellProduct([FromBody] int id) {

            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();

            var productStock = await _productService.GetProductStokById(id);
            if(productStock == null || productStock.Stock == 0) return BadRequest();

            return Ok(await _productService.SellProduct(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ProductModel> AddProuct([FromBody] ProductModel productModel)
        {
            return await _productService.AddProduct(productModel);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductById(int id, [FromBody] ProductModel productModel)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();

            productModel.Id = id;
            return Ok(await _productService.UpdateProduct(productModel));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();

            return Ok(await _productService.DeleteProductById(id));
        }
    }
}
