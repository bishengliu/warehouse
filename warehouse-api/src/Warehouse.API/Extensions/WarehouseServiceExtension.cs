using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Services;

namespace Warehouse.API.Extensions
{
    public static class WarehouseServiceExtension
    {
        public static void RegisterWarehouseService(this IServiceCollection services)
        {
            services.AddTransient<IUploadService, UploadService>();
            services.AddTransient<IInventoryService, InventoryService>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
