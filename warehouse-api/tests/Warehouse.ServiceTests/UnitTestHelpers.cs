using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Entities;

namespace Warehouse.ServiceTests
{
    public class UnitTestHelpers
    {
        public WarehouseDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<WarehouseDbContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;
            var WarehouseDbContext = new WarehouseDbContext(options);
            WarehouseDbContext.Database.EnsureCreated();

            return WarehouseDbContext;
        }
    }
}
