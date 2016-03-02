using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using FluentAssertions;
using NUnit.Framework;
using Auth0.Tests.Shared;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    [TestFixture]
    public class ImpersonationTests : TestBase
    {
        private string accessToken = "your access token";

        [Test, Explicit]
        public async Task Can_impersonate_user()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

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