using System.Security.Cryptography;
using System.Text;
using Auth0.AuthenticationApi.Tokens;
using Auth0.Tests.Shared;
using Microsoft.IdentityModel.Tokens;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests.Tokens
{
    public class SymmetricSignedDecoderTests : TestBase
    {
        readonly SignedDecoder hs256Verifier = new SymmetricSignedDecoder("AUTH0_VALID_CLIENT_SECRET");

        [Fact]
        public void SucceedsWhenSignatureIsValid()
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("AUTH0_VALID_CLIENT_SECRET"));

            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.HmacSha256Signature);

            var token = tokenFactory.GenerateToken("test_issuer", "test_audience", "test_sub");

            hs256Verifier.DecodeSignedToken(token);
        }

        [Fact]
        public void ThrowsWhenSignatureIsInvalid()
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("AUTH0_INVALID_CLIENT_SECRET"));

            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.HmacSha256Signature);

            var token = tokenFactory.GenerateToken("test_issuer", "test_audience", "test_sub");

            var ex = Assert.Throws<IdTokenValidationException>(() => hs256Verifier.DecodeSignedToken(token));
        }

        [Fact]
        public void ThrowsWhenRS256()
        {
            var key = new RsaSecurityKey(new RSACryptoServiceProvider(2048));

            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.RsaSha256);

            var token = tokenFactory.GenerateToken("test_issuer", "test_audience", "test_sub");

            var ex = Assert.Throws<IdTokenValidationException>(() => hs256Verifier.DecodeSignedToken(token));
            Assert.Equal("Signature algorithm of \"RS256\" is not supported. Expected the ID token to be signed with \"HS256\".", ex.Message);
        }
    }
}
