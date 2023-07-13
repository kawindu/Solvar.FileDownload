using System.Net;
using Moq;
using Moq.Protected;

namespace Solvar.FileDownload.Tests
{
    [TestFixture]
    public class FileDownloadServiceTests
    {
        [Test]
        public async Task DownloadFilesAsync_SuccessfullyDownloadsFiles()
        {
            // Arrange
            var url = "http://example.com/file2.txt";

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ByteArrayContent(new byte[0])
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var fileDownloader = new FileDownloadService();

            // Act
            await fileDownloader.DownloadFileAsync(url, httpClient);

            // Assert
            var fileName = Path.GetFileName(url);
            mockHttpMessageHandler.Protected().Verify("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
            Assert.IsTrue(File.Exists(fileName));
            File.Delete(fileName);
        }
    }
}
