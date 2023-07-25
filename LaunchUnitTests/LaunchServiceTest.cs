using System.Net;
using System.Net.Http;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using LaunchApi.ApiClients.v1;
using LaunchApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LaunchUnitTests
{
    public class LaunchTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("")]
        public void LaunchesService_GetLaunchAsyncByEmptyStringId_ThrowsArgumentNullException(string id)
        {
            var expectedResponse = "";

            var mockHttpMessageHandler = GetHttpMessageHandlerMock(HttpStatusCode.OK, "");

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var launchApiClient = new LaunchesApiClient(httpClient);
            var launchService = new LaunchesService(launchApiClient);

            Assert.ThrowsAsync<ArgumentNullException>(async () => { await launchService.GetLaunchAsync(id); });
        }


        private Mock<HttpMessageHandler> GetHttpMessageHandlerMock(HttpStatusCode httpStatusCode, string content)
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = httpStatusCode,
                    Content = new StringContent(content),
                });

            return mockHttpMessageHandler;
        }
    }
}