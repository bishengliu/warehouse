using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.DTO
{
    public class ArticleUploadModel
    {
        public List<ArticleUpload> Inventory { get; set; }
    }

    public class ArticleUpload
    {
        public string Art_id { get; set; }
        public string Name { get; set; }
        public string Stock { get; set; }
    }
}
