using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Entities;

namespace Warehouse.API.Extensions
{
    public static class RegisterDbCOntextServiceExtenstion
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configureation)
        {
            string connectionString = configureation.GetValue<string>("WarehouseDb:ConnectionString");

            services.AddDbContext<WarehouseDbContext>(o =>
                // lazy loading
                o.UseLazyLoadingProxies()
                .UseSqlServer(connectionString, options => options.MigrationsAssembly("Warehouse.Entities")));

        }
    }
}
