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
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            throw new NotImplementedException();
        }



        public IEnumerable<ProductStock> GetAllProductStocks()
        {
            throw new NotImplementedException();
        }


        public ProductStock GetProductStok()
        {
            throw new NotImplementedException();
        }

        public void SellProduct(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
