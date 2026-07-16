using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Auth0.AuthenticationApi.Models;
using Auth0.AuthenticationApi.Tokens;
using Auth0.Core.Exceptions;
using Auth0.Tests.Shared;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Moq.Protected;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class CustomTokenExchangeTests
{
    private const string Domain = "test-tenant.auth0.com";
    private const string ClientId = "test-client-id";
    private const string ClientSecret = "test-client-secret";
    private const string SubjectToken = "test-subject-token";
    private const string CteProfile = "https://acme.com/cte-profile";

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
    public async Task Can_exchange_subject_token_for_access_token()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "exchanged-access-token",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            IssuedTokenType = TokenType.AccessToken
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "urn:ietf:params:oauth:grant-type:token-exchange" },
            { "subject_token", SubjectToken },
            { "subject_token_type", CteProfile }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile
        });

        result.Should().NotBeNull();
        result.AccessToken.Should().Be("exchanged-access-token");
        result.IssuedTokenType.Should().Be(TokenType.AccessToken);
    }

    [Fact]
    public void TokenType_constants_have_expected_urn_values()
    {
        TokenType.IdToken.Should().Be("urn:ietf:params:oauth:token-type:id_token");
        TokenType.AccessToken.Should().Be("urn:ietf:params:oauth:token-type:access_token");
        TokenType.Jwt.Should().Be("urn:ietf:params:oauth:token-type:jwt");
        TokenType.SessionTransferToken.Should().Be("urn:auth0:params:oauth:token-type:session_transfer_token");
    }

    [Fact]
    public void IssuedTokenType_deserializes_from_response()
    {
        var json = "{\"access_token\":\"at\",\"token_type\":\"Bearer\",\"issued_token_type\":\"urn:ietf:params:oauth:token-type:access_token\"}";

        var response = JsonSerializer.Deserialize<AccessTokenResponse>(json);

        response.IssuedTokenType.Should().Be("urn:ietf:params:oauth:token-type:access_token");
    }

    [Fact]
    public void TokenExchangeTokenRequest_implements_IClientAuthentication()
    {
        var request = new TokenExchangeTokenRequest
        {
            SubjectToken = "st",
            SubjectTokenType = CteProfile,
            ClientId = "cid"
        };

        request.Should().BeAssignableTo<IClientAuthentication>();
        request.SubjectTokenType.Should().Be(CteProfile);
    }

    [Fact]
    public async Task Can_exchange_with_actor_token()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "delegated-token",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            IssuedTokenType = TokenType.AccessToken
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "urn:ietf:params:oauth:grant-type:token-exchange" },
            { "subject_token", SubjectToken },
            { "subject_token_type", CteProfile },
            { "actor_token", "actor-token-value" },
            { "actor_token_type", TokenType.AccessToken }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile,
            ActorToken = "actor-token-value",
            ActorTokenType = TokenType.AccessToken
        });

        result.Should().NotBeNull();
        result.AccessToken.Should().Be("delegated-token");
    }

    [Fact]
    public async Task Can_request_session_transfer_token()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "session-transfer-token-value",
            TokenType = "Bearer",
            ExpiresIn = 60,
            IssuedTokenType = TokenType.SessionTransferToken
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "urn:ietf:params:oauth:grant-type:token-exchange" },
            { "subject_token", SubjectToken },
            { "subject_token_type", CteProfile },
            { "audience", "urn:test-tenant.auth0.com:session_transfer" }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile,
            Audience = "urn:test-tenant.auth0.com:session_transfer"
        });

        result.Should().NotBeNull();
        result.IssuedTokenType.Should().Be(TokenType.SessionTransferToken);
        result.AccessToken.Should().Be("session-transfer-token-value");
    }

    [Fact]
    public async Task Sends_optional_organization()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "at",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            IssuedTokenType = TokenType.AccessToken
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "urn:ietf:params:oauth:grant-type:token-exchange" },
            { "subject_token", SubjectToken },
            { "subject_token_type", CteProfile },
            { "organization", "org_abc123" }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile,
            Organization = "org_abc123"
        });

        result.Should().NotBeNull();
        result.AccessToken.Should().Be("at");
    }

    [Fact]
    public async Task Sends_scope_when_set()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "at",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            IssuedTokenType = TokenType.AccessToken
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "urn:ietf:params:oauth:grant-type:token-exchange" },
            { "subject_token", SubjectToken },
            { "subject_token_type", CteProfile },
            { "scope", "read:data write:data" }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile,
            Scope = "read:data write:data"
        });

        result.Should().NotBeNull();
        result.AccessToken.Should().Be("at");
    }

    [Fact]
    public async Task Sends_client_secret_in_request_body()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "at",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            IssuedTokenType = TokenType.AccessToken
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "urn:ietf:params:oauth:grant-type:token-exchange" },
            { "client_id", ClientId },
            { "client_secret", ClientSecret },
            { "subject_token", SubjectToken },
            { "subject_token_type", CteProfile }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile
        });

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Omits_optional_params_when_unset()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "at",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            IssuedTokenType = TokenType.AccessToken
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

        await client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile
        });

        capturedBody.Should().NotContain("actor_token");
        capturedBody.Should().NotContain("audience");
        capturedBody.Should().NotContain("scope");
        capturedBody.Should().NotContain("reason");
        capturedBody.Should().NotContain("organization");
    }

    [Fact]
    public async Task Throws_when_subject_token_is_missing()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var httpClient = new HttpClient(mockHandler.Object);
        var client = new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));

        Func<Task> act = () => client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectTokenType = CteProfile
        });

        await act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task Throws_when_subject_token_type_is_missing()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var httpClient = new HttpClient(mockHandler.Object);
        var client = new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));

        Func<Task> act = () => client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken
        });

        await act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task Throws_when_only_actor_token_set()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var httpClient = new HttpClient(mockHandler.Object);
        var client = new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));

        Func<Task> act = () => client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile,
            ActorToken = "actor-only"
        });

        await act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task Throws_when_only_actor_token_type_set()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var httpClient = new HttpClient(mockHandler.Object);
        var client = new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));

        Func<Task> act = () => client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile,
            ActorTokenType = TokenType.AccessToken
        });

        await act.Should().ThrowAsync<ArgumentException>();
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
                    "{\"error\":\"invalid_request\",\"error_description\":\"setActor is required\"}",
                    Encoding.UTF8,
                    "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var client = new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));

        Func<Task> act = () => client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile
        });

        await act.Should().ThrowAsync<ErrorApiException>();
    }

    [Fact]
    public async Task Validates_returned_id_token()
    {
        var secret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(secret);
        var client = CreateClientReturningIdToken(idToken);

        var result = await client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = secret,
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile,
            SigningAlgorithm = JwtSignatureAlgorithm.HS256
        });

        result.Should().NotBeNull();
        result.IdToken.Should().Be(idToken);
    }

    [Fact]
    public async Task Throws_when_returned_id_token_is_forged()
    {
        // Server response is tampered with an id_token signed by a different secret.
        var forgedToken = GenerateHs256Token(Guid.NewGuid().ToString("N"));
        var client = CreateClientReturningIdToken(forgedToken);

        Func<Task> act = () => client.GetTokenAsync(new TokenExchangeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = Guid.NewGuid().ToString("N"),
            SubjectToken = SubjectToken,
            SubjectTokenType = CteProfile,
            SigningAlgorithm = JwtSignatureAlgorithm.HS256
        });

        await act.Should().ThrowAsync<IdTokenValidationException>();
    }

    private static string GenerateHs256Token(string clientSecret)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(clientSecret));
        var factory = new JwtTokenFactory(key, SecurityAlgorithms.HmacSha256);
        return factory.GenerateToken($"https://{Domain}/", ClientId, "auth0|test-user");
    }

    private static AuthenticationApiClient CreateClientReturningIdToken(string idToken)
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "exchanged-access-token",
            TokenType = "Bearer",
            ExpiresIn = 86400,
            IssuedTokenType = TokenType.AccessToken,
            IdToken = idToken
        };

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
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    JsonSerializer.Serialize(response),
                    Encoding.UTF8,
                    "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        return new TestAuthenticationApiClient(Domain, new TestHttpClientAuthenticationConnection(httpClient));
    }
}
