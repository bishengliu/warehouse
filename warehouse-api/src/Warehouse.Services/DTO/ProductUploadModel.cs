using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.DTO
{
    public class ProductUploadModel
    {
        public List<ProductUpload> Products { get; set; }
    }
    public class ProductUpload
    {
        public string Name { get; set; }
        public List<ContainArticle> Contain_articles { get; set; }
    }

    public class ContainArticle
    {
        public string Art_id { get; set; }
        public string Amount_of { get; set; }
    }
}
