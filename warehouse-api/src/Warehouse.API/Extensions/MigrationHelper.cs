using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Entities;

namespace Warehouse.API.Extensions
{
    public static class MigrationHelper
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            // create product stock view
            string script =
                @"CREATE VIEW dbo.ProductStock AS 
                SELECT 
	                p.Id
	                , p.Name
	                , ps.Stock
	                , ps.Price

                FROM 
                (
		                        SELECT 
			                        pd.ProductId
		                        ,	Min(a.Stock / pd.ArticleAmount) as Stock
		                        ,	Sum(pd.Price) as Price

		                        FROM ProductDefinition as pd
		                        JOIN Article as a

		                        ON pd.ArticleId = a.Id

		                        GROUP BY pd.ProductId

                ) as ps

                JOIN Product as p

                ON ps.ProductId = p.Id;";

            using (var scope = host.Services.CreateScope())
            {
                IConfiguration configureation = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                bool migrateOnStart = configureation.GetValue<bool>("DBMigration:OnStart");
                if (migrateOnStart)
                {
                    using var repoContext = scope.ServiceProvider.GetRequiredService<WarehouseDbContext>();
                    try
                    {
                        repoContext.Database.Migrate();
                        // create a view for product stock
                        repoContext.Database.ExecuteSqlRawAsync(script);
                    }
                    catch (Exception)
                    {
                        throw;

                    }
                }
            }            
            return host;
        }
    }
}
