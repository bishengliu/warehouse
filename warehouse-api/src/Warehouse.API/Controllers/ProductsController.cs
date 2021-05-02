using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Warehouse.Entities.Models;
using Warehouse.Services;
using Warehouse.Services.DTO;


namespace Warehouse.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;
        private readonly IUploadService _uploadService;

        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true
        };
        public ProductsController(IProductService productService
            , ILogger<ProductsController> logger
            , IUploadService uploadService)
        {
            _productService = productService;
            _logger = logger;
            _uploadService = uploadService;
        }

        /// <summary>
        /// Get all the products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProductModel> GetProducts()
        {
            return _productService.GetProducts();
        }

        // GET api/<ProductController>/5
        // get a product by product Id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

            await _productService.SellProduct(id);
            return Ok();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ProductModel> AddProuct([FromBody] ProductModel productModel)
        {
            return await _productService.AddProduct(productModel);
        }

        [HttpPost("upload")]
        public async Task<IEnumerable<ProductModel>> UploadProducts(IFormFile file)
        {
            var data = await _uploadService.ReadFileContent(file);
            var productsUpload = JsonSerializer.Deserialize<ProductUploadModel>(data, JsonSerializerOptions);
            var products = _uploadService.MapProducts(productsUpload);
            await _productService.AddProducts(products);
            return products;
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProductById(int id, [FromBody] ProductModel productModel)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();

            productModel.Id = id;
            return Ok(await _productService.UpdateProduct(productModel));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();

            return Ok(await _productService.DeleteProductById(id));
        }
    }
}
