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
    [InlineData("https://tenant.auth0.com/api/v2/jobs/verification-email", "GET")]
    [InlineData("https://tenant.auth0.com/api/v2/jobs/verification-email", "POST")]
    [InlineData("https://tenant.auth0.com/api/v2/tickets/email-verification", "GET")]
    [InlineData("https://tenant.auth0.com/api/v2/tickets/email-verification", "POST")]
    [InlineData("https://tenant.auth0.com/api/v2/tickets/password-change", "GET")]
    [InlineData("https://tenant.auth0.com/api/v2/tickets/password-change", "POST")]
    [InlineData("https://tenant.auth0.com/api/v2/organizations/org_123/invitations", "GET")]
    [InlineData("https://tenant.auth0.com/api/v2/organizations/org_123/invitations", "POST")]
    [InlineData("https://tenant.auth0.com/api/v2/users", "GET")]
    [InlineData("https://tenant.auth0.com/api/v2/users", "POST")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123", "GET")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123", "POST")]
    [InlineData("https://tenant.auth0.com/api/v2/guardian/enrollments/ticket", "GET")]
    [InlineData("https://tenant.auth0.com/api/v2/guardian/enrollments/ticket", "POST")]
    [InlineData("https://tenant.auth0.com/api/v2/self-service-profiles/ssp_123/sso-ticket", "GET")]
    [InlineData("https://tenant.auth0.com/api/v2/self-service-profiles/ssp_123/sso-ticket", "POST")]
    public async Task Custom_domain_header_sent_on_allowed_endpoint(string url, string httpMethod)
    {
        HttpRequestMessage capturedRequest = null;
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("", Encoding.UTF8, "application/json") });

        var connection = new HttpClientManagementConnection(new HttpClient(mockHandler.Object), null, "custom.example.com");
        var method = new HttpMethod(httpMethod);
        if (method == HttpMethod.Get)
            await connection.GetAsync<object>(new Uri(url), null);
        else
            await connection.SendAsync<object>(method, new Uri(url), null, null);

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
    [InlineData("https://tenant.auth0.com/api/v2/users/")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123/roles")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123/permissions")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123/logs")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123/identities")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0|123/enrollments")]
    public async Task Custom_domain_header_not_sent_on_non_allowed_endpoint(string url)
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

    [Theory]
    [InlineData(" ")]
    [InlineData("   ")]
    [InlineData("\t")]
    public void Custom_domain_throws_when_whitespace(string customDomain)
    {
        Assert.Throws<ArgumentException>(() =>
            new HttpClientManagementConnection(new HttpClient(), null, customDomain));
    }

    [Theory]
    [InlineData("https://login.example.com")]
    [InlineData("http://login.example.com")]
    public void Custom_domain_throws_when_contains_scheme(string customDomain)
    {
        Assert.Throws<ArgumentException>(() =>
            new HttpClientManagementConnection(new HttpClient(), null, customDomain));
    }

    [Theory]
    [InlineData("login.example.com/path")]
    [InlineData("login.example.com/")]
    public void Custom_domain_throws_when_contains_path(string customDomain)
    {
        Assert.Throws<ArgumentException>(() =>
            new HttpClientManagementConnection(new HttpClient(), null, customDomain));
    }

    [Fact]
    public void Custom_domain_wired_into_internally_created_connection_when_null_connection_passed()
    {
        var client = new InspectableManagementApiClient("fake", "tenant.auth0.com", null, "custom.example.com");

        var conn = client.ExposedConnection as HttpClientManagementConnection;
        Assert.NotNull(conn);
        Assert.Equal("custom.example.com", conn.customDomain);
    }

    private class InspectableManagementApiClient(string token, string domain, IManagementConnection conn, string customDomain)
        : ManagementApiClient(token, domain, conn, customDomain)
    {
        public IManagementConnection ExposedConnection => connection;
    }

    [Fact]
    public async Task Custom_domain_header_sent_on_allowed_endpoint_via_management_client()
    {
        HttpRequestMessage capturedRequest = null;
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("[]", Encoding.UTF8, "application/json") });

        var connection = new HttpClientManagementConnection(new HttpClient(mockHandler.Object), null, "custom.example.com");
        var client = new ManagementApiClient("fake", "tenant.auth0.com", connection);

        await client.Users.GetAllAsync(new ManagementApi.Models.GetUsersRequest(), new ManagementApi.Paging.PaginationInfo());

        Assert.NotNull(capturedRequest);
        Assert.True(capturedRequest.Headers.Contains(CustomDomainHeader.HeaderName));
        Assert.Equal("custom.example.com", capturedRequest.Headers.GetValues(CustomDomainHeader.HeaderName).Single());
    }

    [Fact]
    public async Task Custom_domain_header_not_sent_on_non_allowed_endpoint_via_management_client()
    {
        HttpRequestMessage capturedRequest = null;
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}", Encoding.UTF8, "application/json") });

        var connection = new HttpClientManagementConnection(new HttpClient(mockHandler.Object), null, "custom.example.com");
        var client = new ManagementApiClient("fake", "tenant.auth0.com", connection);

        await client.TenantSettings.GetAsync();

        Assert.NotNull(capturedRequest);
        Assert.False(capturedRequest.Headers.Contains(CustomDomainHeader.HeaderName));
    }

    [Fact]
    public async Task Custom_domain_header_sent_when_connection_and_custom_domain_both_provided_and_connection_has_custom_domain()
    {
        HttpRequestMessage capturedRequest = null;
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("[]", Encoding.UTF8, "application/json") });
            
        var connection = new HttpClientManagementConnection(new HttpClient(mockHandler.Object), null, "custom.example.com");
        var client = new ManagementApiClient("fake", "tenant.auth0.com", connection, "custom.example.com");

        await client.Users.GetAllAsync(new ManagementApi.Models.GetUsersRequest(), new ManagementApi.Paging.PaginationInfo());

        Assert.NotNull(capturedRequest);
        Assert.True(capturedRequest.Headers.Contains(CustomDomainHeader.HeaderName));
        Assert.Equal("custom.example.com", capturedRequest.Headers.GetValues(CustomDomainHeader.HeaderName).Single());
    }

    [Fact]
    public async Task Custom_domain_header_not_sent_when_connection_provided_without_custom_domain()
    {
        HttpRequestMessage capturedRequest = null;
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("[]", Encoding.UTF8, "application/json") });

        // Connection has no custom domain; customDomain on the constructor is ignored when a connection is supplied.
        var connection = new HttpClientManagementConnection(new HttpClient(mockHandler.Object));
        var client = new ManagementApiClient("fake", "tenant.auth0.com", connection, "custom.example.com");

        await client.Users.GetAllAsync(new ManagementApi.Models.GetUsersRequest(), new ManagementApi.Paging.PaginationInfo());

        Assert.NotNull(capturedRequest);
        Assert.False(capturedRequest.Headers.Contains(CustomDomainHeader.HeaderName));
    }

    [Theory]
    [InlineData("https://tenant.auth0.com/api/v2/users?page=0&per_page=10")]
    [InlineData("https://tenant.auth0.com/api/v2/users/auth0%7C123")]
    public async Task Custom_domain_header_sent_on_allowed_endpoint_with_query_and_encoding(string url)
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
    }

    [Theory]
    [InlineData("https://tenant.auth0.com/api/v2/organizations/org_123/invitations/inv_456")]
    [InlineData("https://tenant.auth0.com/api/v2/guardian/enrollments/ticket/extra")]
    [InlineData("https://tenant.auth0.com/api/v2/jobs/verification-email/extra")]
    public async Task Custom_domain_header_not_sent_on_sub_paths_of_allowed_endpoints(string url)
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
    public void Custom_domain_throws_when_empty_string()
    {
        Assert.Throws<ArgumentException>(() =>
            new HttpClientManagementConnection(new HttpClient(), null, ""));
    }

    [Fact]
    public void Custom_domain_trims_whitespace()
    {
        var connection = new HttpClientManagementConnection(new HttpClient(), null, "  custom.example.com  ");
        // Should not throw — whitespace is trimmed, not rejected
    }

    [Theory]
    [InlineData("https://tenant.auth0.com/api/v2/USERS")]
    [InlineData("https://tenant.auth0.com/api/v2/Users/auth0|123")]
    [InlineData("https://tenant.auth0.com/api/v2/TICKETS/Password-Change")]
    [InlineData("https://tenant.auth0.com/api/v2/Jobs/Verification-Email")]
    public async Task Custom_domain_header_sent_on_allowed_endpoint_case_insensitive(string url)
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
    }

    [Theory]
    [InlineData("https://evil.com/users")]
    [InlineData("https://example.com/tickets/password-change")]
    [InlineData("https://example.com/some/path/users")]
    public async Task Custom_domain_header_not_sent_when_api_v2_prefix_missing(string url)
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
    public void Custom_domain_accepts_domain_with_port()
    {
        var connection = new HttpClientManagementConnection(new HttpClient(), null, "login.example.com:8443");
        // Should not throw — port numbers are valid in domain specifications
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