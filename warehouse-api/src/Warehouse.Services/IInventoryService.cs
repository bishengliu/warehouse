using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Entities.Models;
using Warehouse.Services.DTO;

namespace Warehouse.Services
{
    public interface IInventoryService
    {
        /// <summary>
        /// get all the articles
        /// </summary>
        /// <returns></returns>
        IEnumerable<Article> GetArticles();
        /// <summary>
        /// get an article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Article> GetArticleById(int id);
        /// <summary>
        /// check whether there are sufficient articles before selling
        /// </summary>
        /// <param name="articles"></param>
        /// <returns></returns>
        Task<bool> HasSufficientStock(IEnumerable<ProductArticleModel> articles);
        /// <summary>
        /// update inventory upon selling a product
        /// </summary>
        /// <param name="articles"></param>
        Task UpdateInventoryStock(IEnumerable<ProductArticleModel> articles);
        /// <summary>
        /// add a new article
        /// </summary>
        /// <param name="articles"></param>
        /// <returns></returns>
        Task<Article> AddArticle(Article article);
        /// <summary>
        /// add articles
        /// </summary>
        /// <param name="articles"></param>
        /// <returns></returns>
        Task AddArticles(IEnumerable<Article> articles);
        /// <summary>
        /// update an article
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        Task<Article> UpadteArticle(Article article);
        /// <summary>
        /// delete an article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Article> DeleteArticleById(int id);
        /// <summary>
        /// check whether an article is defined at least in a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> IsArticleDefinedInProduct(int id);

    }
}
