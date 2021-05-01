using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Entities.Models;
using Warehouse.Services.DTO;

namespace Warehouse.Services
{
    public interface IProductService
    {
        /// <summary>
        /// get a product by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<ProductModel> GetProductById(int Id);

        /// <summary>
        /// get all the product
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductModel> GetProducts();

        /// <summary>
        /// sell a product and update inventory
        /// </summary>
        /// <param name="Id"></param>
        Task SellProduct(int Id);

        /// <summary>
        /// add new products
        /// </summary>
        /// <param name="products"></param>
        Task AddProducts(IEnumerable<ProductModel> products);

        /// <summary>
        /// add a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<ProductModel> AddProduct(ProductModel product);
        /// <summary>
        /// update a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<ProductModel> UpdateProduct(ProductModel product);
        /// <summary>
        /// delete a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<ProductModel> DeleteProductById(int id);
        /// <summary>
        /// get stock info of a product
        /// </summary>
        /// <returns></returns>
        Task<ProductStock> GetProductStokById(int id);

        /// <summary>
        /// get stock info of all products
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductStock> GetAllProductStocks();
    }
}
