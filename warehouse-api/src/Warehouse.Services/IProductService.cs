using System;
using System.Collections.Generic;
using System.Text;
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
        ProductModel GetProductById(int Id);

        /// <summary>
        /// get all the product
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductModel> GetProducts();

        /// <summary>
        /// sell a product and update inventory
        /// </summary>
        /// <param name="Id"></param>
        void SellProduct(int Id);

        /// <summary>
        /// add new products
        /// </summary>
        /// <param name="products"></param>
        void AddProducts(IEnumerable<ProductModel> products);

        /// <summary>
        /// get stock info of a product
        /// </summary>
        /// <returns></returns>
        ProductStock GetProductStok();

        /// <summary>
        /// get stock info of all products
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductStock> GetAllProductStocks();
    }
}
