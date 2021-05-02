using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Warehouse.Entities;
using Warehouse.Entities.Models;
using Warehouse.Services;
using Warehouse.Services.Exceptions;
using Xunit;

namespace Warehouse.ServiceTests
{
    public class InventoryServiceTests
    {
        private readonly WarehouseDbContext _repoContext;
        private readonly InventoryService _inventoryService;
        private readonly Mock<ILogger<InventoryService>> _mockLogger;
        private readonly UnitTestHelpers _unitTestHelpers;
        public InventoryServiceTests()
        {
            _unitTestHelpers = new UnitTestHelpers();
            _repoContext = _unitTestHelpers.GetDatabaseContext();
            _mockLogger = new Mock<ILogger<InventoryService>>();

            _inventoryService = new InventoryService(_repoContext, _mockLogger.Object);
        }

        [Fact]
        public async Task AddArticle_ArticleNameNotProvided_ThrowsArticleNameIsNullException()
        {
            Article art = new Article() { Name = string.Empty, Stock = 10 };
            // act & assert
            await Assert.ThrowsAsync<ArticleNameIsNullException>(() => _inventoryService.AddArticle(art));
        }

        // todo add more tests
    }
}
