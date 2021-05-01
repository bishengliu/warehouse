using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Services.DTO;

namespace Warehouse.Services
{
    public interface IUploadService
    {
        Task<string> ReadFileContent(IFormFile file);

        IEnumerable<ProductModel> MapProducts(ProductUploadModel productsUpload);
    }
}
