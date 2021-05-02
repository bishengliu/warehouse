using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Warehouse.Entities;
using Warehouse.Services;
using Warehouse.Services.DTO;
using Warehouse.Services.Exceptions;
using Xunit;

namespace Warehouse.ServiceTests
{
    public class ProductServiceTests
    {
        private readonly ProductService _productService;
        private readonly WarehouseDbContext _repoContext;
        private readonly UnitTestHelpers _unitTestHelpers;
        private readonly Mock<ILogger<ProductService>> _mockLogger;
        private readonly Mock<IInventoryService> _mockInventoryService;
        public ProductServiceTests()
        {
            _unitTestHelpers = new UnitTestHelpers();
            _repoContext = _unitTestHelpers.GetDatabaseContext();
            _mockLogger = new Mock<ILogger<ProductService>>();
            _mockInventoryService = new Mock<IInventoryService>();

            _productService = new ProductService(
                _repoContext
                , _mockLogger.Object
                , _mockInventoryService.Object);
        }

        [Fact]
        public async Task AddProduct_ProductameNotProvided_ThrowsProductNameIsNullException()
        {
            ProductModel product = new ProductModel() { Name = string.Empty };

            // act & assert
            await Assert.ThrowsAsync<ProductNameIsNullException>(() => _productService.AddProduct(product));
        }

        // todo add more tests
    }
}
