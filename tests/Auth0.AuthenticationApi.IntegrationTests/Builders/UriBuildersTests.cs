using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests.Builders
{
    public class UriBuildersTests : TestBase
    {
        [Fact]
        public void Preserves_Uri_Path()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri("https://localhost:2000/something/here"));

            var authorizationUrl = authenticationApiClient.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Code)
                .WithClient("rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW")
                .WithConnection("google-oauth2")
                .Build();

            authorizationUrl.Should()
                .Be(
                    new Uri("https://localhost:2000/something/here/authorize?response_type=code&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&connection=google-oauth2"));
        }

        [Fact]
        public void Can_build_authorization_uri()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var authorizationUrl = authenticationApiClient.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Code)
                .WithClient("rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW")
                .WithConnection("google-oauth2")
                .WithRedirectUrl("http://www.jerriepelser.com/test")
                .WithScope("openid offline_access")
                .WithAudience("https://myapi.com/v2")
                .WithNonce("MyNonce")
                .WithState("MyState")
                .WithConnectionScope("ConnectionScope")
                .Build();

            authorizationUrl.Should()
                .Be(
                    new Uri("https://dx-sdks-testing.us.auth0.com/authorize?response_type=code&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&connection=google-oauth2&redirect_uri=http%3A%2F%2Fwww.jerriepelser.com%2Ftest&scope=openid%20offline_access&audience=https%3A%2F%2Fmyapi.com%2Fv2&nonce=MyNonce&state=MyState&connection_scope=ConnectionScope"));
        }

        [Fact]
        public void Can_build_authorization_uri_with_params_overloads()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var authorizationUrl = authenticationApiClient.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Code)
                .WithScopes("openid", "offline_access")
                .WithState("MyState")
                .WithConnectionScopes("ConnectionScope", "More")
                .Build();

            authorizationUrl.Should()
                .Be(
                    new Uri("https://dx-sdks-testing.us.auth0.com/authorize?response_type=code&scope=openid%20offline_access&state=MyState&connection_scope=ConnectionScope%20More"));
        }

        [Fact]
        public void Can_build_authorization_uri_with_organization()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var authorizationUrl = authenticationApiClient.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Code)
                .WithClient("rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW")
                .WithRedirectUrl("http://www.jerriepelser.com/test")
                .WithScope("openid offline_access")
                .WithNonce("MyNonce")
                .WithState("MyState")
                .WithOrganization("123")
                .Build();

            authorizationUrl.Should()
                .Be(
                    new Uri("https://dx-sdks-testing.us.auth0.com/authorize?response_type=code&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&redirect_uri=http%3A%2F%2Fwww.jerriepelser.com%2Ftest&scope=openid%20offline_access&nonce=MyNonce&state=MyState&organization=123"));
        }

        [Fact]
        public void Can_build_authorization_uri_with_invitation()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var authorizationUrl = authenticationApiClient.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Code)
                .WithClient("rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW")
                .WithRedirectUrl("http://www.jerriepelser.com/test")
                .WithScope("openid offline_access")
                .WithNonce("MyNonce")
                .WithState("MyState")
                .WithOrganization("123")
                .WithInvitation("456")
                .Build();

            authorizationUrl.Should()
                .Be(
                    new Uri("https://dx-sdks-testing.us.auth0.com/authorize?response_type=code&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&redirect_uri=http%3A%2F%2Fwww.jerriepelser.com%2Ftest&scope=openid%20offline_access&nonce=MyNonce&state=MyState&organization=123&invitation=456"));
        }

        [Fact]
        public void Can_provide_multiple_response_type()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var authorizationUrl = authenticationApiClient.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Code)
                .WithClient("rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW")
                .WithConnection("google-oauth2")
                .WithRedirectUrl("http://www.jerriepelser.com/test")
                .WithScope("openid offline_access")
                .Build();

            authorizationUrl.Should()
                .Be(
                    @"https://dx-sdks-testing.us.auth0.com/authorize?response_type=code&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&connection=google-oauth2&redirect_uri=http%3A%2F%2Fwww.jerriepelser.com%2Ftest&scope=openid%20offline_access");
        }

        [Fact]
        public void Can_provide_response_mode()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var authorizationUrl = authenticationApiClient.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Code)
                .WithClient("rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW")
                .WithRedirectUrl("http://www.jerriepelser.com/test")
                .WithScope("openid")
                .WithResponseMode(AuthorizationResponseMode.FormPost)
                .Build();

            authorizationUrl.Should()
                .Be(
                    @"https://dx-sdks-testing.us.auth0.com/authorize?response_type=code&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&redirect_uri=http%3A%2F%2Fwww.jerriepelser.com%2Ftest&scope=openid&response_mode=form_post");
        }

        [Fact]
        public void Can_build_logout_url()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var logoutUrl = authenticationApiClient.BuildLogoutUrl()
                .Federated()
                .WithClientId("rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW")
                .WithReturnUrl("https://myapp/logged_out")
                .Build();

            logoutUrl.Should()
                .Be(
                    @"https://dx-sdks-testing.us.auth0.com/v2/logout?federated&client_id=rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW&returnTo=https%3A%2F%2Fmyapp%2Flogged_out");
        }

        [Fact]
        public void Can_build_logout_url_with_return_url_as_string()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var logoutUrl = authenticationApiClient.BuildLogoutUrl()
                .WithReturnUrl("http://www.jerriepelser.com/test")
                .Build();

            logoutUrl.Should()
                .Be(
                    @"https://dx-sdks-testing.us.auth0.com/v2/logout?returnTo=http%3A%2F%2Fwww.jerriepelser.com%2Ftest");
        }

        [Fact]
        public void Can_build_logout_url_with_return_url_as_uri()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var logoutUrl = authenticationApiClient.BuildLogoutUrl()
                .WithReturnUrl(new Uri("http://www.jerriepelser.com/test"))
                .Build();

            logoutUrl.Should()
                .Be(
                    @"https://dx-sdks-testing.us.auth0.com/v2/logout?returnTo=http%3A%2F%2Fwww.jerriepelser.com%2Ftest");
        }

        [Fact]
        public void Can_build_logout_url_with_federated()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var logoutUrl = authenticationApiClient.BuildLogoutUrl()
                .Federated()
                .WithReturnUrl(new Uri("http://www.jerriepelser.com/test"))
                .Build();

            logoutUrl.Should()
                .Be(
                    @"https://dx-sdks-testing.us.auth0.com/v2/logout?federated&returnTo=http%3A%2F%2Fwww.jerriepelser.com%2Ftest");
        }

        [Fact]
        public void Can_build_saml_url()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var samlUrl = authenticationApiClient.BuildSamlUrl("myclientid")
                .WithConnection("my-connection-name")
                .Build();

            samlUrl.Should().Be(@"https://dx-sdks-testing.us.auth0.com/samlp/myclientid?connection=my-connection-name");
        }

        [Fact]
        public void Can_build_wsfed_with_relaystate_dictionary()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var samlUrl = authenticationApiClient.BuildSamlUrl("myclientid")
                .WithRelayState(new Dictionary<string, string>
                {
                    {"xcrf", "abc"},
                    {"ru", "/foo"}
                })
                .Build();

            samlUrl.Should().Be(@"https://dx-sdks-testing.us.auth0.com/samlp/myclientid?RelayState=xcrf%3Dabc%26ru%3D%2Ffoo");
        }

        [Fact]
        public void Can_build_wsfed_with_relaystate_string()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var samlUrl = authenticationApiClient.BuildSamlUrl("myclientid")
                .WithRelayState("xcrf=abc&ru=/foo")
                .Build();

            samlUrl.Should().Be(@"https://dx-sdks-testing.us.auth0.com/samlp/myclientid?RelayState=xcrf%3Dabc%26ru%3D%2Ffoo");
        }

        [Fact]
        public void Can_build_wsfed_with_client()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var wsfedUrl = authenticationApiClient.BuildWsFedUrl()
                .WithClient("my-client-id")
                .Build();

            wsfedUrl.Should().Be(@"https://dx-sdks-testing.us.auth0.com/wsfed/my-client-id");
        }

        [Fact]
        public void Can_build_wsfed_with_wtrealm()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var wsfedUrl = authenticationApiClient.BuildWsFedUrl()
                .WithWtrealm("urn:my-client-id")
                .Build();

            wsfedUrl.Should().Be(@"https://dx-sdks-testing.us.auth0.com/wsfed?wtrealm=urn%3Amy-client-id");
        }

        [Fact]
        public void Can_build_wsfed_with_whr()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var wsfedUrl = authenticationApiClient.BuildWsFedUrl()
                .WithWhr("urn:my-connection-name")
                .Build();

            wsfedUrl.Should().Be(@"https://dx-sdks-testing.us.auth0.com/wsfed?whr=urn%3Amy-connection-name");
        }

        [Fact]
        public void Can_build_wsfed_with_wctx_dictionary()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var wsfedUrl = authenticationApiClient.BuildWsFedUrl()
                .WithWctx(new Dictionary<string, string>
                {
                    {"xcrf", "abc"},
                    {"ru", "/foo"}
                })
                .Build();

            wsfedUrl.Should().Be(@"https://dx-sdks-testing.us.auth0.com/wsfed?wctx=xcrf%3Dabc%26ru%3D%2Ffoo");
        }

        [Fact]
        public void Can_build_wsfed_with_wctx_string()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            var wsfedUrl = authenticationApiClient.BuildWsFedUrl()
                .WithWctx("xcrf=abc&ru=/foo")
                .Build();

            wsfedUrl.Should().Be(@"https://dx-sdks-testing.us.auth0.com/wsfed?wctx=xcrf%3Dabc%26ru%3D%2Ffoo");
        }
    }
}