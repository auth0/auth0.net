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
using Auth0.Tests.Shared;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class OnBehalfOfTokenExchangeTests
{
    private static string Base64UrlEncode(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }

    // Builds an UNSIGNED JWT-shaped string (header.payload.sig) for decode tests.
    private static string CreateJwt(string payloadJson)
    {
        return $"{Base64UrlEncode("{\"alg\":\"none\"}")}.{Base64UrlEncode(payloadJson)}.sig";
    }

    [Fact]
    public void Actor_deserializes_nested_act_structure()
    {
        var json = "{\"sub\":\"mcp_server\",\"act\":{\"sub\":\"spa_client\"}}";

        var actor = JsonSerializer.Deserialize<Actor>(json);

        actor.Should().NotBeNull();
        actor!.Subject.Should().Be("mcp_server");
        actor.Act.Should().NotBeNull();
        actor.Act!.Subject.Should().Be("spa_client");
        actor.Act.Act.Should().BeNull();
    }

    [Fact]
    public void GetCurrentActor_returns_outermost_act_sub_for_single_exchange()
    {
        var token = CreateJwt("{\"sub\":\"auth0|user123\",\"act\":{\"sub\":\"mcp_server\"}}");
        var response = new OnBehalfOfTokenResponse { AccessToken = token };

        response.GetCurrentActor().Should().Be("mcp_server");
    }

    [Fact]
    public void GetCurrentActor_returns_outermost_act_sub_for_chained_exchange()
    {
        var token = CreateJwt(
            "{\"sub\":\"auth0|user123\",\"act\":{\"sub\":\"mcp_server_2\",\"act\":{\"sub\":\"mcp_server_1\",\"act\":{\"sub\":\"spa_client\"}}}}");
        var response = new OnBehalfOfTokenResponse { AccessToken = token };

        response.GetCurrentActor().Should().Be("mcp_server_2");
    }

    [Fact]
    public void GetDelegationChain_returns_full_nested_chain()
    {
        var token = CreateJwt(
            "{\"sub\":\"auth0|user123\",\"act\":{\"sub\":\"mcp_server_2\",\"act\":{\"sub\":\"mcp_server_1\",\"act\":{\"sub\":\"spa_client\"}}}}");
        var response = new OnBehalfOfTokenResponse { AccessToken = token };

        var chain = response.GetDelegationChain();

        chain.Should().NotBeNull();
        chain!.Subject.Should().Be("mcp_server_2");
        chain.Act!.Subject.Should().Be("mcp_server_1");
        chain.Act.Act!.Subject.Should().Be("spa_client");
        chain.Act.Act.Act.Should().BeNull();
    }

    [Fact]
    public void GetCurrentActor_reflects_reassigned_access_token()
    {
        var response = new OnBehalfOfTokenResponse
        {
            AccessToken = CreateJwt("{\"sub\":\"auth0|user123\",\"act\":{\"sub\":\"first\"}}")
        };

        response.GetCurrentActor().Should().Be("first");

        // Reassigning the token must invalidate the cached actor.
        response.AccessToken = CreateJwt("{\"sub\":\"auth0|user123\",\"act\":{\"sub\":\"second\"}}");

        response.GetCurrentActor().Should().Be("second");
    }

    [Fact]
    public void Reassigning_from_act_to_no_act_token_invalidates_cache_to_null()
    {
        var response = new OnBehalfOfTokenResponse
        {
            AccessToken = CreateJwt("{\"sub\":\"auth0|user123\",\"act\":{\"sub\":\"first\"}}")
        };

        response.GetCurrentActor().Should().Be("first");
        response.GetDelegationChain().Should().NotBeNull();

        response.AccessToken = CreateJwt("{\"sub\":\"auth0|user123\"}");

        response.GetCurrentActor().Should().BeNull();
        response.GetDelegationChain().Should().BeNull();
    }

    [Fact]
    public void Reassigning_from_no_act_to_act_token_populates_cache()
    {
        var response = new OnBehalfOfTokenResponse
        {
            AccessToken = CreateJwt("{\"sub\":\"auth0|user123\"}")
        };

        response.GetCurrentActor().Should().BeNull();

        response.AccessToken = CreateJwt("{\"sub\":\"auth0|user123\",\"act\":{\"sub\":\"later\"}}");

        response.GetCurrentActor().Should().Be("later");
    }

    [Fact]
    public void Reassigning_to_equal_content_but_different_instance_returns_correct_value()
    {
        var payload = "{\"sub\":\"auth0|user123\",\"act\":{\"sub\":\"actor\"}}";
        var response = new OnBehalfOfTokenResponse { AccessToken = CreateJwt(payload) };

        response.GetCurrentActor().Should().Be("actor");

        // A distinct string instance with identical content (a redundant re-parse, but the
        // result must still be correct — never a mismatched/stale actor).
        response.AccessToken = CreateJwt(payload);

        response.GetCurrentActor().Should().Be("actor");
    }

    [Fact]
    public void GetCurrentActor_and_GetDelegationChain_are_consistent_across_repeated_calls()
    {
        var response = new OnBehalfOfTokenResponse
        {
            AccessToken = CreateJwt(
                "{\"sub\":\"auth0|user123\",\"act\":{\"sub\":\"outer\",\"act\":{\"sub\":\"inner\"}}}")
        };

        // Repeated calls (served from the cache after the first parse) stay consistent.
        for (var i = 0; i < 3; i++)
        {
            response.GetCurrentActor().Should().Be("outer");
            response.GetDelegationChain()!.Subject.Should().Be("outer");
            response.GetDelegationChain()!.Act!.Subject.Should().Be("inner");
        }
    }

    [Fact]
    public void Concurrent_readers_on_a_stable_token_all_observe_the_correct_actor()
    {
        var response = new OnBehalfOfTokenResponse
        {
            AccessToken = CreateJwt("{\"sub\":\"auth0|user123\",\"act\":{\"sub\":\"concurrent_actor\"}}")
        };

        // Exercise the first-parse race: many threads read simultaneously. The atomically
        // published cache must yield a consistent (token, actor) pair with no exceptions.
        var results = new System.Collections.Concurrent.ConcurrentBag<string?>();

        Parallel.For(0, 200, _ =>
        {
            results.Add(response.GetCurrentActor());
            response.GetDelegationChain()!.Subject.Should().Be("concurrent_actor");
        });

        results.Should().HaveCount(200);
        results.Should().OnlyContain(actor => actor == "concurrent_actor");
    }

    [Fact]
    public void GetCurrentActor_and_GetDelegationChain_return_null_when_no_act_claim()
    {
        var token = CreateJwt("{\"sub\":\"auth0|user123\",\"aud\":\"https://api.acme.com\"}");
        var response = new OnBehalfOfTokenResponse { AccessToken = token };

        response.GetCurrentActor().Should().BeNull();
        response.GetDelegationChain().Should().BeNull();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("not-a-jwt")]
    [InlineData("only.two")]
    [InlineData("bad!!!.payload!!!.sig")]
    public void GetCurrentActor_and_GetDelegationChain_return_null_for_malformed_token(string token)
    {
        var response = new OnBehalfOfTokenResponse { AccessToken = token };

        response.GetCurrentActor().Should().BeNull();
        response.GetDelegationChain().Should().BeNull();
    }

    [Fact]
    public void GetCurrentActor_and_GetDelegationChain_return_null_when_payload_is_invalid_json()
    {
        // Valid base64url payload segment, but the decoded bytes are not valid JSON.
        var token = $"{Base64UrlEncode("{\"alg\":\"none\"}")}.{Base64UrlEncode("not json at all")}.sig";
        var response = new OnBehalfOfTokenResponse { AccessToken = token };

        response.GetCurrentActor().Should().BeNull();
        response.GetDelegationChain().Should().BeNull();
    }

    [Fact]
    public void GetCurrentActor_and_GetDelegationChain_return_null_when_act_claim_is_not_an_object()
    {
        // act is a string, not a nested actor object -> Deserialize<Actor> throws JsonException.
        var token = CreateJwt("{\"sub\":\"auth0|user123\",\"act\":\"not-an-object\"}");
        var response = new OnBehalfOfTokenResponse { AccessToken = token };

        response.GetCurrentActor().Should().BeNull();
        response.GetDelegationChain().Should().BeNull();
    }

    [Fact]
    public void OnBehalfOfTokenRequest_implements_IClientAuthentication()
    {
        var request = new OnBehalfOfTokenRequest
        {
            SubjectToken = "user-access-token",
            Audience = "https://calendar-api.acme.com",
            Scope = "calendar:read",
            Organization = "org_123",
            ClientId = "mcp_server_client_id"
        };

        request.Should().BeAssignableTo<IClientAuthentication>();
        request.SubjectToken.Should().Be("user-access-token");
        request.Audience.Should().Be("https://calendar-api.acme.com");
    }

    private const string Domain = "test-tenant.auth0.com";
    private const string ClientId = "mcp_server_client_id";
    private const string ClientSecret = "test-client-secret";
    private const string SubjectToken = "incoming-user-access-token";
    private const string Audience = "https://calendar-api.acme.com";

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
    public async Task GetTokenOnBehalfOfAsync_sends_obo_exchange_request()
    {
        var response = new AccessTokenResponse
        {
            AccessToken = "exchanged-access-token",
            TokenType = "Bearer",
            ExpiresIn = 3600,
            Scope = "calendar:read",
            IssuedTokenType = TokenType.AccessToken
        };
        var expectedParams = new Dictionary<string, string>
        {
            { "grant_type", "urn:ietf:params:oauth:grant-type:token-exchange" },
            { "subject_token", SubjectToken },
            { "subject_token_type", TokenType.AccessToken },
            { "audience", Audience },
            { "scope", "calendar:read" },
            { "organization", "org_123" }
        };

        var client = CreateClient(response, expectedParams);

        var result = await client.GetTokenOnBehalfOfAsync(new OnBehalfOfTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            SubjectToken = SubjectToken,
            Audience = Audience,
            Scope = "calendar:read",
            Organization = "org_123"
        });

        result.Should().NotBeNull();
        result.Should().BeOfType<OnBehalfOfTokenResponse>();
        result.AccessToken.Should().Be("exchanged-access-token");
        result.TokenType.Should().Be("Bearer");
        result.ExpiresIn.Should().Be(3600);
        result.Scope.Should().Be("calendar:read");
        result.IssuedTokenType.Should().Be(TokenType.AccessToken);
    }

    [Fact]
    public async Task GetTokenOnBehalfOfAsync_throws_when_subject_token_missing()
    {
        var client = new TestAuthenticationApiClient(
            Domain, new TestHttpClientAuthenticationConnection(new HttpClient()));

        Func<Task> act = () => client.GetTokenOnBehalfOfAsync(new OnBehalfOfTokenRequest
        {
            ClientId = ClientId,
            Audience = Audience
        });

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("*SubjectToken*");
    }

    [Fact]
    public async Task GetTokenOnBehalfOfAsync_throws_when_audience_missing()
    {
        var client = new TestAuthenticationApiClient(
            Domain, new TestHttpClientAuthenticationConnection(new HttpClient()));

        Func<Task> act = () => client.GetTokenOnBehalfOfAsync(new OnBehalfOfTokenRequest
        {
            ClientId = ClientId,
            SubjectToken = SubjectToken
        });

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("*Audience*");
    }
}
