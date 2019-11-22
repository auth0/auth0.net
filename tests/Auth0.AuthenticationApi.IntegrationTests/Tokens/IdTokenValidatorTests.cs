using Auth0.AuthenticationApi.IntegrationTests.Tokens;
using Auth0.AuthenticationApi.Tokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.OidcClient.Core.UnitTests.Tokens
{
    public class IdTokenValidatorUnitTests
    {
        private static readonly DateTime tokensWereValid = new DateTime(2019, 9, 9, 10, 00, 00, DateTimeKind.Utc);
        private static readonly ISignatureVerifier rs256NoSignature = new NoSignatureVerifier(new[] { "RS256" });

        private static readonly IdTokenRequirements defaultReqs =
            new IdTokenRequirements("https://tokens-test.auth0.com/", "tokens-test-123", TimeSpan.FromMinutes(1))
            {
                Nonce = "a1b2c3d4e5",
                MaxAge = TimeSpan.FromSeconds(100)
            };

        private static readonly JsonWebKeySet signingKeys = new JsonWebKeySet("{\"keys\":[{\"alg\":\"RS256\",\"kty\":\"RSA\",\"use\":\"sig\",\"x5c\":[\"MIIDGDCCAgCgAwIBAgIJ5HpMuw46gydLMA0GCSqGSIb3DQEBBQUAMDMxMTAvBgNVBAMTKGF1dGgwLWRvdG5ldC1pbnRlZ3JhdGlvbi10ZXN0cy5hdXRoMC5jb20wHhcNMTUxMTI0MTUyNDQ1WhcNMjkwODAyMTUyNDQ1WjAzMTEwLwYDVQQDEyhhdXRoMC1kb3RuZXQtaW50ZWdyYXRpb24tdGVzdHMuYXV0aDAuY29tMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA40mvPtnD1JaKsQWG9eT+1USq31Cl5GHyv2L/TYd7Kjena0v0qHIJ2/bU7jGBRwsbnQ/mL9UJ8Uzqb9VtSU1nG1py4bBS0M6CV9zYCjHROxg5qwyHOH0AbA/LOI/83IM9jK0KFboQmmHc0roLylR6QZ8EKrFEQgHTNMpKYJh7SVnrMrXfVndpNcxnkzI4dJfLUrGtPxsKURtApi1O/5WKytCeCg1lE3EZu0QkGSsvfW7xEYI/1mXVlX9V12/SAQjrF1+u910mfKkcc/PgMnArFCILLAwKm1GqnUnWO8JpKg9N5A8c3u+54JEJMbMFHWrZyNT2qouBWfz7rm+f5Z2KvwIDAQABoy8wLTAMBgNVHRMEBTADAQH/MB0GA1UdDgQWBBSNKc1MtlkujOOp295lpZ5slrHcaDANBgkqhkiG9w0BAQUFAAOCAQEAo9Be/Qe6w4oop19KsFThlOfhLuDEPKTBqL2KlEzwKs35a42o9dalQATRx/zMeIi4stm94YNBovCNi02zpddJKso09zEkPkRoHgZ3p8K+AoWek/4pmys0Yp0WgnHfvdhstqfjFo9bHzG0noNtHFErqdt/UfiRCcRL+tWqwi8TAkgbyv+ZsddH2Xomn8HbHOAaZfiUwRhLQe6yetcDHLx9emsPENLjZRVBAz2hHDfJK7urKprMHY4Q0Jm0nlXz6/gMiJRnyD5nuZjv7DyeFPixOxptCU90zq8UbS/3fj1a1RdbBBNe5KhJjHtLrBqYAuSgwpok99qzUiLjm4fK7sZPHQ==\"],\"n\":\"40mvPtnD1JaKsQWG9eT-1USq31Cl5GHyv2L_TYd7Kjena0v0qHIJ2_bU7jGBRwsbnQ_mL9UJ8Uzqb9VtSU1nG1py4bBS0M6CV9zYCjHROxg5qwyHOH0AbA_LOI_83IM9jK0KFboQmmHc0roLylR6QZ8EKrFEQgHTNMpKYJh7SVnrMrXfVndpNcxnkzI4dJfLUrGtPxsKURtApi1O_5WKytCeCg1lE3EZu0QkGSsvfW7xEYI_1mXVlX9V12_SAQjrF1-u910mfKkcc_PgMnArFCILLAwKm1GqnUnWO8JpKg9N5A8c3u-54JEJMbMFHWrZyNT2qouBWfz7rm-f5Z2Kvw\",\"e\":\"AQAB\",\"kid\":\"MjAyMjg3MjE1QzYxMjhFREJGOEFERDc3NThEODY3QjMwQTRGNzRGQQ\",\"x5t\":\"MjAyMjg3MjE1QzYxMjhFREJGOEFERDc3NThEODY3QjMwQTRGNzRGQQ\"}]}");

        private static readonly IdTokenRequirements signedReqs =
            new IdTokenRequirements("https://auth0-dotnet-integration-tests.auth0.com/", "qmss9A66stPWTOXjR6X1OeA0DLadoNP2", TimeSpan.FromMinutes(1))
            {
                Nonce = "SOrHOau9q0itx4iTF_iX2w"
            };

        private Task ValidateToken(string token, IdTokenRequirements reqs = null, DateTime? when = null, ISignatureVerifier signatureVerifier = null)
        {
            return IdTokenValidator.AssertTokenMeetsRequirements(reqs ?? defaultReqs, token, when ?? tokensWereValid, signatureVerifier ?? rs256NoSignature);
        }

        [Fact]
        public async void ThrowsWhenIdTokenIsNull()
        {
            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(null));
            Assert.Equal("ID token is required but missing.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenIdTokenIsEmpty()
        {
            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(""));
            Assert.Equal("ID token is required but missing.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenIdTokenIsWhitespace()
        {
            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken("  "));
            Assert.Equal("ID token is required but missing.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenIdTokenCanNotBeDecoded()
        {
            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken("@#$?Not A Valid Token@#$!"));
            Assert.Equal("ID token could not be decoded.", ex.Message);
        }

        [Fact]
        public async void SucceedsWhenRS256SignatureIsValid()
        {
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik1qQXlNamczTWpFMVF6WXhNamhGUkVKR09FRkVSRGMzTlRoRU9EWTNRak13UVRSR056UkdRUSJ9.eyJuaWNrbmFtZSI6ImRhbWllbmcrdGVzdDQyIiwibmFtZSI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci81MzFiMDJkYTllOWVjNzg3ZDBlMWE1NzA1YzQ0YzU2Nj9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmRhLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDE5LTExLTAxVDE3OjQ0OjE2LjY5NVoiLCJlbWFpbCI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiaXNzIjoiaHR0cHM6Ly9hdXRoMC1kb3RuZXQtaW50ZWdyYXRpb24tdGVzdHMuYXV0aDAuY29tLyIsInN1YiI6ImF1dGgwfDVkYTY0NTNjMTIyZmI2MGE5MjRlOTI2MSIsImF1ZCI6InFtc3M5QTY2c3RQV1RPWGpSNlgxT2VBMERMYWRvTlAyIiwiaWF0IjoxNTcyNjMwMjU2LCJleHAiOjE1NzI2NjYyNTYsIm5vbmNlIjoiU09ySE9hdTlxMGl0eDRpVEZfaVgydyJ9.NomT02whkH42ISpcd_JvG4ZvQQhzPKfoWCwcgrhyLeWmnmHTo704WtsnfCqR72uw26D-ZGA5n2Yu4Jdcv2A8_leGEQm3p45-ramIDwWUu2J30m_op_5I4wFvgpbRrWSrD1_3qK1GrDnrdv8psGL8VgCf3pLLDbqbkzDmtE6OtEfDp2hEFwXs9YntREXu5Z-ufFFLz9VU5uyRg7JA95YGQNIRhzMFoUNKZAO19nrBq3HKc_iR_W9g9Y3iLPLgVVazq6zHjn3cXNKpr7JN6MUKqIB-YYJ1KDEvmaMO60xs2DAhhnkUN1OhXBLTgQ9xbCJeaxE7N48YMxPAu3HHT-rhZg";

            var rs256Verifier = new AsymmetricSignatureVerifier(signingKeys.Keys);

            await ValidateToken(token, signedReqs, when: new DateTime(2019, 11, 2, 0, 0, 00, DateTimeKind.Utc), signatureVerifier: rs256Verifier);
        }

        [Fact]
        public async void SucceedsWhenHS256SignatureIsValid()
        {
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiIsImtpZCI6Ik1qQXlNamczTWpFMVF6WXhNamhGUkVKR09FRkVSRGMzTlRoRU9EWTNRak13UVRSR056UkdRUSJ9.eyJuaWNrbmFtZSI6ImRhbWllbmcrdGVzdDQyIiwibmFtZSI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci81MzFiMDJkYTllOWVjNzg3ZDBlMWE1NzA1YzQ0YzU2Nj9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmRhLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDE5LTExLTAxVDE3OjQ0OjE2LjY5NVoiLCJlbWFpbCI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiaXNzIjoiaHR0cHM6Ly9hdXRoMC1kb3RuZXQtaW50ZWdyYXRpb24tdGVzdHMuYXV0aDAuY29tLyIsInN1YiI6ImF1dGgwfDVkYTY0NTNjMTIyZmI2MGE5MjRlOTI2MSIsImF1ZCI6InFtc3M5QTY2c3RQV1RPWGpSNlgxT2VBMERMYWRvTlAyIiwiaWF0IjoxNTcyNjMwMjU2LCJleHAiOjE1NzI2NjYyNTYsIm5vbmNlIjoiU09ySE9hdTlxMGl0eDRpVEZfaVgydyJ9.ek1FlyRofSAeAFe9McmwVwEwXGY48KcYRNPtmTyvjqQ";

            var hs256Verifier = SymmetricSignatureVerifier.FromClientSecret("777d050475b92aecef27ba02c753bd279fbb2bef0ae3a38e0da63eb5bc63466d");

            await ValidateToken(token, signedReqs, when: new DateTime(2019, 11, 2, 0, 0, 00, DateTimeKind.Utc), signatureVerifier: hs256Verifier);
        }

        [Fact]
        public async void ThrowsWhenRS256SignatureIsInvalid()
        {
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik1qQXlNamczTWpFMVF6WXhNamhGUkVKR09FRkVSRGMzTlRoRU9EWTNRak13UVRSR056UkdRUSJ9.eyJuaWNrbmFtZSI6ImRhbWllbmcrdGVzdDQyIiwibmFtZSI6ImRhbWllbmcrZmFrZUBnbWFpbC5jb20iLCJwaWN0dXJlIjoiaHR0cHM6Ly9zLmdyYXZhdGFyLmNvbS9hdmF0YXIvNTMxYjAyZGE5ZTllYzc4N2QwZTFhNTcwNWM0NGM1NjY_cz00ODAmcj1wZyZkPWh0dHBzJTNBJTJGJTJGY2RuLmF1dGgwLmNvbSUyRmF2YXRhcnMlMkZkYS5wbmciLCJ1cGRhdGVkX2F0IjoiMjAxOS0xMS0wMVQxNzo0NDoxNi42OTVaIiwiZW1haWwiOiJkYW1pZW5nK3Rlc3Q0MkBnbWFpbC5jb20iLCJlbWFpbF92ZXJpZmllZCI6ZmFsc2UsImlzcyI6Imh0dHBzOi8vYXV0aDAtZG90bmV0LWludGVncmF0aW9uLXRlc3RzLmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHw1ZGE2NDUzYzEyMmZiNjBhOTI0ZTkyNjEiLCJhdWQiOiJxbXNzOUE2NnN0UFdUT1hqUjZYMU9lQTBETGFkb05QMiIsImlhdCI6MTU3MjYzMDI1NiwiZXhwIjoxNTcyNjY2MjU2LCJub25jZSI6IlNPckhPYXU5cTBpdHg0aVRGX2lYMncifQ.oAXS_JCoVboZ0oheyQYyHbbaFQSS5wP4U2RYMnevEJNQxRWKi9wVjwUD5GpYMnhpQ_IfGaV5yld1kWgjWfg0R9bseZHPAgIRAz9dXZ-ZK2uadY4JDOLkFB5VNoTaKNTKG0gd5Rw9T2j_AABSyX0d9KP0id987OCI6GUCOAArqIZXklk2UM9-dmFH3H2IKBMRUxk2GtCw3jvrYzrSbm806JSzAihFeHYrmG0wTP243suznm21ZKhBU5a7Us1CLbGMJZ56ZUJY4IcB9zeDr87Y5b-DpG8L_5KAolNhha4GoV2G4kczEJNjwIgHADvsGUZAFNAmn-sTMygDpHIu4ZpEEQ";

            var rs256Verifier = new AsymmetricSignatureVerifier(signingKeys.Keys);

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token, signedReqs, signatureVerifier: rs256Verifier));
            Assert.Equal("Invalid ID token signature.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenHS256SignatureIsInvalid()
        {
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiIsImtpZCI6Ik1qQXlNamczTWpFMVF6WXhNamhGUkVKR09FRkVSRGMzTlRoRU9EWTNRak13UVRSR056UkdRUSJ9.eyJuaWNrbmFtZSI6ImRhbWllbmcrdGVzdDQyIiwibmFtZSI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci81MzFiMDJkYTllOWVjNzg3ZDBlMWE1NzA1YzQ0YzU2Nj9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmRhLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDE5LTExLTAxVDE3OjQ0OjE2LjY5NVoiLCJlbWFpbCI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiaXNzIjoiaHR0cHM6Ly9hdXRoMC1kb3RuZXQtaW50ZWdyYXRpb24tdGVzdHMuYXV0aDAuY29tLyIsInN1YiI6ImF1dGgwfDVkYTY0NTNjMTIyZmI2MGE5MjRlOTI2MSIsImF1ZCI6InFtc3M5QTY2c3RQV1RPWGpSNlgxT2VBMERMYWRvTlAyIiwiaWF0IjoxNTcyNjMwMjU2LCJleHAiOjE1NzI2NjYyNTYsIm5vbmNlIjoiU09ySE9hdTlxMGl0eDRpVEZfaVgydyJ9.ek1FlyRofSAeAFe9McmwVwEwXGY48KcYRNPtmTyvjqQ";

            var hs256Verifier = SymmetricSignatureVerifier.FromClientSecret("fee96dfce7ebfba9f9e489ae07ff2aaa3b06efe1710e34d92762c61182124e5b");

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token, signedReqs, signatureVerifier: hs256Verifier));

            Assert.Equal("Invalid ID token signature.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenAlgIsNone()
        {
            var token = "eyJhbGciOiJub25lIn0.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Signature algorithm of \"none\" is not supported. Expected the ID token to be signed with \"RS256\".", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenAlgIsInvalid()
        {
            var token = "eyJhbGciOiJSUzM4NCIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMn0.D4kXa3UspFjRA9ys5tsD4YDyxxam3l_XnOb3hMEdPDTfSLRHPv4HPwxvin-pIkEmfJshXPSK7O4zqSXWAXFO52X-upJjFc_gpGDswctNWpOJeXe1xBgJ--VuGDzUQCqkr9UBpN-Q7TE5u9cgIVisekSFSH5Ax6aXQC9vCO5LooNFx_WnbTLNZz7FUia9vyJ544kLB7UcacL-_idgRNIWPdd_d1vvnNGkknIMarRjCsjAEf6p5JGhYZ8_C18g-9DsfokfUfSpKgBR23R8v8ZAAmPPPiJ6MZXkefqE7p3jRbA--58z5TlHmH9nTB1DYE2872RYvyzG3LoQ-2s93VaVuw";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Signature algorithm of \"RS384\" is not supported. Expected the ID token to be signed with \"RS256\".", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenHS256OnAsymmetric()
        {
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiIsImtpZCI6Ik1qQXlNamczTWpFMVF6WXhNamhGUkVKR09FRkVSRGMzTlRoRU9EWTNRak13UVRSR056UkdRUSJ9.eyJuaWNrbmFtZSI6ImRhbWllbmcrdGVzdDQyIiwibmFtZSI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci81MzFiMDJkYTllOWVjNzg3ZDBlMWE1NzA1YzQ0YzU2Nj9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmRhLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDE5LTExLTAxVDE3OjQ0OjE2LjY5NVoiLCJlbWFpbCI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiaXNzIjoiaHR0cHM6Ly9hdXRoMC1kb3RuZXQtaW50ZWdyYXRpb24tdGVzdHMuYXV0aDAuY29tLyIsInN1YiI6ImF1dGgwfDVkYTY0NTNjMTIyZmI2MGE5MjRlOTI2MSIsImF1ZCI6InFtc3M5QTY2c3RQV1RPWGpSNlgxT2VBMERMYWRvTlAyIiwiaWF0IjoxNTcyNjMwMjU2LCJleHAiOjE1NzI2NjYyNTYsIm5vbmNlIjoiU09ySE9hdTlxMGl0eDRpVEZfaVgydyJ9.ek1FlyRofSAeAFe9McmwVwEwXGY48KcYRNPtmTyvjqQ";

            var rs256Verifier = new AsymmetricSignatureVerifier(signingKeys.Keys);

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token, signatureVerifier: rs256Verifier));
            Assert.Equal("Signature algorithm of \"HS256\" is not supported. Expected the ID token to be signed with \"RS256\".", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenRS256OnSymmetric()
        {
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik1qQXlNamczTWpFMVF6WXhNamhGUkVKR09FRkVSRGMzTlRoRU9EWTNRak13UVRSR056UkdRUSJ9.eyJuaWNrbmFtZSI6ImRhbWllbmcrdGVzdDQyIiwibmFtZSI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci81MzFiMDJkYTllOWVjNzg3ZDBlMWE1NzA1YzQ0YzU2Nj9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmRhLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDE5LTExLTAxVDE3OjQ0OjE2LjY5NVoiLCJlbWFpbCI6ImRhbWllbmcrdGVzdDQyQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiaXNzIjoiaHR0cHM6Ly9hdXRoMC1kb3RuZXQtaW50ZWdyYXRpb24tdGVzdHMuYXV0aDAuY29tLyIsInN1YiI6ImF1dGgwfDVkYTY0NTNjMTIyZmI2MGE5MjRlOTI2MSIsImF1ZCI6InFtc3M5QTY2c3RQV1RPWGpSNlgxT2VBMERMYWRvTlAyIiwiaWF0IjoxNTcyNjMwMjU2LCJleHAiOjE1NzI2NjYyNTYsIm5vbmNlIjoiU09ySE9hdTlxMGl0eDRpVEZfaVgydyJ9.NomT02whkH42ISpcd_JvG4ZvQQhzPKfoWCwcgrhyLeWmnmHTo704WtsnfCqR72uw26D-ZGA5n2Yu4Jdcv2A8_leGEQm3p45-ramIDwWUu2J30m_op_5I4wFvgpbRrWSrD1_3qK1GrDnrdv8psGL8VgCf3pLLDbqbkzDmtE6OtEfDp2hEFwXs9YntREXu5Z-ufFFLz9VU5uyRg7JA95YGQNIRhzMFoUNKZAO19nrBq3HKc_iR_W9g9Y3iLPLgVVazq6zHjn3cXNKpr7JN6MUKqIB-YYJ1KDEvmaMO60xs2DAhhnkUN1OhXBLTgQ9xbCJeaxE7N48YMxPAu3HHT-rhZg";

            var hs256Verifier = SymmetricSignatureVerifier.FromClientSecret("fee96dfce7ebfba9f9e489ae07ff2aaa3b06efe1710e34d92762c61182124e5b");

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token, signatureVerifier: hs256Verifier));
            Assert.Equal("Signature algorithm of \"RS256\" is not supported. Expected the ID token to be signed with \"HS256\".", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenIssMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.qThWXz2PspgwyGQGsobPgrNjMPhvRdgjPSijG4NSaKuAPG_E5zVGdxTAiZhhwMCvhyqVIyV7eJJ7JMM6zeXsIel6mR_rZ1BiEwW_K02jDXlhXTkIUJP2KGt7zmzTEYvTiQ5izpCOLOtg02vMBS_xaqpGqquZI6-0s28qYw0eXS2hoZP2n90MEtpLcvxa9CnsnZyDRbZcOEY5mFwPMZEpW3BtMzVsbtYzJQdzOfKOe_2f9PdugMoEhaMnExviXVd7Bc0hJ8vcQumel79gIKqm5dvoCyDMDzjs48TZfkLxP9W-6lhOhQJbXeIPjaw0Wa0QvzTZMPzF-QeYotMKPkXEyA";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Issuer (iss) claim must be a string present in the ID token.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenIssInvalid()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJzb21ldGhpbmctZWxzZSIsInN1YiI6ImF1dGgwfDEyMzQ1Njc4OSIsImF1ZCI6WyJ0b2tlbnMtdGVzdC0xMjMiLCJleHRlcm5hbC10ZXN0LTk5OSJdLCJleHAiOjE1NjgxODA4OTQuMjI0LCJpYXQiOjE1NjgwMDgwOTQuMjI0LCJub25jZSI6ImExYjJjM2Q0ZTUiLCJhenAiOiJ0b2tlbnMtdGVzdC0xMjMiLCJhdXRoX3RpbWUiOjE1NjgwOTQ0OTQuMjI0fQ.fLAWfII_43BAXNuWuCUYfEBBIGdpRZt-dJK8RI9aVDqoDc27GmnFTjwA4hkOK5zLEAx4PYfVb9ISYdt3oRwiQJDI0HSfFoqFTetE1JBIGQwihZ3Fvyh3BqbVs9RC_BkL8iNYSFgrNL82_JbbwbaFra0JhZA4p7e97eF8h0W681oXIX_mGrKBmfpGx2yfJHhihfQEXos4xnWjyFCZnYwjzUqGHeykwddrQqkuAfFML6BRWygXc9szYduYYW5-WY3kp9aCmoWF1TGoEgPHV02u-B5BOo05H4xGReLUTvKUK9vOVe2g7rqG8vzyKciSj50lIBMEAOLRaWuO-hDCRcNdfA";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Issuer (iss) claim mismatch in the ID token; expected \"https://tokens-test.auth0.com/\", found \"something-else\".", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenSubMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.Jvt1rTNpLX6QKtnmOEw_CSPGF2IzcCrIAxWKpqS8tnX1t1PgZX1a3xYv6oG527a388cZMPpUAIYQTffz_2UT7OCareT9KnlqarHjOlfX3V7W91aYHCKbx_O9yfFys4MjdlEDZEfYcVnMuq4frirtFgPVcpM1IqJtsCe9hhkqXklzRufuxqHmcw6WHTW_izJPtNyn8Aqy7_lxK03JH4bFrs7IOsibW0Cm5f7X530u0Mi9lRyTIN3-imGVUhEuhopaCnp4fZ0tZUw7bvSHMUwMU2USY47O7ZNB4d3nYoazOjBCAE63-mNOW-B8Lg5YeWMlp_nGunpklquO7B_i7d2Bfw";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Subject (sub) claim must be a string present in the ID token.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenAudMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJleHAiOjE1NjgxODA4OTQuMjI0LCJpYXQiOjE1NjgwMDgwOTQuMjI0LCJub25jZSI6ImExYjJjM2Q0ZTUiLCJhenAiOiJ0b2tlbnMtdGVzdC0xMjMiLCJhdXRoX3RpbWUiOjE1NjgwOTQ0OTQuMjI0fQ.GKqEq8SU1MxHgS2k6cgs1QzIPHPmiWOtxMI4jmR1CHnJo0SXrikMmLPr8ZygJbJua_VQmxr2rFx4on0vwABpChBPNty0kt9RssBMa3laMfesEFuzHl-KlzH3kNxhStEgbmPvPg9dvny-ue7zd2CiACKj_ZSBUXRFJYzWzRYYaA0qGU1IBiIVR9lPJBErpqTrZPXtF6VSz3fysRMtXLhiAkeIKf2SEXuo-yXrYAExh0T4hyy58uARdWkO8q2CfY6U30WVZAkee9weBYR6WAfTc7v8fmpGt82aFCehtZrqUhYoFGNpCLINMUuPxNdTkc3oZua7Snf4SikdPWyoZb7oIQ";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Audience (aud) claim must be a string or array of strings present in the ID token.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenAudDoesNotContainAudience()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.lZN_VhbsnJpkHc0Y7j7cASHzgN3hC9mIiUTMVrIRh-cpBLt-xND1gVH5UtkkyIKacIwY3tX729Ri3yXGhYtF-7Z0qN0QnazXebjD6e8sUC1l4hqtXZaAYXN57IukvotlDAWBd5KWkRAxV4r-GgYLmfVXGdWa6pzv76tCCMVpj8fbFtlNfUdX2yJ2lV9MTL71phVWOOhZnabdnGRT_93fVnb_uQEpjzfDV3yTwtLYZ1qjJpBb3tve1D99RnMQP-ppeu09iER5YACNhaiOWMYlAwctT8yHXgwDeqfDoQq7YBepNy71Crf84GfeNQW6KUkTeZEdAJWmRcC07P6Hyy0POA";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Audience (aud) claim mismatch in the ID token; expected \"tokens-test-123\" but was not one of \"external-test-999\".", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenExpMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.RVRPBKl2LjUtEl5Wn7sqHJQw9zKkbv5L8nQimRu-p6t9gEBFRftZtgFVCV0n4fmZ7W1ofsCaInzwCW9DtTB6SAUZe5VaZTL7lqljEDVZyGZRRLPFR1m8ow_8B5Z0c2ga-w_gK1Vf0DM_ei0ASUmjO_9F53Qi-N1RwZqjQCbrNKpTOiLO2tTgk68uFamV4AZgmvq6_0HYJvlj2Y3MD6Gx04AiLEySnmRXaTzjTlrs6eJIrzrCN0GDFQfb4Xqstto1JuQqmLtejoTppGM1MxuU5ccoFerJRy94leLaqwuyBHQdUYr2mgT0pHaeOn-G0NsJpO3F1jqd26gfjNXdp-IhDQ";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Expiration Time (exp) claim must be an integer present in the ID token.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenExpIndicatesExpired()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MDA4MDk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.ioTJE8JzqUud9sFdk96M-lbMtbYeGV2eN30sGNMDHpNGxPYjHGWCyaEJbP8alybGM4P-YZ9HG58_IbAkaRY72gZRfn4Kb6-VWwfmub4h3diy4CQo8aY5onRlPOB700C_DMFe28W0KgK7GmUksjVrpdIQfBSYUb4dkIIoWKO81IVKdSRM21h5dFa16uVoPRNerQ7_x_Oni8oBxE0KhrG6EIPlCF0jBI_6wL8heBrUGqnjMAYRh1u_wN2Vm8c5upmHRM3orV-pWdLKyg44irp-EljTdLiMEz8lgjYK-BHw0UUJQdZOJAoZ36qQ5QtO3mR_61rAluhS7NGs60XliBUC6A";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Expiration Time (exp) claim error in the ID token; current time (1568023200) is after expiration time (1568008094).", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenIatMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.FgWPbEgrRSY0E12S1BY2kz01qWX3bXc_TqPQQb4TqqgjgECFQISwWTF4kjFqJ1jou1C0z5k5LP2DXStKJchvS6xBZzzPu1AXCGBsJCdlnr3mDVqSSA5TITCDkRNUnRcg4LOjU4Kjo5Ssq0FyL6xEth2Rkjgej0er5UTT3cNPaWY4AIDPHoJFCYXuOt6cFuRn3048Q6CV3rCfAp8B2PDq48AyZOHYaMdSCjMBgcqoB98mWTCP-K037Xmry_mudxufEyxzcJc6bRTCUalIoDm6FB9tP48fTfJMy_sQOmykdsg35_4gXX4HyGClIy3NbvqzP0vCS1htX1mB_4QY9YA19g";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Issued At (iat) claim must be an integer present in the ID token.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenIatIndicatesNotYetValid()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MTgwODk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.TK73zh_jQ8mUGZvQqs7PlIKmHSuXlVDrHSVrKzj0fQwcAxGEEC_IvXZ_p3KPTy4J0bL3IQ2uZe6I7f1i00N4WLwGKlMP-SbcFuPlAK-OnwgnHDafbsIU4eVd-a-cqoUrlMY46au4p8sdlkS8V5k8SExU_7lyunevvqZYPcsehl67Xp0QlkBOZaG90WGQ3qm0MVAZranl6LkQIET9UidhF4ArsMWi6dtEeMypiGIJp7tytDRD2j7QzY7UIB1zOEde2cClcpqnMM0cY2iySkFk22aJch1ERwZlCe1Y7VPWkx0R5rXxDJptpxIz95gGTW3AxyPUL00mahIzjLrOvkQp_g";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Issued At (iat) claim error in the ID token; current time (1568023200) is before issued at time (1568180894).", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenNonceIsMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.f1ljNRgJTXS8L9z3G7ILphOqm3y9pW_MjxmcMdo-W8jc5WeCau6vxXoBJnc3D73SSXTKBURoQRXB-Db3BPxt7xE-JcUYcVeJCDuq7bcCkL4AcCjfRjQLaXyQR18lJyqXmsf3fh_RiG67vxPBTrTBFzCpefmKvma0brpT4iIUsHdTRk9TYyII42PvYqKFqCN3hX32nfsprzazYBJNCvskx49O0Cd5_e-AMBpst9X3Q5azOxQ4KIGEEDxjdRRCG_SavW1WCBHLdtQk4NFICycGdFH73QPLoTUYYce5wdp2AAFWwQGaustoLryQXcan_NMzQP8uXfCwv0G4cC0oy1Xz2w";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Nonce (nonce) claim must be a string present in the ID token.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenNonceIsNotNonce()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiIwMDA5OTkiLCJhenAiOiJ0b2tlbnMtdGVzdC0xMjMiLCJhdXRoX3RpbWUiOjE1NjgwOTQ0OTQuMjI0fQ.l4aIDsM7POa7AQlxcCPW1PL84H7oFSdKOCuh-EXTfDAbOsH7RIL1ZGzbx3gUdxW0TCVWEMqlUcIJFbgIR66EAljU3WoY7V_2yiQz4QaPP_kOcodylOkV7EZ7-IIHGKWYD82NtV2ZoS239aY4tVK7H_IqMrfO--5caRRydThT01nVxnGatxNcbVxO0duahWIIJlEHjMVeIyA_Ct1iFfm-JV_j8Wo1w9bvh4ReJ3h6N9NBN9_B8Js4WPjNO_O947dNafwmWoVuTPTEIuf26_7UOvdrW0bjeMa5tRE_5topKVnUz7wRPJNIWiyNUSUSXGHxgE4ABa-TYoVOTQlgBjQo3Q";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Nonce (nonce) claim mismatch in the ID token; expected \"a1b2c3d4e5\", found \"000999\".", ex.Message);
        }

        [Fact]
        public async void SucceedsWhenNonceShouldBeIgnored()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.IfreWGZM2PVjgYG1E0WLIJ0f9-omYlq6v3FSn3ruu3a9gpTzhN-VB4ZKJRYmqkNLz_0F1mMFJgfpcCZ-ra5KW0aviiIAZHadYPoYLHsQsIVdOQmxkpwzaIoOwtgwvvg8QCKa3DTTPERRriUTYBfSgc5_4qg4bTxulZ7R3whygRMhVBI1uzjTHWMGXeu2PMezo1NtlFTVc3859UpDhGOUAYwBP3oC5JD1B2K15B9qpCtMq8AaAX1bieM8kX4Jez8r_ZwS1NTPMsCWOa2tpGFGhgu7ic9dlQpDjmxQdG8zXTgGJfejzSi0oHHAEtHxD-znTsyRVqu5psq_LEKBnWi6HA";

            var reqs = new IdTokenRequirements("https://tokens-test.auth0.com/", "tokens-test-123", TimeSpan.FromMinutes(5))
            {
                MaxAge = TimeSpan.FromSeconds(100)
            };

            await ValidateToken(token, reqs);
        }

        [Fact]
        public async void ThrowsWhenMultiAudAndNoAzp()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.Cp9wPTfgBlSkX-nbWjo6C4Emy_GqcdNjZDRNkDo8Vx6XfIwCjAqzVD6s9RUCH7neU-cjJML6h6mxi-J75moPMSjw4W0Jc2-AO-2wUh54PjAP35n1OQwjNkfsyPmjNYxGFzjejNvxvG04jH0XJLq6dPGm11aaVmgHaZ9aon3VqR36GxYSsQ76VytsHUtytOPqLQsdd8Men_wknw5niUKY0vjlV5SUFzSl_vQnQ2XojpCucczs9kOwrTDhJjCvSveZC8tnKqpBtb_DHV1HhCFyosgK7EYuKurVneRcKPiIeIg-F1bwmsWntfOFNmCeZe8xHUs1WV6oBXVFjaxIUiQZcA";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Authorized Party (azp) claim must be a string present in the ID token when Audiences (aud) claim has multiple values.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenMultiAudAndAzpDoesNotMatchAudience()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoiZXh0ZXJuYWwtdGVzdC05OTkiLCJhdXRoX3RpbWUiOjE1NjgwOTQ0OTQuMjI0fQ.K3ept8B5qiaMnEPn7ro3Rb0LGxJH44FQggWq3KOl4i2Mcm93Rba5T-u8MeQ82kggEyb5qvf9vUhobKQnDz-BwGHqVSGWtqyBXiWD9r1B64HewVpSSZ477wWNNzsSSUBAkcUYKSQ97vdJYRq0B6C-D2D2uy0oHC7yMLaKfbpZv5M76_k3b9ZVp26ubobh99RlHZ_JBdQxcTgtNUy2LpMyBX06rxK5tQuNvPTp2_Y3Q15ENQpBxetw88dXEU_hwMnmlncRM97iDBJSpyhrYU8js047wAVcojAFJD57kkqLM-Jns1EUlmPG0lF1cz7BOJBgs_7QN7dDyyu4qLjCMnWl0A";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Authorized Party (azp) claim mismatch in the ID token; expected \"tokens-test-123\", found \"external-test-999\".", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenMaxAgeRequestedButAuthTimeMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIn0.bCfVOKvoXEdbnMkGwrAx23TxrPE-aeitq0MNU5oKhFXzMikPvMkrgj9Iveh_2va7R0-X9_dMBorVzxn-I2YtIdcWFduj64GyMgALfLi678zecSiL4DUO6T_oPKRxrfiQXRKx6UUmxwp9tNfTcD-MYusD6Y-zpPw4blTxilBxb62BS3y3JcAUOoLEHF6XUooNNCybXK3-1HNZXMLcyG7GI2Qrnuuc8N-1dNJql_e420AELca21HZILxNtadQ14mayYXbF-jg3_ANtA-EZs58EVg7fs-T-NNNOTTNnDAJSndZc4TyeZQCQ9r56GC6_BoWfT3pK7WxASU-9fVFr472YfA";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Authentication Time (auth_time) claim must be an integer present in the ID token when MaxAge specified.", ex.Message);
        }

        [Fact]
        public async void ThrowsWhenMaxAgeRequestButAuthTimeExpired()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDA4MDk0LjIyNH0.RJmtcWlP3ZxQcNDRWgvJeRd_t5JGYPElRieOVUtYBbCUpThUYefp5YpoBinzT6Wc3vyzXs3FBjQWYhz7gvLFvEEtDcQIlBlhGVJ7EJkm1X8N5IbEYt-MfsyCUFK01q1rqDJSgSNqaMaTPPAQqjBd7sAsUCoP8XoWDF50aknrqtBfgVE2BMm-UqJSr1UjRXlGayDwBF5kjTJ-O8oeDP6PoXgmpj--NB-0p9zFATG0I2U_8iT1s9OYEJ3OIcyA5Zpv8Hs8eFL8KLZ4ZhAsr0NwTncsTdNSMD4-ywasCfXBvGcMXYwlKJL6LMzvTypvzcETFahFGJFm5ME-ziPu9Fj8dQ";

            var ex = await Assert.ThrowsAsync<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Authentication Time (auth_time) claim in the ID token indicates that too much time has passed since the last end-user authentication. Current time (1568023200) is after last auth at 1568008254.", ex.Message);
        }
    }
}
