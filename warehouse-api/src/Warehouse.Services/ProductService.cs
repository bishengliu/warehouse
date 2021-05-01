using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Entities;
using Warehouse.Entities.Models;
using Warehouse.Services.DTO;
using System.Linq;

namespace Warehouse.Services
{
    public class ProductService : IProductService
    {
        private WarehouseDbContext _repoContext;
        private ILogger<ProductService> _logger;
        private IInventoryService _inventoryService;
        public ProductService(WarehouseDbContext repoContext, 
            ILogger<ProductService> logger,
            IInventoryService inventoryService
            )
        {
            _repoContext = repoContext;
            _logger = logger;
            _inventoryService = inventoryService;
        }
        public void AddProducts(IEnumerable<ProductModel> products)
        {
            // prevent the same product being added twice
            // more product properties can be used 
            int productAlreadyDefined = _repoContext
                .Product.Select(p => p.Name)
                .Intersect(products.Select(p => p.Name)).Count();
            if(productAlreadyDefined  == 0)
            {
                foreach(var product in products)
                {
                    Product prd = new Product();
                    prd.Description = product.Description;
                    prd.Name = product.Name;

                    List<ProductDefinition> definitions = new List<ProductDefinition>();
                    //load product articles
                    foreach(var art in product.Articles)
                    {
                        ProductDefinition def = new ProductDefinition();
                        def.ArticleAmount = art.Amount;
                        def.ArticleId = art.Id;
                        def.Price = 
                            _inventoryService.GetArticleById(art.Id) == null 
                            ? 0 
                            : _inventoryService.GetArticleById(art.Id).Price * art.Amount;
                        def.ProductId = product.Id;
                        definitions.Add(def);
                    }
                    _repoContext.Product.Add(prd);
                    _repoContext.ProductDefinition.AddRange(definitions);
                }
                _repoContext.SaveChanges();
                _logger.LogInformation("products 1, 2, 3 updated by DemoUser");
            } 
            else
            {
                _logger.LogError("Update products failed: at least one produce already exists!");
            }

        }

        public ProductModel GetProductById(int Id)
        {
            ProductModel prodModel = new ProductModel();
            var product = _repoContext.Product.Find(Id);
            if(product != null)
            {
                // get product details
                prodModel.Id = product.Id;
                prodModel.Name = product.Name;
                prodModel.Description = product.Description;

                // get product definition/articles
                List<ProductArticleModel> articles = new List<ProductArticleModel>();
                foreach(var def in product.ProductDefinitions)
                {
                    ProductArticleModel article = new ProductArticleModel();
                    article.Id = def.ArticleId;
                    article.Name = def.Article.Name;
                    article.Amount = def.ArticleAmount;
                    article.Price = def.Price;
                    articles.Add(article);
                }

                prodModel.Articles = articles;

            }
            return prodModel;
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            List<ProductModel> productModels = new List<ProductModel>();

            var products = _repoContext.Product;

            foreach(var prod in products)
            {
                var productModel = GetProductById(prod.Id);
                if(productModel != null)
                {
                    productModels.Add(productModel);
                }
            }

            return productModels;
        }



        public IEnumerable<ProductStock> GetAllProductStocks() => _repoContext.ProductStock;


        public ProductStock GetProductStokById(int id) => _repoContext.ProductStock.FirstOrDefault(s => s.Id == id);

        public void SellProduct(int Id)
        {
            var productModel = GetProductById(Id);
            if(productModel != null)
            {

                if(_inventoryService.HasEnoughStock(productModel.Articles))
                {

                    _inventoryService.UpdateInventory(productModel.Articles);
                }
                else
                {
                    _logger.LogError("failed to sell the product: insufficient articles!");
                }
            } 
            else
            {
                _logger.LogError("failed to sell the product: product doesn't exist!");
            }
        }
    }



}
