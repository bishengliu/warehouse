using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Entities;
using Warehouse.Entities.Models;
using Warehouse.Services.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Warehouse.Services.Exceptions;

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

        public async Task AddProducts(IEnumerable<ProductModel> products)
        {
            try
            {
                // prevent the same product being added twice
                // more product properties can be used 
                var productNameGroups = products.GroupBy(p => p.Name);
                if (productNameGroups.Count() != products.Count())
                {
                    throw new ProductNameNotUniqueException("Product Names must be unique!");
                }

                foreach (var product in products)
                {
                    Product prd = await CreateProduct(product);
                    List<ProductDefinition> definitions = await CreateProductDefinitions(product, prd);
                    await _repoContext.Product.AddAsync(prd);
                    await _repoContext.ProductDefinition.AddRangeAsync(definitions);
                }
                await _repoContext.SaveChangesAsync();
                _logger.LogInformation($"products added by DemoUser");
            }
            catch (ProductNameIsNullException)
            {
                _logger.LogError($"add products failed: product name not provided!");
                throw;
            }
            catch (ProductNameNotUniqueException)
            {
                _logger.LogError($"add products failed: a product with the same name already exists!");
                throw;
            }
            catch (ArticleNotFoundException)
            {
                _logger.LogError($"add products failed: article not found!");
                throw;
            }
            catch (Exception)
            {
                _logger.LogError("add products failed: an unkown error encountered!");
                throw;
            }           
        }

        public async Task<ProductModel> GetProductById(int Id)
        {       
            var product = await _repoContext.Product.FindAsync(Id);
            return product != null ? MapProduct(product) : null;
        }

        public async Task<Product> GetProductByName(string name) 
            => await _repoContext.Product.FirstOrDefaultAsync(p => p.Name == name);

        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            try
            {
                Product prd = await CreateProduct(product);
                List<ProductDefinition> definitions = await CreateProductDefinitions(product, prd);
                await _repoContext.Product.AddAsync(prd);
                await _repoContext.ProductDefinition.AddRangeAsync(definitions);
                await _repoContext.SaveChangesAsync();
                return MapProduct(prd);
            }
            catch (ProductNameIsNullException)
            {
                _logger.LogError($"update product {product.Id} failed: product name not provided!");
                throw;
            }
            catch (ProductNameNotUniqueException)
            {
                _logger.LogError($"add product failed: a product with the same name {product.Name} already exists!");
                throw;
            }
            catch (ArticleNotFoundException)
            {
                _logger.LogError($"add product failed: article not found!");
                throw;
            }
            catch (Exception)
            {
                _logger.LogError("add product failed: an unkown error encountered!");
                throw;
            }
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            try
            {
                var prod = await _repoContext.Product.FindAsync(product.Id);
                prod.Name = product.Name;
                if(product.Name == string.Empty)
                {                    
                    throw new ProductNameIsNullException($"update product {product.Id} failed: product name not provided!");
                }
                prod.Description = product.Description;

                _repoContext.ProductDefinition.RemoveRange(prod.ProductDefinitions);
                prod.ProductDefinitions = await CreateProductDefinitions(product, prod);
                await _repoContext.SaveChangesAsync();
                return MapProduct(prod);
            }
            catch (ProductNameIsNullException)
            {
                _logger.LogError($"update product {product.Id} failed: product name not provided!");
                throw;
            }
            catch (ProductNotFoundException)
            {
                _logger.LogError($"update product {product.Id} failed: product not found!");
                throw;
            }
            catch (ArticleNotFoundException)
            {
                _logger.LogError($"add product failed: article not found!");
                throw;
            }
            catch (Exception)
            {
                _logger.LogError($"update product {product.Id} failed: an unkown error encountered!");
                throw;
            }
        }

        private async Task<List<ProductDefinition>> CreateProductDefinitions(ProductModel product, Product prd)
        {
            List<ProductDefinition> definitions = new List<ProductDefinition>();
            //load product articles
            foreach (var art in product.Articles)
            {
                var article = await _inventoryService.GetArticleById(art.Id);
                if(article == null)
                {
                    _logger.LogError($"No article found with Id {art.Id}!");
                    throw new ArticleNotFoundException($"No article found with Id {art.Id}!");
                }
                ProductDefinition def = new ProductDefinition();
                def.ArticleAmount = art.Amount;
                def.ArticleId = art.Id;
                def.Price = article.Price <= 0 ? 0 : article.Price * art.Amount;
                def.Product = prd;
                definitions.Add(def);
            }
            return definitions;
        }
        
        private async Task<Product> CreateProduct(ProductModel product)
        {
            if (product.Name == string.Empty)
            {
                _logger.LogError($"add product {product.Id} failed: product name not provided!");
                throw new ProductNameIsNullException($"add product {product.Id} failed: product name not provided!");
            }
            var prod = await GetProductByName(product.Name);
            if(prod != null)
            {
                _logger.LogError($"add product failed: a product with the same name {product.Name} already exists!");
                throw new ProductNameNotUniqueException($"Product Name must be unique: a product with the same name {product.Name} already exists!");
            }
            Product prd = new Product();
            prd.Description = product.Description;
            prd.Name = product.Name;
       
            return prd;
        }
        
        private ProductModel MapProduct(Product product)
        {
            ProductModel prodModel = new ProductModel();
            if (product != null)
            {
                // get product details
                prodModel.Id = product.Id;
                prodModel.Name = product.Name;
                prodModel.Description = product.Description;

                // get product definition/articles
                List<ProductArticleModel> articles = new List<ProductArticleModel>();
                foreach (var def in product.ProductDefinitions)
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
        
        public async Task<ProductModel> DeleteProductById(int id)
        {
            try
            {
                var prod = await _repoContext.Product.FindAsync(id);
                if (prod != null) throw new ProductNotFoundException("Product doesn't exist!");
                         
                _repoContext.ProductDefinition.RemoveRange(prod.ProductDefinitions);
                _repoContext.Product.Remove(prod);
                var productModel = MapProduct(prod);
                await _repoContext.SaveChangesAsync();
                return productModel;
            }
            catch (ProductNotFoundException)
            {
                _logger.LogError("delete product failed: product not found!");
                throw;
            }
            catch (Exception){
                _logger.LogError("delete product failed: an unkown error encountered!");
                throw;
            }   
        }
        
        public IEnumerable<ProductModel> GetProducts()
        {
            List<ProductModel> productModels = new List<ProductModel>();

            var products = _repoContext.Product;

            foreach(var prod in products)
            {
                var productModel = MapProduct(prod);
                if(productModel != null)
                {
                    productModels.Add(productModel);
                }
            }

            return productModels;
        }

        public IEnumerable<ProductStock> GetAllProductStocks() => _repoContext.ProductStock;

        public async Task<ProductStock> GetProductStokById(int id) => await _repoContext.ProductStock.FindAsync(id);

        public async Task SellProduct(int Id)
        {
            try
            {
                var productModel = await GetProductById(Id);
                if(productModel == null)
                    throw new ProductNotFoundException($"sell product failed: product {Id} not found!");
                if (! await _inventoryService.HasSufficientStock(productModel.Articles))
                    throw new InsufficientArticlesException($"failed to sell product {Id}: insufficient articles!");
                // sell
                await _inventoryService.UpdateInventoryStock(productModel.Articles);                
            }
            catch(InsufficientArticlesException)
            {
                _logger.LogError($"failed to sell product {Id}: insufficient articles!");
                throw;
            }
            catch(ProductNotFoundException)
            {
                _logger.LogError($"sell product failed: product {Id} not found!");
                throw;
            }
            catch (Exception)
            {
                _logger.LogError("sell the product failed: an unkown error encountered!");
                throw;
            }
                     
        }
    }
}
