using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Warehouse.Entities.Models;
using Warehouse.Services;
using Warehouse.Services.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly ILogger<InventoryController> _logger;
        private readonly IUploadService _uploadService;

        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true
        };
        public InventoryController(IInventoryService inventoryService
            , ILogger<InventoryController> logger
            , IUploadService uploadService)
        {
            _inventoryService = inventoryService;
            _logger = logger;
            _uploadService = uploadService;
        }
        // GET: api/<InventoryController>
        [HttpGet]
        public IEnumerable<Article> GetArticles() => _inventoryService.GetArticles();

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public async Task<Article> GetArticleById(int id) => await _inventoryService.GetArticleById(id);


        // POST api/<InventoryController>
        [HttpPost]
        public async Task<Article> AddArticle([FromBody] Article article)
        {
            return await _inventoryService.AddArticle(article);
        }

        [HttpPost("upload")]
        public async Task<IEnumerable<Article>> Uploadrticles(IFormFile file)
        {
            var data = await _uploadService.ReadFileContent(file);
            var articlesUpload = JsonSerializer.Deserialize<ArticleUploadModel>(data, JsonSerializerOptions);
            var articles = _uploadService.MapArticles(articlesUpload);
            await _inventoryService.AddArticles(articles);
            return articles;

        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] Article art)
        {
            var article = await _inventoryService.GetArticleById(id);
            if (article == null) return BadRequest();
            art.Id = article.Id;

            return Ok(await _inventoryService.UpadteArticle(art));
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleById(int id)
        {
            var article = await _inventoryService.GetArticleById(id);
            if (article == null) return BadRequest();

            return Ok(await _inventoryService.DeleteArticleById(id));
        }
    }
}
