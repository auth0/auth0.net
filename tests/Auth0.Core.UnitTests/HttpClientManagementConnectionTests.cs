using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using FluentAssertions;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.Core.UnitTests;

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

    [Theory]
    [InlineData("https://tenant.auth0.com/api/v2/jobs/verification-email")]
    [InlineData("https://tenant.auth0.com/api/v2/tickets/email-verification")]
    [InlineData("https://tenant.auth0.com/api/v2/tickets/password-change")]
    [InlineData("https://tenant.auth0.com/api/v2/organizations/org_123/invitations")]
    [InlineData("https://tenant.auth0.com/api/v2/users")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123")]
    [InlineData("https://tenant.auth0.com/api/v2/guardian/enrollments/ticket")]
    [InlineData("https://tenant.auth0.com/api/v2/self-service-profiles/ssp_123/sso-ticket")]
    public async Task Custom_domain_header_sent_on_whitelisted_endpoint(string url)
    {
        HttpRequestMessage capturedRequest = null;
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("", Encoding.UTF8, "application/json") });

        var connection = new HttpClientManagementConnection(new HttpClient(mockHandler.Object), null, "custom.example.com");
        await connection.GetAsync<object>(new Uri(url), null);

        Assert.NotNull(capturedRequest);
        Assert.True(capturedRequest.Headers.Contains(CustomDomainHeader.HeaderName));
        Assert.Equal("custom.example.com", capturedRequest.Headers.GetValues(CustomDomainHeader.HeaderName).Single());
    }

    [Theory]
    [InlineData("https://tenant.auth0.com/api/v2/clients")]
    [InlineData("https://tenant.auth0.com/api/v2/clients/client_123")]
    [InlineData("https://tenant.auth0.com/api/v2/connections")]
    [InlineData("https://tenant.auth0.com/api/v2/tenant/settings")]
    [InlineData("https://tenant.auth0.com/api/v2/logs")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123/roles")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123/permissions")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123/logs")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123/identities")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123/enrollments")]
    public async Task Custom_domain_header_not_sent_on_non_whitelisted_endpoint(string url)
    {
        HttpRequestMessage capturedRequest = null;
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("", Encoding.UTF8, "application/json") });

        var connection = new HttpClientManagementConnection(new HttpClient(mockHandler.Object), null, "custom.example.com");
        await connection.GetAsync<object>(new Uri(url), null);

        Assert.NotNull(capturedRequest);
        Assert.False(capturedRequest.Headers.Contains(CustomDomainHeader.HeaderName));
    }

    [Fact]
    public async Task Custom_domain_header_not_sent_when_not_configured()
    {
        HttpRequestMessage capturedRequest = null;
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("", Encoding.UTF8, "application/json") });

        var connection = new HttpClientManagementConnection(new HttpClient(mockHandler.Object));
        await connection.GetAsync<object>(new Uri("https://tenant.auth0.com/api/v2/users"), null);

        Assert.NotNull(capturedRequest);
        Assert.False(capturedRequest.Headers.Contains(CustomDomainHeader.HeaderName));
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