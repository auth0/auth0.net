using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Auth0.AuthenticationApi.Models;
using Auth0.AuthenticationApi.Tokens;
using Auth0.Tests.Shared;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests.Tokens;

public class AuthorizationCodeNonceValidationTests
{
    private const string Issuer = "https://tokens-test.auth0.com/";
    private const string ClientId = "tokens-test-123";
    private const string Subject = "auth0|test-user";
    private const string CorrectNonce = "abc123nonce";
    private const string WrongNonce = "wrong-nonce-xyz";

    // RSA key pair used to sign test tokens — generated once per test class.
    private static readonly RsaSecurityKey RsaKey = new(new RSACryptoServiceProvider(2048));
    private static readonly JwtTokenFactory TokenFactory = new(RsaKey, SecurityAlgorithms.RsaSha256);

    /// <summary>
    /// Builds a mock HttpMessageHandler that returns a token endpoint response
    /// containing the given idToken.
    /// </summary>
    private static Mock<HttpMessageHandler> BuildMockHandlerReturning(string idToken)
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var tokenResponseJson = JsonConvert.SerializeObject(new
        {
            access_token = "some-access-token",
            token_type = "Bearer",
            expires_in = 86400,
            id_token = idToken
        });

        // Return a new HttpResponseMessage (with a fresh StringContent) on each call
        // to avoid ObjectDisposedException when the handler is invoked more than once.
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(() => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(tokenResponseJson, Encoding.UTF8, "application/json")
            });

        return mockHandler;
    }

    /// <summary>
    /// Builds a TestAuthenticationApiClient backed by the given mock handler.
    /// The domain matches the Issuer so that signature validation resolves correctly.
    /// We pass the RSA public key directly via a custom OIDC document retriever shim.
    /// Since RS256 validation fetches keys from the OIDC discovery endpoint, we test
    /// nonce wiring via HS256 (symmetric) which doesn't require a key fetch.
    /// </summary>
    private static TestAuthenticationApiClient BuildClient(HttpMessageHandler handler)
    {
        // Strip trailing slash for domain
        var domain = Issuer.TrimEnd('/').Replace("https://", "");
        return new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(handler));
    }

    /// <summary>
    /// Generates an HS256 ID token (no external key fetch needed).
    /// </summary>
    private static string GenerateHs256Token(string nonce, string clientSecret)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(clientSecret));
        var factory = new JwtTokenFactory(key, SecurityAlgorithms.HmacSha256);
        var claims = nonce != null
            ? new List<Claim> { new(JwtRegisteredClaimNames.Nonce, nonce) }
            : null;
        return factory.GenerateToken(Issuer, ClientId, Subject, claims);
    }

    /// <summary>
    /// Generates an RS256 ID token signed with the shared RSA key.
    /// Used for flows (e.g. device code) that have no client secret and therefore
    /// cannot use HS256.
    /// </summary>
    private static string GenerateRs256Token(string nonce)
    {
        var claims = nonce != null
            ? new List<Claim> { new(JwtRegisteredClaimNames.Nonce, nonce) }
            : null;
        return TokenFactory.GenerateToken(Issuer, ClientId, Subject, claims);
    }

    /// <summary>
    /// Builds a mock handler that responds to the token endpoint (POST) plus the
    /// OIDC discovery and JWKS endpoints (GET) required for RS256 signature validation.
    /// </summary>
    private static Mock<HttpMessageHandler> BuildMockHandlerWithDiscovery(string idToken)
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        var tokenResponseJson = JsonConvert.SerializeObject(new
        {
            access_token = "some-access-token",
            token_type = "Bearer",
            expires_in = 86400,
            id_token = idToken
        });

        var rsaParams = RsaKey.Rsa.ExportParameters(false);
        var jwksJson = JsonConvert.SerializeObject(new
        {
            keys = new[]
            {
                new
                {
                    kty = "RSA",
                    n = Base64UrlEncoder.Encode(rsaParams.Modulus),
                    e = Base64UrlEncoder.Encode(rsaParams.Exponent)
                }
            }
        });

        var discoveryJson = JsonConvert.SerializeObject(new
        {
            issuer = Issuer,
            jwks_uri = $"{Issuer}.well-known/jwks.json"
        });

        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Post),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(() => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(tokenResponseJson, Encoding.UTF8, "application/json")
            });

        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.AbsolutePath.Contains("openid-configuration")),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(() => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(discoveryJson, Encoding.UTF8, "application/json")
            });

        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.AbsolutePath.Contains("jwks")),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(() => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jwksJson, Encoding.UTF8, "application/json")
            });

        return mockHandler;
    }

    [Fact]
    public async Task GetTokenAsync_AuthorizationCode_ThrowsWhenNonceSetAndTokenHasMismatchedNonce()
    {
        var clientSecret = Guid.NewGuid().ToString("N");
        // Token contains the WRONG nonce — should be rejected when request.Nonce is set.
        var idToken = GenerateHs256Token(WrongNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() =>
            client.GetTokenAsync(new AuthorizationCodeTokenRequest
            {
                ClientId = ClientId,
                ClientSecret = clientSecret,
                Code = "some-code",
                RedirectUri = "https://app.example.com/callback",
                SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                Nonce = CorrectNonce  // caller supplies the nonce they sent to /authorize
            }));

        Assert.Equal(
            $"Nonce (nonce) claim mismatch in the ID token; expected \"{CorrectNonce}\", found \"{WrongNonce}\".",
            ex.Message);
    }

    [Fact]
    public async Task GetTokenAsync_AuthorizationCode_ThrowsWhenNonceSetAndTokenHasNoNonceClaim()
    {
        var clientSecret = Guid.NewGuid().ToString("N");
        // Token has NO nonce claim — should be rejected when request.Nonce is set.
        var idToken = GenerateHs256Token(null, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() =>
            client.GetTokenAsync(new AuthorizationCodeTokenRequest
            {
                ClientId = ClientId,
                ClientSecret = clientSecret,
                Code = "some-code",
                RedirectUri = "https://app.example.com/callback",
                SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                Nonce = CorrectNonce
            }));

        Assert.Equal("Nonce (nonce) claim must be a string present in the ID token.", ex.Message);
    }

    [Fact]
    public async Task GetTokenAsync_AuthorizationCode_SucceedsWhenNonceSetAndTokenNonceMatches()
    {
        var clientSecret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(CorrectNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        // Should not throw.
        var result = await client.GetTokenAsync(new AuthorizationCodeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = clientSecret,
            Code = "some-code",
            RedirectUri = "https://app.example.com/callback",
            SigningAlgorithm = JwtSignatureAlgorithm.HS256,
            Nonce = CorrectNonce
        });

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetTokenAsync_AuthorizationCode_SucceedsWhenNoNonceSetEvenIfTokenHasNonceClaim()
    {
        // Backward compatibility: if caller doesn't set Nonce, nonce validation is skipped
        // even if the token happens to contain a nonce claim.
        var clientSecret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(CorrectNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var result = await client.GetTokenAsync(new AuthorizationCodeTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = clientSecret,
            Code = "some-code",
            RedirectUri = "https://app.example.com/callback",
            SigningAlgorithm = JwtSignatureAlgorithm.HS256
            // Nonce not set — opt-in behaviour
        });

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetTokenAsync_AuthorizationCodePkce_ThrowsWhenNonceSetAndTokenHasMismatchedNonce()
    {
        var clientSecret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(WrongNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() =>
            client.GetTokenAsync(new AuthorizationCodePkceTokenRequest
            {
                ClientId = ClientId,
                ClientSecret = clientSecret,
                Code = "some-code",
                CodeVerifier = "some-code-verifier",
                RedirectUri = "https://app.example.com/callback",
                SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                Nonce = CorrectNonce
            }));

        Assert.Equal(
            $"Nonce (nonce) claim mismatch in the ID token; expected \"{CorrectNonce}\", found \"{WrongNonce}\".",
            ex.Message);
    }

    [Fact]
    public async Task GetTokenAsync_AuthorizationCodePkce_SucceedsWhenNoNonceSetEvenIfTokenHasNonceClaim()
    {
        // Backward compatibility: if caller doesn't set Nonce, nonce validation is skipped
        // even if the token happens to contain a nonce claim.
        var clientSecret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(CorrectNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var result = await client.GetTokenAsync(new AuthorizationCodePkceTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = clientSecret,
            Code = "some-code",
            CodeVerifier = "some-code-verifier",
            RedirectUri = "https://app.example.com/callback",
            SigningAlgorithm = JwtSignatureAlgorithm.HS256
            // Nonce not set — opt-in behaviour
        });

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetTokenAsync_AuthorizationCode_ThrowsWhenNonceDiffersOnlyInCase()
    {
        // Nonce comparison must be case-sensitive per OpenID Connect spec.
        var clientSecret = Guid.NewGuid().ToString("N");
        var upperNonce = CorrectNonce.ToUpperInvariant();
        var idToken = GenerateHs256Token(upperNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() =>
            client.GetTokenAsync(new AuthorizationCodeTokenRequest
            {
                ClientId = ClientId,
                ClientSecret = clientSecret,
                Code = "some-code",
                RedirectUri = "https://app.example.com/callback",
                SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                Nonce = CorrectNonce  // lowercase — token has uppercase
            }));

        Assert.Equal(
            $"Nonce (nonce) claim mismatch in the ID token; expected \"{CorrectNonce}\", found \"{upperNonce}\".",
            ex.Message);
    }

    // ──────────────────────────────────────────────────────────────────────────
    // RefreshTokenRequest
    // ──────────────────────────────────────────────────────────────────────────

    [Fact]
    public async Task GetTokenAsync_RefreshToken_ThrowsWhenNonceSetAndTokenHasMismatchedNonce()
    {
        var clientSecret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(WrongNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() =>
            client.GetTokenAsync(new RefreshTokenRequest
            {
                ClientId = ClientId,
                ClientSecret = clientSecret,
                RefreshToken = "some-refresh-token",
                SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                Nonce = CorrectNonce
            }));

        Assert.Equal(
            $"Nonce (nonce) claim mismatch in the ID token; expected \"{CorrectNonce}\", found \"{WrongNonce}\".",
            ex.Message);
    }

    [Fact]
    public async Task GetTokenAsync_RefreshToken_SucceedsWhenNoNonceSetEvenIfTokenHasNonceClaim()
    {
        var clientSecret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(CorrectNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var result = await client.GetTokenAsync(new RefreshTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = clientSecret,
            RefreshToken = "some-refresh-token",
            SigningAlgorithm = JwtSignatureAlgorithm.HS256
            // Nonce not set — opt-in behaviour
        });

        Assert.NotNull(result);
    }

    // ──────────────────────────────────────────────────────────────────────────
    // ResourceOwnerTokenRequest
    // ──────────────────────────────────────────────────────────────────────────

    [Fact]
    public async Task GetTokenAsync_ResourceOwner_ThrowsWhenNonceSetAndTokenHasMismatchedNonce()
    {
        var clientSecret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(WrongNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() =>
            client.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = ClientId,
                ClientSecret = clientSecret,
                Username = "user@example.com",
                Password = "password",
                Scope = "openid",
                SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                Nonce = CorrectNonce
            }));

        Assert.Equal(
            $"Nonce (nonce) claim mismatch in the ID token; expected \"{CorrectNonce}\", found \"{WrongNonce}\".",
            ex.Message);
    }

    [Fact]
    public async Task GetTokenAsync_ResourceOwner_SucceedsWhenNoNonceSetEvenIfTokenHasNonceClaim()
    {
        var clientSecret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(CorrectNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var result = await client.GetTokenAsync(new ResourceOwnerTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = clientSecret,
            Username = "user@example.com",
            Password = "password",
            Scope = "openid",
            SigningAlgorithm = JwtSignatureAlgorithm.HS256
            // Nonce not set — opt-in behaviour
        });

        Assert.NotNull(result);
    }

    // ──────────────────────────────────────────────────────────────────────────
    // PasswordlessEmailTokenRequest
    // ──────────────────────────────────────────────────────────────────────────

    [Fact]
    public async Task GetTokenAsync_PasswordlessEmail_ThrowsWhenNonceSetAndTokenHasMismatchedNonce()
    {
        var clientSecret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(WrongNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() =>
            client.GetTokenAsync(new PasswordlessEmailTokenRequest
            {
                ClientId = ClientId,
                ClientSecret = clientSecret,
                Email = "user@example.com",
                Code = "123456",
                Audience = "https://api.example.com",
                Scope = "openid",
                SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                Nonce = CorrectNonce
            }));

        Assert.Equal(
            $"Nonce (nonce) claim mismatch in the ID token; expected \"{CorrectNonce}\", found \"{WrongNonce}\".",
            ex.Message);
    }

    [Fact]
    public async Task GetTokenAsync_PasswordlessEmail_SucceedsWhenNoNonceSetEvenIfTokenHasNonceClaim()
    {
        var clientSecret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(CorrectNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var result = await client.GetTokenAsync(new PasswordlessEmailTokenRequest
        {
            ClientId = ClientId,
            ClientSecret = clientSecret,
            Email = "user@example.com",
            Code = "123456",
            Audience = "https://api.example.com",
            Scope = "openid",
            SigningAlgorithm = JwtSignatureAlgorithm.HS256
            // Nonce not set — opt-in behaviour
        });

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetTokenAsync_AuthorizationCode_ThrowsWhenNonceSetToEmptyString()
    {
        // An empty string is not the same as null — the validator checks `!= null` to
        // decide whether to validate, so an empty Nonce triggers validation and will
        // always fail because no token will carry an empty nonce claim.
        var clientSecret = Guid.NewGuid().ToString("N");
        var idToken = GenerateHs256Token(CorrectNonce, clientSecret);

        var mockHandler = BuildMockHandlerReturning(idToken);
        using var client = BuildClient(mockHandler.Object);

        var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() =>
            client.GetTokenAsync(new AuthorizationCodeTokenRequest
            {
                ClientId = ClientId,
                ClientSecret = clientSecret,
                Code = "some-code",
                RedirectUri = "https://app.example.com/callback",
                SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                Nonce = string.Empty
            }));

        Assert.Equal(
            $"Nonce (nonce) claim mismatch in the ID token; expected \"\", found \"{CorrectNonce}\".",
            ex.Message);
    }
}
