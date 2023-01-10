using System;
using Auth0.AuthenticationApi.Models;
using System.Threading.Tasks;
using Xunit;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using FluentAssertions;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Auth0.AuthenticationApi.IntegrationTests.Tokens
{
    public class JwtTokenFactoryTests
    {

        [Fact]
        public void Can_generate_a_token()
        {
            var key = new RsaSecurityKey(new RSACryptoServiceProvider(2048));

            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.RsaSha256);

            var token = tokenFactory.GenerateToken("test_issuer", "test_audience", "test_sub");

            token.Should().NotBeNull();
        }

        [Fact]
        public void Can_generate_a_token_with_the_correct_claims()
        {
            var key = new RsaSecurityKey(new RSACryptoServiceProvider(2048));

            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.RsaSha256);

            var token = tokenFactory.GenerateToken("test_issuer", "test_audience", "test_sub");

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            var issuer = jwtSecurityToken.Claims.First(claim => claim.Type == "iss").Value;
            var audience = jwtSecurityToken.Claims.First(claim => claim.Type == "aud").Value;
            var sub = jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value;
            var jti = jwtSecurityToken.Claims.First(claim => claim.Type == "jti").Value;

            issuer.Should().Be("test_issuer");
            audience.Should().Be("test_audience");
            sub.Should().Be("test_sub");
            jti.Should().NotBeNull();
        }

        [Fact]
        public void Can_generate_a_token_with_the_correct_signature()
        {
            var key = new RsaSecurityKey(new RSACryptoServiceProvider(2048));

            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.RsaSha256);

            var token = tokenFactory.GenerateToken("test_issuer", "test_audience", "test_sub");

            var handler = new JwtSecurityTokenHandler();
            var principal = handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = "test_audience",
                ValidateIssuer = true,
                ValidIssuer = "test_issuer",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key
            }, out _);

            principal.Should().NotBeNull();
        }
    }
}

