using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Services.DTO;

namespace Warehouse.Services
{
    public class UploadService : IUploadService
    {
        public async Task<string> ReadFileContent(IFormFile file)
        {
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
            // todo
            return null;
        }
    }
}
