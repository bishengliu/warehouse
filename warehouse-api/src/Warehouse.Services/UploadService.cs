using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Services.DTO;
using System.Linq;
using Warehouse.Entities.Models;
using Warehouse.Services.Exceptions;

namespace Warehouse.Services
{
    public class UploadService : IUploadService
    {
        public UploadService()
        {

        }
        public async Task<string> ReadFileContent(IFormFile file)
        {
            if (file.Length == 0) throw new UploadEmptyContentException("Upload file has no content!");
            var sb = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    sb.AppendLine(await reader.ReadLineAsync());
            }
            return sb.ToString();
        }

        public IEnumerable<ProductModel> MapProducts(ProductUploadModel productsUpload)
        {
            List<ProductModel> products = new List<ProductModel>();
            foreach (var prod in productsUpload.Products)
            {
                ProductModel product = new ProductModel();
                List<ProductArticleModel> articles = new List<ProductArticleModel>();
                product.Name = prod.Name;
                foreach(var art in prod.Contain_articles)
                {
                    ProductArticleModel article = new ProductArticleModel();

                    int id = -1;
                    int amount = 0;
                    if(int.TryParse(art.Art_id, out id) && int.TryParse(art.Amount_of, out amount))
                    {
                        article.Id = id;
                        article.Amount = amount;
                    }
                    articles.Add(article);
                }
                product.Articles = articles;
                products.Add(product);
            }         
            return products.AsEnumerable();
        }

        public IEnumerable<Article> MapArticles(ArticleUploadModel articlesUpload)
        {
            List<Article> articles = new List<Article>();
            foreach(var art in articlesUpload.Inventory)
            {      
                int id = 0;
                int stock = 0;
                decimal price = 0;
                if (int.TryParse(art.Art_id, out id) && int.TryParse(art.Stock, out stock))
                {
                    Article article = new Article();
                    article.Id = id;
                    article.Name = art.Name;
                    article.Stock = stock < 0 ? 0: stock;
                    article.Price = price;
                    articles.Add(article);
                }    
            }
            return articles;
        }
    }
}
