using Auth0.AuthenticationApi.Tokens;
using Auth0.Tests.Shared;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests.Tokens
{
    public class IdTokenClaimValidatorTests : TestBase
    {
        static readonly JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
        static readonly DateTime tokensWereValid = new DateTime(2019, 9, 9, 10, 00, 00, DateTimeKind.Utc);

        static readonly IdTokenRequirements defaultReqs =
            new IdTokenRequirements(JwtSignatureAlgorithm.RS256, "https://tokens-test.auth0.com/", "tokens-test-123", TimeSpan.FromMinutes(1))
            {
                Nonce = "a1b2c3d4e5",
                MaxAge = TimeSpan.FromSeconds(100)
            };

        private void ValidateToken(string token, IdTokenRequirements reqs = null)
        {
            var decodedToken = securityTokenHandler.ReadJwtToken(token);
            IdTokenClaimValidator.AssertClaimsMeetRequirements(reqs ?? defaultReqs, decodedToken, tokensWereValid);
        }

        [Fact]
        public void ThrowsWhenIssMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.qThWXz2PspgwyGQGsobPgrNjMPhvRdgjPSijG4NSaKuAPG_E5zVGdxTAiZhhwMCvhyqVIyV7eJJ7JMM6zeXsIel6mR_rZ1BiEwW_K02jDXlhXTkIUJP2KGt7zmzTEYvTiQ5izpCOLOtg02vMBS_xaqpGqquZI6-0s28qYw0eXS2hoZP2n90MEtpLcvxa9CnsnZyDRbZcOEY5mFwPMZEpW3BtMzVsbtYzJQdzOfKOe_2f9PdugMoEhaMnExviXVd7Bc0hJ8vcQumel79gIKqm5dvoCyDMDzjs48TZfkLxP9W-6lhOhQJbXeIPjaw0Wa0QvzTZMPzF-QeYotMKPkXEyA";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Issuer (iss) claim must be a string present in the ID token.", ex.Message);
        }

        [Fact]
        public void ThrowsWhenIssInvalid()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJzb21ldGhpbmctZWxzZSIsInN1YiI6ImF1dGgwfDEyMzQ1Njc4OSIsImF1ZCI6WyJ0b2tlbnMtdGVzdC0xMjMiLCJleHRlcm5hbC10ZXN0LTk5OSJdLCJleHAiOjE1NjgxODA4OTQuMjI0LCJpYXQiOjE1NjgwMDgwOTQuMjI0LCJub25jZSI6ImExYjJjM2Q0ZTUiLCJhenAiOiJ0b2tlbnMtdGVzdC0xMjMiLCJhdXRoX3RpbWUiOjE1NjgwOTQ0OTQuMjI0fQ.fLAWfII_43BAXNuWuCUYfEBBIGdpRZt-dJK8RI9aVDqoDc27GmnFTjwA4hkOK5zLEAx4PYfVb9ISYdt3oRwiQJDI0HSfFoqFTetE1JBIGQwihZ3Fvyh3BqbVs9RC_BkL8iNYSFgrNL82_JbbwbaFra0JhZA4p7e97eF8h0W681oXIX_mGrKBmfpGx2yfJHhihfQEXos4xnWjyFCZnYwjzUqGHeykwddrQqkuAfFML6BRWygXc9szYduYYW5-WY3kp9aCmoWF1TGoEgPHV02u-B5BOo05H4xGReLUTvKUK9vOVe2g7rqG8vzyKciSj50lIBMEAOLRaWuO-hDCRcNdfA";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Issuer (iss) claim mismatch in the ID token; expected \"https://tokens-test.auth0.com/\", found \"something-else\".", ex.Message);
        }

        [Fact]
        public void ThrowsWhenSubMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.Jvt1rTNpLX6QKtnmOEw_CSPGF2IzcCrIAxWKpqS8tnX1t1PgZX1a3xYv6oG527a388cZMPpUAIYQTffz_2UT7OCareT9KnlqarHjOlfX3V7W91aYHCKbx_O9yfFys4MjdlEDZEfYcVnMuq4frirtFgPVcpM1IqJtsCe9hhkqXklzRufuxqHmcw6WHTW_izJPtNyn8Aqy7_lxK03JH4bFrs7IOsibW0Cm5f7X530u0Mi9lRyTIN3-imGVUhEuhopaCnp4fZ0tZUw7bvSHMUwMU2USY47O7ZNB4d3nYoazOjBCAE63-mNOW-B8Lg5YeWMlp_nGunpklquO7B_i7d2Bfw";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Subject (sub) claim must be a string present in the ID token.", ex.Message);
        }

        [Fact]
        public void ThrowsWhenAudMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJleHAiOjE1NjgxODA4OTQuMjI0LCJpYXQiOjE1NjgwMDgwOTQuMjI0LCJub25jZSI6ImExYjJjM2Q0ZTUiLCJhenAiOiJ0b2tlbnMtdGVzdC0xMjMiLCJhdXRoX3RpbWUiOjE1NjgwOTQ0OTQuMjI0fQ.GKqEq8SU1MxHgS2k6cgs1QzIPHPmiWOtxMI4jmR1CHnJo0SXrikMmLPr8ZygJbJua_VQmxr2rFx4on0vwABpChBPNty0kt9RssBMa3laMfesEFuzHl-KlzH3kNxhStEgbmPvPg9dvny-ue7zd2CiACKj_ZSBUXRFJYzWzRYYaA0qGU1IBiIVR9lPJBErpqTrZPXtF6VSz3fysRMtXLhiAkeIKf2SEXuo-yXrYAExh0T4hyy58uARdWkO8q2CfY6U30WVZAkee9weBYR6WAfTc7v8fmpGt82aFCehtZrqUhYoFGNpCLINMUuPxNdTkc3oZua7Snf4SikdPWyoZb7oIQ";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Audience (aud) claim must be a string or array of strings present in the ID token.", ex.Message);
        }

        [Fact]
        public void ThrowsWhenAudDoesNotContainAudience()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.lZN_VhbsnJpkHc0Y7j7cASHzgN3hC9mIiUTMVrIRh-cpBLt-xND1gVH5UtkkyIKacIwY3tX729Ri3yXGhYtF-7Z0qN0QnazXebjD6e8sUC1l4hqtXZaAYXN57IukvotlDAWBd5KWkRAxV4r-GgYLmfVXGdWa6pzv76tCCMVpj8fbFtlNfUdX2yJ2lV9MTL71phVWOOhZnabdnGRT_93fVnb_uQEpjzfDV3yTwtLYZ1qjJpBb3tve1D99RnMQP-ppeu09iER5YACNhaiOWMYlAwctT8yHXgwDeqfDoQq7YBepNy71Crf84GfeNQW6KUkTeZEdAJWmRcC07P6Hyy0POA";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Audience (aud) claim mismatch in the ID token; expected \"tokens-test-123\" but was not one of \"external-test-999\".", ex.Message);
        }

        [Fact]
        public void ThrowsWhenExpMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.RVRPBKl2LjUtEl5Wn7sqHJQw9zKkbv5L8nQimRu-p6t9gEBFRftZtgFVCV0n4fmZ7W1ofsCaInzwCW9DtTB6SAUZe5VaZTL7lqljEDVZyGZRRLPFR1m8ow_8B5Z0c2ga-w_gK1Vf0DM_ei0ASUmjO_9F53Qi-N1RwZqjQCbrNKpTOiLO2tTgk68uFamV4AZgmvq6_0HYJvlj2Y3MD6Gx04AiLEySnmRXaTzjTlrs6eJIrzrCN0GDFQfb4Xqstto1JuQqmLtejoTppGM1MxuU5ccoFerJRy94leLaqwuyBHQdUYr2mgT0pHaeOn-G0NsJpO3F1jqd26gfjNXdp-IhDQ";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Expiration Time (exp) claim must be an integer present in the ID token.", ex.Message);
        }

        [Fact]
        public void ThrowsWhenExpIndicatesExpired()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MDA4MDk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.ioTJE8JzqUud9sFdk96M-lbMtbYeGV2eN30sGNMDHpNGxPYjHGWCyaEJbP8alybGM4P-YZ9HG58_IbAkaRY72gZRfn4Kb6-VWwfmub4h3diy4CQo8aY5onRlPOB700C_DMFe28W0KgK7GmUksjVrpdIQfBSYUb4dkIIoWKO81IVKdSRM21h5dFa16uVoPRNerQ7_x_Oni8oBxE0KhrG6EIPlCF0jBI_6wL8heBrUGqnjMAYRh1u_wN2Vm8c5upmHRM3orV-pWdLKyg44irp-EljTdLiMEz8lgjYK-BHw0UUJQdZOJAoZ36qQ5QtO3mR_61rAluhS7NGs60XliBUC6A";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Expiration Time (exp) claim error in the ID token; current time (1568023200) is after expiration time (1568008094).", ex.Message);
        }

        [Fact]
        public void ThrowsWhenIatMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.FgWPbEgrRSY0E12S1BY2kz01qWX3bXc_TqPQQb4TqqgjgECFQISwWTF4kjFqJ1jou1C0z5k5LP2DXStKJchvS6xBZzzPu1AXCGBsJCdlnr3mDVqSSA5TITCDkRNUnRcg4LOjU4Kjo5Ssq0FyL6xEth2Rkjgej0er5UTT3cNPaWY4AIDPHoJFCYXuOt6cFuRn3048Q6CV3rCfAp8B2PDq48AyZOHYaMdSCjMBgcqoB98mWTCP-K037Xmry_mudxufEyxzcJc6bRTCUalIoDm6FB9tP48fTfJMy_sQOmykdsg35_4gXX4HyGClIy3NbvqzP0vCS1htX1mB_4QY9YA19g";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Issued At (iat) claim must be an integer present in the ID token.", ex.Message);
        }

        [Fact]
        public void ThrowsWhenNonceIsMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.f1ljNRgJTXS8L9z3G7ILphOqm3y9pW_MjxmcMdo-W8jc5WeCau6vxXoBJnc3D73SSXTKBURoQRXB-Db3BPxt7xE-JcUYcVeJCDuq7bcCkL4AcCjfRjQLaXyQR18lJyqXmsf3fh_RiG67vxPBTrTBFzCpefmKvma0brpT4iIUsHdTRk9TYyII42PvYqKFqCN3hX32nfsprzazYBJNCvskx49O0Cd5_e-AMBpst9X3Q5azOxQ4KIGEEDxjdRRCG_SavW1WCBHLdtQk4NFICycGdFH73QPLoTUYYce5wdp2AAFWwQGaustoLryQXcan_NMzQP8uXfCwv0G4cC0oy1Xz2w";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Nonce (nonce) claim must be a string present in the ID token.", ex.Message);
        }

        [Fact]
        public void ThrowsWhenNonceIsNotNonce()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiIwMDA5OTkiLCJhenAiOiJ0b2tlbnMtdGVzdC0xMjMiLCJhdXRoX3RpbWUiOjE1NjgwOTQ0OTQuMjI0fQ.l4aIDsM7POa7AQlxcCPW1PL84H7oFSdKOCuh-EXTfDAbOsH7RIL1ZGzbx3gUdxW0TCVWEMqlUcIJFbgIR66EAljU3WoY7V_2yiQz4QaPP_kOcodylOkV7EZ7-IIHGKWYD82NtV2ZoS239aY4tVK7H_IqMrfO--5caRRydThT01nVxnGatxNcbVxO0duahWIIJlEHjMVeIyA_Ct1iFfm-JV_j8Wo1w9bvh4ReJ3h6N9NBN9_B8Js4WPjNO_O947dNafwmWoVuTPTEIuf26_7UOvdrW0bjeMa5tRE_5topKVnUz7wRPJNIWiyNUSUSXGHxgE4ABa-TYoVOTQlgBjQo3Q";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Nonce (nonce) claim mismatch in the ID token; expected \"a1b2c3d4e5\", found \"000999\".", ex.Message);
        }

        [Fact]
        public void SucceedsWhenNonceShouldBeIgnored()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.IfreWGZM2PVjgYG1E0WLIJ0f9-omYlq6v3FSn3ruu3a9gpTzhN-VB4ZKJRYmqkNLz_0F1mMFJgfpcCZ-ra5KW0aviiIAZHadYPoYLHsQsIVdOQmxkpwzaIoOwtgwvvg8QCKa3DTTPERRriUTYBfSgc5_4qg4bTxulZ7R3whygRMhVBI1uzjTHWMGXeu2PMezo1NtlFTVc3859UpDhGOUAYwBP3oC5JD1B2K15B9qpCtMq8AaAX1bieM8kX4Jez8r_ZwS1NTPMsCWOa2tpGFGhgu7ic9dlQpDjmxQdG8zXTgGJfejzSi0oHHAEtHxD-znTsyRVqu5psq_LEKBnWi6HA";

            var reqs = new IdTokenRequirements(JwtSignatureAlgorithm.RS256, "https://tokens-test.auth0.com/", "tokens-test-123", TimeSpan.FromMinutes(5))
            {
                MaxAge = TimeSpan.FromSeconds(100)
            };

            ValidateToken(token, reqs);
        }

        [Fact]
        public void ThrowsWhenMultiAudAndNoAzp()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXV0aF90aW1lIjoxNTY4MDk0NDk0LjIyNH0.Cp9wPTfgBlSkX-nbWjo6C4Emy_GqcdNjZDRNkDo8Vx6XfIwCjAqzVD6s9RUCH7neU-cjJML6h6mxi-J75moPMSjw4W0Jc2-AO-2wUh54PjAP35n1OQwjNkfsyPmjNYxGFzjejNvxvG04jH0XJLq6dPGm11aaVmgHaZ9aon3VqR36GxYSsQ76VytsHUtytOPqLQsdd8Men_wknw5niUKY0vjlV5SUFzSl_vQnQ2XojpCucczs9kOwrTDhJjCvSveZC8tnKqpBtb_DHV1HhCFyosgK7EYuKurVneRcKPiIeIg-F1bwmsWntfOFNmCeZe8xHUs1WV6oBXVFjaxIUiQZcA";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Authorized Party (azp) claim must be a string present in the ID token when Audiences (aud) claim has multiple values.", ex.Message);
        }

        [Fact]
        public void ThrowsWhenMultiAudAndAzpDoesNotMatchAudience()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoiZXh0ZXJuYWwtdGVzdC05OTkiLCJhdXRoX3RpbWUiOjE1NjgwOTQ0OTQuMjI0fQ.K3ept8B5qiaMnEPn7ro3Rb0LGxJH44FQggWq3KOl4i2Mcm93Rba5T-u8MeQ82kggEyb5qvf9vUhobKQnDz-BwGHqVSGWtqyBXiWD9r1B64HewVpSSZ477wWNNzsSSUBAkcUYKSQ97vdJYRq0B6C-D2D2uy0oHC7yMLaKfbpZv5M76_k3b9ZVp26ubobh99RlHZ_JBdQxcTgtNUy2LpMyBX06rxK5tQuNvPTp2_Y3Q15ENQpBxetw88dXEU_hwMnmlncRM97iDBJSpyhrYU8js047wAVcojAFJD57kkqLM-Jns1EUlmPG0lF1cz7BOJBgs_7QN7dDyyu4qLjCMnWl0A";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Authorized Party (azp) claim mismatch in the ID token; expected \"tokens-test-123\", found \"external-test-999\".", ex.Message);
        }

        [Fact]
        public void ThrowsWhenMaxAgeRequestedButAuthTimeMissing()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIn0.bCfVOKvoXEdbnMkGwrAx23TxrPE-aeitq0MNU5oKhFXzMikPvMkrgj9Iveh_2va7R0-X9_dMBorVzxn-I2YtIdcWFduj64GyMgALfLi678zecSiL4DUO6T_oPKRxrfiQXRKx6UUmxwp9tNfTcD-MYusD6Y-zpPw4blTxilBxb62BS3y3JcAUOoLEHF6XUooNNCybXK3-1HNZXMLcyG7GI2Qrnuuc8N-1dNJql_e420AELca21HZILxNtadQ14mayYXbF-jg3_ANtA-EZs58EVg7fs-T-NNNOTTNnDAJSndZc4TyeZQCQ9r56GC6_BoWfT3pK7WxASU-9fVFr472YfA";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Authentication Time (auth_time) claim must be an integer present in the ID token when MaxAge specified.", ex.Message);
        }

        [Fact]
        public void ThrowsWhenMaxAgeRequestButAuthTimeExpired()
        {
            var token = "eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL3Rva2Vucy10ZXN0LmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHwxMjM0NTY3ODkiLCJhdWQiOlsidG9rZW5zLXRlc3QtMTIzIiwiZXh0ZXJuYWwtdGVzdC05OTkiXSwiZXhwIjoxNTY4MTgwODk0LjIyNCwiaWF0IjoxNTY4MDA4MDk0LjIyNCwibm9uY2UiOiJhMWIyYzNkNGU1IiwiYXpwIjoidG9rZW5zLXRlc3QtMTIzIiwiYXV0aF90aW1lIjoxNTY4MDA4MDk0LjIyNH0.RJmtcWlP3ZxQcNDRWgvJeRd_t5JGYPElRieOVUtYBbCUpThUYefp5YpoBinzT6Wc3vyzXs3FBjQWYhz7gvLFvEEtDcQIlBlhGVJ7EJkm1X8N5IbEYt-MfsyCUFK01q1rqDJSgSNqaMaTPPAQqjBd7sAsUCoP8XoWDF50aknrqtBfgVE2BMm-UqJSr1UjRXlGayDwBF5kjTJ-O8oeDP6PoXgmpj--NB-0p9zFATG0I2U_8iT1s9OYEJ3OIcyA5Zpv8Hs8eFL8KLZ4ZhAsr0NwTncsTdNSMD4-ywasCfXBvGcMXYwlKJL6LMzvTypvzcETFahFGJFm5ME-ziPu9Fj8dQ";

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token));
            Assert.Equal("Authentication Time (auth_time) claim in the ID token indicates that too much time has passed since the last end-user authentication. Current time (1568023200) is after last auth at 1568008254.", ex.Message);
        }

        [Fact]
        public void ThrowsWhenNoOrgIdWhileOrgIdRequired()
        {
            IdTokenRequirements requirements =
            new IdTokenRequirements(JwtSignatureAlgorithm.RS256, "https://tokens-test.auth0.com/", "tokens-test-123", TimeSpan.FromMinutes(1))
            {
                Nonce = "a1b2c3d4e5",
                MaxAge = TimeSpan.FromSeconds(100),
                Organization = "org_123"
            };

            var key = new RsaSecurityKey(new RSACryptoServiceProvider(2048));
            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.RsaSha256);

            var token = tokenFactory.GenerateToken("https://tokens-test.auth0.com/", "tokens-test-123", "test_sub", new List<Claim> { new Claim(JwtRegisteredClaimNames.Nonce, "a1b2c3d4e5"), new Claim("org_name", "organizationA") });

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token, requirements));
            Assert.Equal("Organization claim (org_id) must be a string present in the ID token.", ex.Message);
        }

        [Fact]
        public void ThrowsWhenOrgIdDoesntMatch()
        {
            IdTokenRequirements requirements =
            new IdTokenRequirements(JwtSignatureAlgorithm.RS256, "https://tokens-test.auth0.com/", "tokens-test-123", TimeSpan.FromMinutes(1))
            {
                Nonce = "a1b2c3d4e5",
                MaxAge = TimeSpan.FromSeconds(100),
                Organization = "org_123"
            };

            var key = new RsaSecurityKey(new RSACryptoServiceProvider(2048));
            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.RsaSha256);

            var organization = "abc";
            var token = tokenFactory.GenerateToken("https://tokens-test.auth0.com/", "tokens-test-123", "test_sub", new List<Claim> { new Claim(JwtRegisteredClaimNames.Nonce, "a1b2c3d4e5"), new Claim("org_id", organization) });

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token, requirements));
            Assert.Equal($"Organization claim (org_id) mismatch in the ID token; expected \"{requirements.Organization}\", found \"{organization}\".", ex.Message);
        }

        [Fact]
        public void DoesNotThrowWhenOrgIdMatch()
        {
            IdTokenRequirements requirements =
            new IdTokenRequirements(JwtSignatureAlgorithm.RS256, "https://tokens-test.auth0.com/", "tokens-test-123", TimeSpan.FromMinutes(1))
            {
                Nonce = "a1b2c3d4e5",
                MaxAge = TimeSpan.FromSeconds(100),
                Organization = "org_123"
            };

            var key = new RsaSecurityKey(new RSACryptoServiceProvider(2048));
            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.RsaSha256);
            var token = tokenFactory.GenerateToken("https://tokens-test.auth0.com/", "tokens-test-123", "test_sub", new List<Claim> { new Claim(JwtRegisteredClaimNames.Nonce, "a1b2c3d4e5"), new Claim("org_id", "org_123") });

            ValidateToken(token, requirements);
        }

        [Fact]
        public void ThrowsWhenNoOrgNameWhileOrgNameRequired()
        {
            IdTokenRequirements requirements =
            new IdTokenRequirements(JwtSignatureAlgorithm.RS256, "https://tokens-test.auth0.com/", "tokens-test-123", TimeSpan.FromMinutes(1))
            {
                Nonce = "a1b2c3d4e5",
                MaxAge = TimeSpan.FromSeconds(100),
                Organization = "organizationa"
            };

            var key = new RsaSecurityKey(new RSACryptoServiceProvider(2048));
            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.RsaSha256);

            var token = tokenFactory.GenerateToken("https://tokens-test.auth0.com/", "tokens-test-123", "test_sub", new List<Claim> { new Claim(JwtRegisteredClaimNames.Nonce, "a1b2c3d4e5"), new Claim("org_id", "org_123") });

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token, requirements));
            Assert.Equal("Organization claim (org_name) must be a string present in the ID token.", ex.Message);
        }

        [Fact]
        public void ThrowsWhenOrgNameDoesntMatch()
        {
            IdTokenRequirements requirements =
            new IdTokenRequirements(JwtSignatureAlgorithm.RS256, "https://tokens-test.auth0.com/", "tokens-test-123", TimeSpan.FromMinutes(1))
            {
                Nonce = "a1b2c3d4e5",
                MaxAge = TimeSpan.FromSeconds(100),
                Organization = "organizationa"
            };

            var key = new RsaSecurityKey(new RSACryptoServiceProvider(2048));
            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.RsaSha256);

            var organization = "organization2";
            var token = tokenFactory.GenerateToken("https://tokens-test.auth0.com/", "tokens-test-123", "test_sub", new List<Claim> { new Claim(JwtRegisteredClaimNames.Nonce, "a1b2c3d4e5"), new Claim("org_name", organization) });

            var ex = Assert.Throws<IdTokenValidationException>(() => ValidateToken(token, requirements));
            Assert.Equal($"Organization claim (org_name) mismatch in the ID token; expected \"{requirements.Organization}\", found \"{organization}\".", ex.Message);
        }

        [Fact]
        public void DoesNotThrowWhenOrgNameMatch()
        {
            IdTokenRequirements requirements =
            new IdTokenRequirements(JwtSignatureAlgorithm.RS256, "https://tokens-test.auth0.com/", "tokens-test-123", TimeSpan.FromMinutes(1))
            {
                Nonce = "a1b2c3d4e5",
                MaxAge = TimeSpan.FromSeconds(100),
                Organization = "organizationA"
            };

            var key = new RsaSecurityKey(new RSACryptoServiceProvider(2048));
            var tokenFactory = new JwtTokenFactory(key, SecurityAlgorithms.RsaSha256);

            var token = tokenFactory.GenerateToken("https://tokens-test.auth0.com/", "tokens-test-123", "test_sub", new List<Claim> { new Claim(JwtRegisteredClaimNames.Nonce, "a1b2c3d4e5"), new Claim("org_name", "organizationa") });

            ValidateToken(token, requirements);
        }
    }
}
