using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Services;
using Warehouse.Services.Exceptions;
using Xunit;

namespace Warehouse.ServiceTests
{
    public class UploadServiceTests
    {
        private readonly UploadService _uploadService;
        public UploadServiceTests()
        {
            _uploadService = new UploadService();
        }

        [Fact]
        public async Task ReadFileContent_FileHasContent_ReturnsContent()
        {
            // arrange
            var fileMock = new Mock<IFormFile>();
            //Setup mock file using a memory stream
            var content = "file content";
            var fileName = "upload.json";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;

            // act
            var result = await _uploadService.ReadFileContent(file);

            // assert
            Assert.Contains("file content", result);
        }

        [Fact]
        public async Task ReadFileContent_FileHasNoContent_ThrowsUploadEmptyContentException()
        {
            // arrange
            var fileMock = new Mock<IFormFile>();
            //Setup mock file using a memory stream
            var content = string.Empty;
            var fileName = "upload.json";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;

            // act & assert
            await Assert.ThrowsAsync<UploadEmptyContentException>(() => _uploadService.ReadFileContent(file));
        }
    }
}
