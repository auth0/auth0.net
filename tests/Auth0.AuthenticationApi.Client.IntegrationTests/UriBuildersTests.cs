using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Client.Models;
using Auth0.ManagementApi.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.AuthenticationApi.Client.IntegrationTests
{
    [TestFixture]
    public class UriBuildersTests : TestBase
    {
        [Test]
        public async Task Can_build_authorization_uri()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var authorizationUri = await authenticationApiClient.BuildAuthorizationUri(new BuildAuthorizationUriRequest
            {
                ResponseType = AuthorizationResponseType.Code,
                ClientId = "rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW",
                Connection = "google-oauth2",
                RedirectUri = new Uri("http://www.jerriepelser.com/test"),
                Scope = "openid offline_access"
            });

            authorizationUri.Should()
                .Be(
                    @"https://auth0-dotnet-integration-tests.auth0.com/authorize?response_type=code&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&connection=google-oauth2&redirect_uri=http%3A%2F%2Fwww.jerriepelser.com%2Ftest&scope=openid%20offline_access");
        }

        [Test]
        public async Task Can_build_logout_uri()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var logoutUri = await authenticationApiClient.BuildLogoutUri(new Uri("http://www.jerriepelser.com/test"));

            logoutUri.Should()
                .Be(
                    @"https://auth0-dotnet-integration-tests.auth0.com/logout?returnTo=http:%2F%2Fwww.jerriepelser.com%2Ftest");
        }

        [Test]
        public void Can_build_saml_url()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            authenticationApiClient.BuildSamlUrl("aaa")
                .WithConnection("aaa")
                .WithValue("asasas", "dsfsdfsd");
        }
    }
}