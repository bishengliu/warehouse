using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Entities;
using Warehouse.Entities.Models;
using Warehouse.Services.DTO;
using Warehouse.Services.Exceptions;

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

        public IEnumerable<Article> GetArticles() => _repoContext.Article;
        public async Task<Article> GetArticleById(int id) => await _repoContext.Article.FindAsync(id);

        public async Task<Article> GetArticleByName(string name) => await _repoContext.Article.FirstOrDefaultAsync(a => a.Name == name);

        private async Task<Article> CreateArticle(Article art)
        {
            if (art.Name == string.Empty) 
                throw new ArticleNameIsNullException("add artcile failed: artcile name not provided!");
            // check whether same name already in the inventory, since we don't want to add the same article twice
            // in real application more properties can be combined, like color, materials, model code etc

            if (await GetArticleByName(art.Name) != null) 
                throw new ArticleNameNotUniqueException($"add article failed: an article with the same name {art.Name} already exists!");
            var article = new Article()
            {
                Name = art.Name,
                Description = art.Description,
                Stock = art.Stock <= 0 ? 0 : art.Stock,
                Price = art.Price <= 0 ? 0 : art.Price
            };
            return article;
        }

        public async Task<Article> AddArticle(Article art)
        {
            try
            {
                var article = await CreateArticle(art);
                await _repoContext.Article.AddAsync(article);
                await _repoContext.SaveChangesAsync();
                _logger.LogInformation($"new article {art.Name} added by DemoUser");
                return await GetArticleByName(art.Name);
            }
            catch (ArticleNameIsNullException)
            {
                _logger.LogError("add artcile failed: artcile name not provided!");
                throw;
            }
            catch (ArticleNameNotUniqueException)
            {
                _logger.LogError($"add article failed: an article with the same name {art.Name} already exists!");
                throw;
            }      
            catch (Exception)
            {
                _logger.LogError("add article failed: an unkown error encountered!");
                throw;
            }            
        }

        public async Task<Article> UpadteArticle(Article art)
        {
            try
            {
                var article = await GetArticleById(art.Id);
                if (article.Name == string.Empty)
                {
                    throw new ArticleNameIsNullException($"update article {article.Id} failed: article name not provided!");
                }
                article.Name = art.Name;
                article.Stock = art.Stock <= 0 ? 0 : art.Stock;
                article.Price = art.Price <= 0 ? 0 : art.Price;
                article.Description = art.Description;
                await _repoContext.SaveChangesAsync();
                return article;
            }
            catch(ArticleNameIsNullException)
            {
                _logger.LogError($"update article {art.Id} failed: article name not provided!");
                throw;
            }
            catch (Exception)
            {
                _logger.LogError("update article failed: an unkown error encountered!");
                throw;
            }
        }

        public async Task<Article> DeleteArticleById(int id)
        {
            try
            {
                var article = await GetArticleById(id);
                if (article == null)
                    throw new ArticleNotFoundException($"delete article failed: article not found with id {id}!");
                // prevent delete if included in a product
                if (await IsArticleDefinedInProduct(article.Id))
                    throw new ArticleDefinedInProductException($"delete article failed: article {id} is defined in a product!");
                _repoContext.Article.Remove(article);
                await _repoContext.SaveChangesAsync();
                return article;
            }
            catch(ArticleDefinedInProductException)
            {
                _logger.LogError($"delete article failed: article {id} is defined in a product!");
                throw;
            }
            catch (ArticleNotFoundException)
            {
                _logger.LogError($"delete article failed: article not found with id {id}!");
                throw;
            }
            catch (Exception)
            {
                _logger.LogError("delete article failed: an unkown error encountered!");
                throw;
            }
        }

        public async Task<bool> HasSufficientStock(IEnumerable<ProductArticleModel> articleModels)
        {
            var articles = _repoContext.Article.Where(a => articleModels.Select(m => m.Id).Contains(a.Id));
            foreach (var model in articleModels)
            {
                var article = await articles.FirstOrDefaultAsync(a => a.Id == model.Id);
                if (article.Stock < model.Amount)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task UpdateInventoryStock(IEnumerable<ProductArticleModel> articleModels)
        {
            var articles = _repoContext.Article.Where(a => articleModels.Select(m => m.Id).Contains(a.Id));
            foreach (var model in articleModels)
            {
                var article = await articles.FirstOrDefaultAsync(a => a.Id == model.Id);
                article.Stock -= model.Amount;
            }
            await _repoContext.SaveChangesAsync();
        }

        public async Task AddArticles(IEnumerable<Article> articles)
        {
            try
            {
                var articleNameGroups = articles.GroupBy(p => p.Name);
                if (articleNameGroups.Count() != articles.Count())
                {
                    throw new ArticleNameNotUniqueException("article Names must be unique!");
                }
                foreach(var article in articles)
                {
                    var art = await CreateArticle(article);
                    await _repoContext.Article.AddAsync(art);
                }
                await _repoContext.SaveChangesAsync();
                _logger.LogInformation($"articles added by DemoUser");
            }
            catch (ArticleNameIsNullException)
            {
                _logger.LogError($"add articles failed: article name not provided!");
                throw;
            }
            catch (ArticleNameNotUniqueException)
            {
                _logger.LogError($"add articles failed: a product with the same name already exists!");
                throw;
            }
            catch (Exception)
            {
                _logger.LogError("add articles failed: an unkown error encountered!");
                throw;
            }
        }

        public async Task<bool> IsArticleDefinedInProduct(int id) => await _repoContext.ProductDefinition.FirstOrDefaultAsync(d => d.ArticleId == id) != null;
    }
}
