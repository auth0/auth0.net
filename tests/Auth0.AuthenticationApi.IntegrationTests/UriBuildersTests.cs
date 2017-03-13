using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class UriBuildersTests : TestBase
    {
        [Fact]
        public void Can_build_authorization_uri()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var authorizationUrl = authenticationApiClient.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Code)
                .WithClient("rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW")
                .WithConnection("google-oauth2")
                .WithRedirectUrl("http://www.jerriepelser.com/test")
                .WithScope("openid offline_access")
                .WithAudience("https://myapi.com/v2")
                .WithNonce("MyNonce")
                .WithState("MyState")
                .Build();

            authorizationUrl.Should()
                .Be(
                    new Uri("https://auth0-dotnet-integration-tests.auth0.com/authorize?response_type=code&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&connection=google-oauth2&redirect_uri=http%3A%2F%2Fwww.jerriepelser.com%2Ftest&scope=openid%20offline_access&audience=https%3A%2F%2Fmyapi.com%2Fv2&nonce=MyNonce&state=MyState"));
        }

        [Fact]
        public void Can_provide_multiple_response_type()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var authorizationUrl = authenticationApiClient.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Code)
                .WithClient("rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW")
                .WithConnection("google-oauth2")
                .WithRedirectUrl("http://www.jerriepelser.com/test")
                .WithScope("openid offline_access")
                .Build();

            authorizationUrl.Should()
                .Be(
                    @"https://auth0-dotnet-integration-tests.auth0.com/authorize?response_type=code&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&connection=google-oauth2&redirect_uri=http%3A%2F%2Fwww.jerriepelser.com%2Ftest&scope=openid%20offline_access");
        }

        [Fact]
        public void Can_provide_response_mode()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var authorizationUrl = authenticationApiClient.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Code)
                .WithClient("rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW")
                .WithRedirectUrl("http://www.jerriepelser.com/test")
                .WithScope("openid")
                .WithResponseMode(AuthorizationResponseMode.FormPost)
                .Build();

            authorizationUrl.Should()
                .Be(
                    @"https://auth0-dotnet-integration-tests.auth0.com/authorize?response_type=code&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&redirect_uri=http%3A%2F%2Fwww.jerriepelser.com%2Ftest&scope=openid&response_mode=form_post");
        }

        [Fact]
        public void Can_build_logout_url()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var logoutUrl = authenticationApiClient.BuildLogoutUrl()
                .Federated()
                .WithClientId("rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW")
                .WithReturnUrl("https://myapp/logged_out")
                .Build();

            logoutUrl.Should()
                .Be(
                    @"https://auth0-dotnet-integration-tests.auth0.com/v2/logout?federated&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&returnTo=https%3A%2F%2Fmyapp%2Flogged_out");
        }

        [Fact]
        public void Can_build_logout_url_with_return_url()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var logoutUrl = authenticationApiClient.BuildLogoutUrl()
                .WithReturnUrl("http://www.jerriepelser.com/test")
                .Build();

            logoutUrl.Should()
                .Be(
                    @"https://auth0-dotnet-integration-tests.auth0.com/v2/logout?returnTo=http:%2F%2Fwww.jerriepelser.com%2Ftest");
        }

        [Fact]
        public void Can_build_saml_url()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var samlUrl = authenticationApiClient.BuildSamlUrl("myclientid")
                .WithConnection("my-connection-name")
                .Build();

            samlUrl.Should().Be(@"https://auth0-dotnet-integration-tests.auth0.com/samlp/myclientid?connection=my-connection-name");
        }

        [Fact]
        public void Can_build_wsfed_with_relaystate_dictionary()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var samlUrl = authenticationApiClient.BuildSamlUrl("myclientid")
                .WithRelayState(new Dictionary<string, string>
                {
                    {"xcrf", "abc"},
                    {"ru", "/foo"}
                })
                .Build();

            samlUrl.Should().Be(@"https://auth0-dotnet-integration-tests.auth0.com/samlp/myclientid?relayState=xcrf%3Dabc%26ru%3D%2Ffoo");
        }

        [Fact]
        public void Can_build_wsfed_with_relaystate_string()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var samlUrl = authenticationApiClient.BuildSamlUrl("myclientid")
                .WithRelayState("xcrf=abc&ru=/foo")
                .Build();

            samlUrl.Should().Be(@"https://auth0-dotnet-integration-tests.auth0.com/samlp/myclientid?relayState=xcrf%3Dabc%26ru%3D%2Ffoo");
        }

        [Fact]
        public void Can_build_wsfed_with_client()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var wsfedUrl = authenticationApiClient.BuildWsFedUrl()
                .WithClient("my-client-id")
                .Build();

            wsfedUrl.Should().Be(@"https://auth0-dotnet-integration-tests.auth0.com/wsfed/my-client-id");
        }

        [Fact]
        public void Can_build_wsfed_with_realm()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var wsfedUrl = authenticationApiClient.BuildWsFedUrl()
                .WithWtrealm("urn:my-client-id")
                .Build();

            wsfedUrl.Should().Be(@"https://auth0-dotnet-integration-tests.auth0.com/wsfed?wtrealm=urn:my-client-id");
        }

        [Fact]
        public void Can_build_wsfed_with_whr()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var wsfedUrl = authenticationApiClient.BuildWsFedUrl()
                .WithWhr("urn:my-connection-name")
                .Build();

            wsfedUrl.Should().Be(@"https://auth0-dotnet-integration-tests.auth0.com/wsfed?whr=urn:my-connection-name");
        }

        [Fact]
        public void Can_build_wsfed_with_wxtx_dictionary()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var wsfedUrl = authenticationApiClient.BuildWsFedUrl()
                .WithWctx(new Dictionary<string, string>
                {
                    {"xcrf", "abc"},
                    {"ru", "/foo"}
                })
                .Build();

            wsfedUrl.Should().Be(@"https://auth0-dotnet-integration-tests.auth0.com/wsfed?wctx=xcrf%3Dabc%26ru%3D%2Ffoo");
        }

        [Fact]
        public void Can_build_wsfed_with_wxtx_string()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            var wsfedUrl = authenticationApiClient.BuildWsFedUrl()
                .WithWctx("xcrf=abc&ru=/foo")
                .Build();

            wsfedUrl.Should().Be(@"https://auth0-dotnet-integration-tests.auth0.com/wsfed?wctx=xcrf%3Dabc%26ru%3D%2Ffoo");
        }
    }
}