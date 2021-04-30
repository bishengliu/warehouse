using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Entities;
using Warehouse.Entities.Models;

namespace Warehouse.Services
{
    public class InventoryService : IInventoryService
    {
        private WarehouseDbContext _repoContext;
        private ILogger<InventoryService> _logger;
        public InventoryService(WarehouseDbContext reposContext, ILogger<InventoryService> logger)
        {
            _repoContext = reposContext;
            _logger = logger;
        }

        public void UpdateInventory(IEnumerable<Article> articles)
        {
            if(AllArticlesInInventory(articles))
            {
                foreach(var art in articles)
                {
                    var article = _repoContext.Article.Find(art.Id);
                    if(article != null)
                    {
                        article.Description = art.Description;
                        article.Name = art.Name;
                        art.Stock = art.Stock;
                    }
                }
                
                _repoContext.SaveChanges();
                _logger.LogInformation("articles 1, 2, 3 updated by DemoUser");
            } 
            else
            {
                _logger.LogError("Update inventory failed: unknown article found!");
            }
        }

        public bool AllArticlesInInventory(IEnumerable<Article> articles)
        {
            int intersections = _repoContext.Article.Select(a => a.Id).Intersect(articles.Select(a => a.Id)).Count();
            return articles.Where(a => a.Id < 0).Any() && intersections != articles.Count();
        }

        public void AddArticle(Article art)
        {
            // check whether same name already in the inventory, since we don't want to add the same article twice
            // in real application more properties can be combined, like color, materials, model code etc

            if(art.Name != string.Empty && !_repoContext.Article.Any(a=> a.Name == art.Name))
            {
                _repoContext.Add(art);
                _repoContext.SaveChanges();

                _logger.LogInformation("new article 1 added by DemoUser");
            }
        }

        public Article GetArticleById(int id) => _repoContext.Article.Find(id);
    }
}
