﻿using Microsoft.AspNetCore.Http;
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
    [Produces("application/json")]
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
        
        /// <summary>
        /// get all the inventory articles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Article> GetArticles() => _inventoryService.GetArticles();

        
        /// <summary>
        /// get an article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Article> GetArticleById(int id) => await _inventoryService.GetArticleById(id);


        /// <summary>
        /// add a new article
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Article> AddArticle([FromBody] Article article)
        {
            return await _inventoryService.AddArticle(article);
        }

        /// <summary>
        /// upload the articles from a json file. 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("upload")]
        public async Task<IEnumerable<Article>> Uploadrticles(IFormFile file)
        {
            var data = await _uploadService.ReadFileContent(file);
            var articlesUpload = JsonSerializer.Deserialize<ArticleUploadModel>(data, JsonSerializerOptions);
            var articles = _uploadService.MapArticles(articlesUpload);
            await _inventoryService.AddArticles(articles);
            return articles;

        }

        /// <summary>
        /// update an article by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="art"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] Article art)
        {
            var article = await _inventoryService.GetArticleById(id);
            if (article == null) return BadRequest();
            art.Id = article.Id;

            return Ok(await _inventoryService.UpadteArticle(art));
        }


        /// <summary>
        /// delete an article by id. Prevent deleting the article if defined in a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteArticleById(int id)
        {
            var article = await _inventoryService.GetArticleById(id);
            if (article == null) return BadRequest();

            return Ok(await _inventoryService.DeleteArticleById(id));
        }
    }
}
