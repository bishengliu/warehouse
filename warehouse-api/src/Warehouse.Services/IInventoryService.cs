using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Entities.Models;
using Warehouse.Services.DTO;

namespace Warehouse.Services
{
    public interface IInventoryService
    {
        /// <summary>
        /// update article details
        /// </summary>
        /// <param name="articles"></param>
        void UpdateInventory(IEnumerable<Article> articles);

        /// <summary>
        /// check whether there are sufficient articles before selling
        /// </summary>
        /// <param name="articles"></param>
        /// <returns></returns>
        bool HasEnoughStock(IEnumerable<ProductArticleModel> articles);

        /// <summary>
        /// update inventory upon selling a product
        /// </summary>
        /// <param name="articles"></param>
        void UpdateInventory(IEnumerable<ProductArticleModel> articles);

        /// <summary>
        /// check whether all the article are in the inventory
        /// </summary>
        /// <param name="articles"></param>
        /// <returns></returns>
        bool AllArticlesInInventory(IEnumerable<Article> articles);

        /// <summary>
        /// add a new article
        /// </summary>
        /// <param name="articles"></param>
        /// <returns></returns>
        void AddArticle(Article article);

        /// <summary>
        /// get an article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Article GetArticleById(int id);

    }
}
