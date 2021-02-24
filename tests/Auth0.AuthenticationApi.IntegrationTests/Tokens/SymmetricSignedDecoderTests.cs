using Auth0.AuthenticationApi.Tokens;
using Auth0.Tests.Shared;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests.Tokens
{
    public class SymmetricSignedDecoderTests : TestBase
    {
        readonly SignedDecoder hs256Verifier = new SymmetricSignedDecoder(GetVariable("AUTH0_HS256_CLIENT_SECRET"));

        [Fact]
        public void SucceedsWhenSignatureIsValid()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuaWNrbmFtZSI6ImZyZWRlcmlrLnByaWpjayIsIm5hbWUiOiJmcmVkZXJpay5wcmlqY2tAYXV0aDAuY29tIiwicGljdHVyZSI6Imh0dHBzOi8vcy5ncmF2YXRhci5jb20vYXZhdGFyL2I3NGZjNjJmYmFmMmE5M2QxZGIzYzU0OWY2MmQ0ZDlhP3M9NDgwJnI9cGcmZD1odHRwcyUzQSUyRiUyRmNkbi5hdXRoMC5jb20lMkZhdmF0YXJzJTJGZnIucG5nIiwidXBkYXRlZF9hdCI6IjIwMjEtMDItMjRUMTQ6MzU6NDMuNDk2WiIsImVtYWlsIjoiZnJlZGVyaWsucHJpamNrQGF1dGgwLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiaXNzIjoiaHR0cHM6Ly9keC1zZGtzLXRlc3RpbmcudXMuYXV0aDAuY29tLyIsInN1YiI6ImF1dGgwfDYwMzY2NDFmMDdjM2NkMDA2ODUwZDZlNCIsImF1ZCI6Inc2VVJlQ0RuUjdoVndUaEUzQkVNdjl0MVM4THR1UzZJIiwiaWF0IjoxNjE0MTc3MzQzLCJleHAiOjE2MTQyMTMzNDN9.wSJ6EzGm9yf1zQHChlvn9quTxA4t6eLxj1atmxnOQE0";
            hs256Verifier.DecodeSignedToken(token);
        }

        [Fact]
        public void ThrowsWhenSignatureIsInvalid()
        {
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiIsImtpZCI6Ik1qQXlNamczTWpFMVF6WXhNamhGUkVKR09FRkVSRGMzTlRoRU9EWTNRak13UVRSR056UkdRUSJ9.eyJuaWNrbmFtZSI6ImRhbWllbmcrdGVzdDQyIiwibmFtZSI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci81MzFiMDJkYTllOWVjNzg3ZDBlMWE1NzA1YzQ0YzU2Nj9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmRhLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDE5LTExLTAxVDE3OjQ0OjE2LjY5NVoiLCJlbWFpbCI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiaXNzIjoiaHR0cHM6Ly9hdXRoMC1kb3RuZXQtaW50ZWdyYXRpb24tdGVzdHMuYXV0aDAuY29tLyIsInN1YiI6ImF1dGgwfDVkYTY0NTNjMTIyZmI2MGE5MjRlOTI2MSIsImF1ZCI6InFtc3M5QTY2c3RQV1RPWGpSNlgxT2VBMERMYWRvTlAyIiwiaWF0IjoxNTcyNjMwMjU2LCJleHAiOjE1NzI2NjYyNTYsIm5vbmNlIjoiU09ySE9hdTlxMGl0eDRpVEZfaVgydyJ9.ek1FlyRofSAeAFe9McmwVwEwXGY48KcYRNPtmTyvjqQ";

            var ex = Assert.Throws<IdTokenValidationKeyMissingException>(() => hs256Verifier.DecodeSignedToken(token));
        }

        [Fact]
        public void ThrowsWhenRS256()
        {
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik1qQXlNamczTWpFMVF6WXhNamhGUkVKR09FRkVSRGMzTlRoRU9EWTNRak13UVRSR056UkdRUSJ9.eyJuaWNrbmFtZSI6ImRhbWllbmcrdGVzdDQyIiwibmFtZSI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci81MzFiMDJkYTllOWVjNzg3ZDBlMWE1NzA1YzQ0YzU2Nj9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmRhLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDE5LTExLTAxVDE3OjQ0OjE2LjY5NVoiLCJlbWFpbCI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiaXNzIjoiaHR0cHM6Ly9hdXRoMC1kb3RuZXQtaW50ZWdyYXRpb24tdGVzdHMuYXV0aDAuY29tLyIsInN1YiI6ImF1dGgwfDVkYTY0NTNjMTIyZmI2MGE5MjRlOTI2MSIsImF1ZCI6InFtc3M5QTY2c3RQV1RPWGpSNlgxT2VBMERMYWRvTlAyIiwiaWF0IjoxNTcyNjMwMjU2LCJleHAiOjE1NzI2NjYyNTYsIm5vbmNlIjoiU09ySE9hdTlxMGl0eDRpVEZfaVgydyJ9.NomT02whkH42ISpcd_JvG4ZvQQhzPKfoWCwcgrhyLeWmnmHTo704WtsnfCqR72uw26D-ZGA5n2Yu4Jdcv2A8_leGEQm3p45-ramIDwWUu2J30m_op_5I4wFvgpbRrWSrD1_3qK1GrDnrdv8psGL8VgCf3pLLDbqbkzDmtE6OtEfDp2hEFwXs9YntREXu5Z-ufFFLz9VU5uyRg7JA95YGQNIRhzMFoUNKZAO19nrBq3HKc_iR_W9g9Y3iLPLgVVazq6zHjn3cXNKpr7JN6MUKqIB-YYJ1KDEvmaMO60xs2DAhhnkUN1OhXBLTgQ9xbCJeaxE7N48YMxPAu3HHT-rhZg";

            var ex = Assert.Throws<IdTokenValidationException>(() => hs256Verifier.DecodeSignedToken(token));
            Assert.Equal("Signature algorithm of \"RS256\" is not supported. Expected the ID token to be signed with \"HS256\".", ex.Message);
        }
    }
}
