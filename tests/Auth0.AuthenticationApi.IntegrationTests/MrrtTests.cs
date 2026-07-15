using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using Auth0.Tests.Shared;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class MrrtTests
{
    private const string Domain = "test-tenant.auth0.com";
    private const string ClientId = "test-client-id";
    private const string ClientSecret = "test-client-secret";
    private const string RefreshToken = "test-refresh-token";

    private static AuthenticationApiClient CreateClient(
        AccessTokenResponse response,
        Dictionary<string, string> expectedParams)
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.RequestUri.ToString() == $"https://{Domain}/oauth/token"
                    && ValidateRequestContent(req, expectedParams)),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    JsonSerializer.Serialize(response, response.GetType()),
                    Encoding.UTF8,
                    "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        return new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));
    }

    private static bool ValidateRequestContent(HttpRequestMessage content, Dictionary<string, string> contentParams)
    {
        string body = content.Content.ReadAsStringAsync().Result;
        var result = body.Split("&")
            .ToDictionary(kv => kv.Split("=")[0], kv => HttpUtility.UrlDecode(kv.Split("=")[1]));
        return contentParams.Aggregate(true, (acc, kv) => acc && result.GetValueOrDefault(kv.Key) == kv.Value);
    }

    [Fact]
    public async Task Can_upscope_for_existing_audience()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "new-access-token",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            Scope = "read:data write:data"
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "refresh_token" },
            { "refresh_token", RefreshToken },
            { "audience", "https://api.example.com" },
            { "scope", "read:data write:data" }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new RefreshTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            RefreshToken = RefreshToken,
            Audience = "https://api.example.com",
            Scope = "read:data write:data"
        });

        result.Should().NotBeNull();
        result.AccessToken.Should().Be("new-access-token");
        result.Scope.Should().Be("read:data write:data");
    }

    [Fact]
    public async Task Can_exchange_token_for_different_audience()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "audience-b-token",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            Scope = "read:b"
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "refresh_token" },
            { "refresh_token", RefreshToken },
            { "audience", "https://api-b.example.com" },
            { "scope", "read:b" }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new RefreshTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            RefreshToken = RefreshToken,
            Audience = "https://api-b.example.com",
            Scope = "read:b"
        });

        result.Should().NotBeNull();
        result.AccessToken.Should().Be("audience-b-token");
        result.Scope.Should().Be("read:b");
    }

    [Fact]
    public async Task Can_upscope_for_default_audience()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "default-audience-token",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            Scope = "openid profile email"
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "refresh_token" },
            { "refresh_token", RefreshToken },
            { "scope", "openid profile email" }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new RefreshTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            RefreshToken = RefreshToken,
            Scope = "openid profile email"
        });

        result.Should().NotBeNull();
        result.Scope.Should().Be("openid profile email");
    }

    [Fact]
    public async Task Can_exchange_from_default_to_specific_audience()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "specific-api-token",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            Scope = "read:tickets"
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "refresh_token" },
            { "refresh_token", RefreshToken },
            { "audience", "https://named-api.example.com" }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new RefreshTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            RefreshToken = RefreshToken,
            Audience = "https://named-api.example.com"
        });

        result.Should().NotBeNull();
        result.AccessToken.Should().Be("specific-api-token");
        result.Scope.Should().Be("read:tickets");
    }

    [Fact]
    public async Task Scope_field_reflects_actual_grants()
    {
        const string requestedScope = "read:data write:data delete:data";
        const string grantedScope = "read:data";

        var response = new AccessTokenResponse
        {
            AccessToken = "narrow-token",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            Scope = grantedScope
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "refresh_token" },
            { "refresh_token", RefreshToken },
            { "scope", requestedScope }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new RefreshTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            RefreshToken = RefreshToken,
            Scope = requestedScope
        });

        result.Scope.Should().Be(grantedScope);
        result.Scope.Should().NotBe(requestedScope);
    }

    [Fact]
    public async Task Returns_error_when_no_refresh_token()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.RequestUri.ToString() == $"https://{Domain}/oauth/token"),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(
                    "{\"error\":\"invalid_request\",\"error_description\":\"Missing required parameter: refresh_token\"}",
                    Encoding.UTF8,
                    "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var client = new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));

        Func<Task> act = () => client.GetTokenAsync(new RefreshTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            RefreshToken = null
        });

        await act.Should().ThrowAsync<ErrorApiException>();
    }
}
