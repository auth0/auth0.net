using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using FluentAssertions;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.Core.UnitTests
{
    public class HttpClientManagementConnectionTests
    {
        [Fact]
        public async void Should_Retry_When_Hitting_RateLimits()
        {
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var amountOfTimesCalled = 0;

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://test.com/" && amountOfTimesCalled == 0),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Callback(() => amountOfTimesCalled++)
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.TooManyRequests,
                    Content = new StringContent("", Encoding.UTF8, "application/json"),
                });

            mockHandler.Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://test.com/" && amountOfTimesCalled != 0),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent("", Encoding.UTF8, "application/json"),
               });

            var httpClient = new HttpClient(mockHandler.Object);
            var connection = new HttpClientManagementConnection(httpClient);

            var result = await connection.SendAsync<object>(HttpMethod.Get, new Uri("https://test.com/"), null, null, null);

            amountOfTimesCalled.Should().Be(1);
        }

        [Fact]
        public void Should_Keep_Retrying_And_Fail_When_Hitting_Default_Limit()
        {
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var amountOfTimesCalled = 0;

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://test.com/"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Callback(() => amountOfTimesCalled++)
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.TooManyRequests,
                    Content = new StringContent("", Encoding.UTF8, "application/json"),
                });

            var httpClient = new HttpClient(mockHandler.Object);
            var connection = new HttpClientManagementConnection(httpClient);

            Func<Task> getFunc = async () => await connection.SendAsync<object>(HttpMethod.Get, new Uri("https://test.com/"), null, null, null);
            getFunc.Should().Throw<RateLimitApiException>();

            amountOfTimesCalled.Should().Be(3);
        }

        [Fact]
        public void Should_Keep_Retrying_And_Fail_When_Hitting_Configurable_Limit()
        {
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var amountOfTimesCalled = 0;

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://test.com/"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Callback(() => amountOfTimesCalled++)
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.TooManyRequests,
                    Content = new StringContent("", Encoding.UTF8, "application/json"),
                });

            var httpClient = new HttpClient(mockHandler.Object);
            var connection = new HttpClientManagementConnection(httpClient, new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 6 });

            Func<Task> getFunc = async () => await connection.SendAsync<object>(HttpMethod.Get, new Uri("https://test.com/"), null, null, null);
            getFunc.Should().Throw<RateLimitApiException>();

            amountOfTimesCalled.Should().Be(6);
        }

        [Fact]
        public void Should_Not_Retry_When_Limit_Set_To_Zero()
        {
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var amountOfTimesCalled = 0;

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://test.com/"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Callback(() => amountOfTimesCalled++)
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.TooManyRequests,
                    Content = new StringContent("", Encoding.UTF8, "application/json"),
                });

            var httpClient = new HttpClient(mockHandler.Object);
            var connection = new HttpClientManagementConnection(httpClient, new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 0 });

            Func<Task> getFunc = async () => await connection.SendAsync<object>(HttpMethod.Get, new Uri("https://test.com/"), null, null, null);
            getFunc.Should().Throw<RateLimitApiException>();

            amountOfTimesCalled.Should().Be(1);
        }

        [Fact]
        public void Should_Not_Retry_When_Not_A_RateLimitApiException()
        {
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var amountOfTimesCalled = 0;

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://test.com/"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Callback(() => amountOfTimesCalled++)
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("", Encoding.UTF8, "application/json"),
                });

            var httpClient = new HttpClient(mockHandler.Object);
            var connection = new HttpClientManagementConnection(httpClient, new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 6 });

            Func<Task> getFunc = async () => await connection.SendAsync<object>(HttpMethod.Get, new Uri("https://test.com/"), null, null, null);
            getFunc.Should().Throw<ErrorApiException>();

            amountOfTimesCalled.Should().Be(1);
        }
    }
}
