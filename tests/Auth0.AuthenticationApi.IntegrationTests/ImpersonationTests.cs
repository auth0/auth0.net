using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class ImpersonationTests : TestBase
    {
        private string accessToken = "your access token";

        [Fact(Skip = "Run manually")]
        public async Task Can_impersonate_user()
        {
            using (var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL")))
            {
                var uri = await authenticationApiClient.GetImpersonationUrlAsync(new ImpersonationRequest
                {
                    ImpersonateId = "impersonate id",
                    Token = accessToken,
                    Protocol = "oauth2",
                    ClientId = GetVariable("AUTH0_CLIENT_ID"),
                    ImpersonatorId = "impoersonator id"
                });

                uri.Should().NotBeNull();
            }
        }
    }
}