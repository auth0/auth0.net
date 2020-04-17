using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class PasswordlessTests : TestBase
    {
        private AuthenticationApiClient authenticationApiClient;
        private string email;
        private string phone;

        public PasswordlessTests()
        {
            authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));
            email = GetVariable("AUTH0_PASSWORDLESSDEMO_EMAIL", false);
            phone = GetVariable("AUTH0_PASSWORDLESSDEMO_PHONE", false);
        }

        [SkippableFact]
        public async Task Can_launch_email_link_flow()
        {
            Skip.If(string.IsNullOrEmpty(email), "AUTH0_PASSWORDLESSDEMO_EMAIL not set");

            var request = new PasswordlessEmailRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                Email = email,
                Type = PasswordlessEmailRequestType.Link
            };

            var response = await authenticationApiClient.StartPasswordlessEmailFlowAsync(request);
            response.Should().NotBeNull();
            response.Email.Should().Be(request.Email);
            response.Id.Should().NotBeNullOrEmpty();
            response.EmailVerified.Should().NotBeNull();
        }

        [SkippableFact]
        public async Task Can_launch_email_link_flow_with_auth_parameters()
        {
            Skip.If(string.IsNullOrEmpty(email), "AUTH0_PASSWORDLESSDEMO_EMAIL not set");

            var request = new PasswordlessEmailRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                Email = email,
                Type = PasswordlessEmailRequestType.Link,
                AuthenticationParameters = new Dictionary<string, object>()
                {
                    { "response_type", "code" },
                    { "scope" , "openid" },
                    { "nonce" , "mynonce" },
                    { "redirect_uri", "http://localhost:5000/signin-auth0" }
                }
            };

            var response = await authenticationApiClient.StartPasswordlessEmailFlowAsync(request);
            response.Should().NotBeNull();
            response.Email.Should().Be(request.Email);
            response.Id.Should().NotBeNullOrEmpty();
            response.EmailVerified.Should().NotBeNull();
        }

        [SkippableFact]
        public async Task Can_launch_email_code_flow()
        {
            Skip.If(string.IsNullOrEmpty(email), "AUTH0_PASSWORDLESSDEMO_EMAIL not set");

            var request = new PasswordlessEmailRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                Email = email,
                Type = PasswordlessEmailRequestType.Code
            };
            var response = await authenticationApiClient.StartPasswordlessEmailFlowAsync(request);
            response.Should().NotBeNull();
            response.Email.Should().Be(request.Email);
            response.Id.Should().NotBeNullOrEmpty();
            response.EmailVerified.Should().NotBeNull();
        }

        [SkippableFact]
        public async Task Can_launch_sms_flow()
        {
            Skip.If(string.IsNullOrEmpty(phone), "AUTH0_PASSWORDLESSDEMO_PHONE not set");

            // Arrange
            using (var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_PASSWORDLESSDEMO_AUTHENTICATION_API_URL")))
            {
                // Act
                var request = new PasswordlessSmsRequest
                {
                    ClientId = GetVariable("AUTH0_PASSWORDLESSDEMO_CLIENT_ID"),
                    ClientSecret = GetVariable("AUTH0_PASSWORDLESSDEMO_CLIENT_SECRET"),
                    PhoneNumber = phone
                };
                var response = await authenticationApiClient.StartPasswordlessSmsFlowAsync(request);
                response.Should().NotBeNull();
                response.PhoneNumber.Should().Be(request.PhoneNumber);
            }
        }
    }
}