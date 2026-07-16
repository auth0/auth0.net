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

public class TokenVaultTests
{
    private const string Domain = "test-tenant.auth0.com";
    private const string ClientId = "test-client-id";
    private const string ClientSecret = "test-client-secret";
    private const string AccessToken = "test-access-token";
    private const string Connection = "google-oauth2";
    private const string GrantType = "urn:auth0:params:oauth:grant-type:token-exchange:federated-connection-access-token";

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
    public void TokenType_constants_have_expected_token_vault_values()
    {
        TokenType.RefreshToken.Should().Be("urn:ietf:params:oauth:token-type:refresh_token");
        TokenType.AccessToken.Should().Be("urn:ietf:params:oauth:token-type:access_token");
        TokenType.FederatedConnectionAccessToken.Should().Be("http://auth0.com/oauth/token-type/federated-connection-access-token");
    }

    [Fact]
    public void FederatedConnectionAccessTokenRequest_implements_IClientAuthentication()
    {
        var request = new FederatedConnectionAccessTokenRequest
        {
            SubjectToken = AccessToken,
            SubjectTokenType = TokenType.AccessToken,
            Connection = Connection,
            ClientId = ClientId
        };

        request.Should().BeAssignableTo<IClientAuthentication>();
        request.SubjectTokenType.Should().Be("urn:ietf:params:oauth:token-type:access_token");
        request.Connection.Should().Be(Connection);
    }

    [Fact]
    public async Task Can_exchange_access_token_for_federated_connection_access_token()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "federated-access-token",
            TokenType = "Bearer",
            ExpiresIn = 3600,
            IssuedTokenType = TokenType.FederatedConnectionAccessToken
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", GrantType },
            { "client_id", ClientId },
            { "subject_token", AccessToken },
            { "subject_token_type", TokenType.AccessToken },
            { "requested_token_type", TokenType.FederatedConnectionAccessToken },
            { "connection", Connection }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new FederatedConnectionAccessTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = AccessToken,
            SubjectTokenType = TokenType.AccessToken,
            Connection = Connection
        });

        result.Should().NotBeNull();
        result.AccessToken.Should().Be("federated-access-token");
        result.IssuedTokenType.Should().Be(TokenType.FederatedConnectionAccessToken);
    }

    [Fact]
    public async Task Sends_login_hint_when_set()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "federated-access-token",
            TokenType = "Bearer",
            ExpiresIn = 3600,
            IssuedTokenType = TokenType.FederatedConnectionAccessToken
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", GrantType },
            { "subject_token", AccessToken },
            { "subject_token_type", TokenType.AccessToken },
            { "connection", Connection },
            { "login_hint", "google-user-123" }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new FederatedConnectionAccessTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = AccessToken,
            SubjectTokenType = TokenType.AccessToken,
            Connection = Connection,
            LoginHint = "google-user-123"
        });

        result.Should().NotBeNull();
        result.AccessToken.Should().Be("federated-access-token");
    }

    [Fact]
    public async Task Omits_login_hint_when_unset()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "federated-access-token",
            TokenType = "Bearer",
            ExpiresIn = 3600,
            IssuedTokenType = TokenType.FederatedConnectionAccessToken
        };

        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        string capturedBody = null;
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.RequestUri.ToString() == $"https://{Domain}/oauth/token"),
                ItExpr.IsAny<CancellationToken>()
            )
            .Callback<HttpRequestMessage, CancellationToken>((req, _) =>
                capturedBody = req.Content.ReadAsStringAsync().Result)
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    JsonSerializer.Serialize(response),
                    Encoding.UTF8,
                    "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var client = new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));

        await client.GetTokenAsync(new FederatedConnectionAccessTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = AccessToken,
            SubjectTokenType = TokenType.AccessToken,
            Connection = Connection
        });

        capturedBody.Should().NotContain("login_hint");
    }

    [Fact]
    public async Task Sends_requested_token_type_as_fixed_federated_urn()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "federated-access-token",
            TokenType = "Bearer",
            ExpiresIn = 3600,
            IssuedTokenType = TokenType.FederatedConnectionAccessToken
        };

        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        string capturedBody = null;
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.RequestUri.ToString() == $"https://{Domain}/oauth/token"),
                ItExpr.IsAny<CancellationToken>()
            )
            .Callback<HttpRequestMessage, CancellationToken>((req, _) =>
                capturedBody = req.Content.ReadAsStringAsync().Result)
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    JsonSerializer.Serialize(response),
                    Encoding.UTF8,
                    "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var client = new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));

        await client.GetTokenAsync(new FederatedConnectionAccessTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = AccessToken,
            SubjectTokenType = TokenType.AccessToken,
            Connection = Connection
        });

        capturedBody.Should().Contain("requested_token_type=");
        var parsed = capturedBody.Split("&")
            .ToDictionary(kv => kv.Split("=")[0], kv => HttpUtility.UrlDecode(kv.Split("=")[1]));
        parsed["requested_token_type"].Should().Be("http://auth0.com/oauth/token-type/federated-connection-access-token");
    }

    [Fact]
    public async Task Throws_when_connection_is_missing()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var httpClient = new HttpClient(mockHandler.Object);
        var client = new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));

        Func<Task> act = () => client.GetTokenAsync(new FederatedConnectionAccessTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = AccessToken,
            SubjectTokenType = TokenType.AccessToken
        });

        await act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task Applies_client_authentication()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "federated-access-token",
            TokenType = "Bearer",
            ExpiresIn = 3600,
            IssuedTokenType = TokenType.FederatedConnectionAccessToken
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", GrantType },
            { "client_id", ClientId },
            { "client_secret", ClientSecret },
            { "subject_token", AccessToken },
            { "subject_token_type", TokenType.AccessToken },
            { "connection", Connection }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new FederatedConnectionAccessTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = AccessToken,
            SubjectTokenType = TokenType.AccessToken,
            Connection = Connection
        });

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Surfaces_server_error()
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
                    "{\"error\":\"invalid_request\",\"error_description\":\"connection is not enabled for token vault\"}",
                    Encoding.UTF8,
                    "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var client = new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));

        Func<Task> act = () => client.GetTokenAsync(new FederatedConnectionAccessTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = AccessToken,
            SubjectTokenType = TokenType.AccessToken,
            Connection = Connection
        });

        await act.Should().ThrowAsync<ErrorApiException>();
    }

    [Fact]
    public void Deserializes_issued_token_type()
    {
        var json = "{\"access_token\":\"fat\",\"token_type\":\"Bearer\",\"issued_token_type\":\"http://auth0.com/oauth/token-type/federated-connection-access-token\"}";

        var response = JsonSerializer.Deserialize<AccessTokenResponse>(json);

        response.IssuedTokenType.Should().Be("http://auth0.com/oauth/token-type/federated-connection-access-token");
    }
}
