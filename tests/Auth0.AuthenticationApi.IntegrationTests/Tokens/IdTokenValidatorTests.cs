using Auth0.AuthenticationApi.Tokens;
using Auth0.Tests.Shared;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests.Tokens
{
    public class IdTokenValidatorUnitTests : TestBase
    {
        static readonly IdTokenValidator idTokenValidator = new IdTokenValidator();
        static readonly DateTime tokensWereValid = new DateTime(2019, 9, 9, 10, 00, 00, DateTimeKind.Utc);

        static readonly IdTokenRequirements defaultReqs =
            new IdTokenRequirements(JwtSignatureAlgorithm.HS256, "https://auth0-dotnet-integration-tests.auth0.com/", "tokens-test-123", TimeSpan.FromMinutes(1))
            {
                Nonce = "a1b2c3d4e5",
                MaxAge = TimeSpan.FromSeconds(100)
            };

        private Task ValidateToken(string token)
        {
            return idTokenValidator.Assert(defaultReqs, token, GetVariable("AUTH0_CLIENT_SECRET"), tokensWereValid);
        }

        [Fact]
        public async Task ThrowsWhenIdTokenIsNull()
        {
            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(null));
            Assert.Equal("ID token is required but missing.", ex.Message);
        }

        [Fact]
        public async Task ThrowsWhenIdTokenIsEmpty()
        {
            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(""));
            Assert.Equal("ID token is required but missing.", ex.Message);
        }

        [Fact]
        public async Task ThrowsWhenIdTokenIsWhitespace()
        {
            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken("  "));
            Assert.Equal("ID token is required but missing.", ex.Message);
        }

        [Fact]
        public async Task ThrowsWhenIdTokenCanNotBeDecoded()
        {
            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken("@#$?Not A Valid Token@#$!"));
            Assert.Equal("ID token could not be decoded.", ex.Message);
        }

        [Fact]
        public async Task ThrowsWhenAlgIsNone()
        {
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJub25lIiwia2lkIjoiTWpBeU1qZzNNakUxUXpZeE1qaEZSRUpHT0VGRVJEYzNOVGhFT0RZM1FqTXdRVFJHTnpSR1FRIn17Im5pY2tuYW1lIjoiZGFtaWVuZyt0ZXN0NDIiLCJuYW1lIjoiZGFtaWVuZyt0ZXN0NDJAZ21haWwuY29tIiwicGljdHVyZSI6Imh0dHBzOi8vcy5ncmF2YXRhci5jb20vYXZhdGFyLzUzMWIwMmRhOWU5ZWM3ODdkMGUxYTU3MDVjNDRjNTY2P3M9NDgwJnI9cGcmZD1odHRwcyUzQSUyRiUyRmNkbi5hdXRoMC5jb20lMkZhdmF0YXJzJTJGZGEucG5nIiwidXBkYXRlZF9hdCI6IjIwMTktMTEtMDFUMTc6NDQ6MTYuNjk1WiIsImVtYWlsIjoiZGFtaWVuZyt0ZXN0NDJAZ21haWwuY29tIiwiZW1haWxfdmVyaWZpZWQiOmZhbHNlLCJpc3MiOiJodHRwczovL2F1dGgwLWRvdG5ldC1pbnRlZ3JhdGlvbi10ZXN0cy5hdXRoMC5jb20vIiwic3ViIjoiYXV0aDB8NWRhNjQ1M2MxMjJmYjYwYTkyNGU5MjYxIiwiYXVkIjoicW1zczlBNjZzdFBXVE9YalI2WDFPZUEwRExhZG9OUDIiLCJpYXQiOjE1NzI2MzAyNTYsImV4cCI6MTU3MjY2NjI1Niwibm9uY2UiOiJTT3JIT2F1OXEwaXR4NGlURl9pWDJ3In0";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("ID token could not be decoded.", ex.Message);
        }

        [Fact]
        public async Task ThrowsWhenAlgIsInvalid()
        {
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzM4NCIsImtpZCI6Ik1qQXlNamczTWpFMVF6WXhNamhGUkVKR09FRkVSRGMzTlRoRU9EWTNRak13UVRSR056UkdRUSJ9.eyJuaWNrbmFtZSI6ImRhbWllbmcrdGVzdDQyIiwibmFtZSI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci81MzFiMDJkYTllOWVjNzg3ZDBlMWE1NzA1YzQ0YzU2Nj9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmRhLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDE5LTExLTAxVDE3OjQ0OjE2LjY5NVoiLCJlbWFpbCI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiaXNzIjoiaHR0cHM6Ly9hdXRoMC1kb3RuZXQtaW50ZWdyYXRpb24tdGVzdHMuYXV0aDAuY29tLyIsInN1YiI6ImF1dGgwfDVkYTY0NTNjMTIyZmI2MGE5MjRlOTI2MSIsImF1ZCI6InFtc3M5QTY2c3RQV1RPWGpSNlgxT2VBMERMYWRvTlAyIiwiaWF0IjoxNTcyNjMwMjU2LCJleHAiOjE1NzI2NjYyNTYsIm5vbmNlIjoiU09ySE9hdTlxMGl0eDRpVEZfaVgydyJ9.BzExZLcshNIpEGhB2NasfgjHMD3LQ21wDt3TAc2JMeYqU-c2WUYk3mzJ6ns55_60";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Signature algorithm of \"HS384\" is not supported. Expected the ID token to be signed with \"HS256\".", ex.Message);
        }
    }
}
