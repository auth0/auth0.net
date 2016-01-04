using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    [TestFixture]
    public class PasswordlessTests : TestBase
    {
        [Test, Explicit]
        public async Task Can_launch_email_link_flow()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // Act
            var request = new PasswordlessEmailRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Email = "your email",
                Type = PasswordlessEmailRequestType.Link
            };
            var response = await authenticationApiClient.StartPasswordlessEmailFlow(request);
            response.Should().NotBeNull();
            response.Email.Should().Be(request.Email);
        }

        [Test, Explicit]
        public async Task Can_launch_email_code_flow()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // Act
            var request = new PasswordlessEmailRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Email = "your email",
                Type = PasswordlessEmailRequestType.Code
            };
            var response = await authenticationApiClient.StartPasswordlessEmailFlow(request);
            response.Should().NotBeNull();
            response.Email.Should().Be(request.Email);
        }

        [Test, Explicit]
        public async Task Can_launch_sms_flow()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_PASSWORDLESSDEMO_AUTHENTICATION_API_URL")));

            // Act
            var request = new PasswordlessSmsRequest
            {
                ClientId = GetVariable("AUTH0_PASSWORDLESSDEMO_CLIENT_ID"),
                PhoneNumber = "your phone number"
            };
            var response = await authenticationApiClient.StartPasswordlessSmsFlow(request);
            response.Should().NotBeNull();
            response.PhoneNumber.Should().Be(request.PhoneNumber);
        }

        [Test, Explicit]
        public async Task Can_authenticate_with_passwordless_email_code()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // Arrange
            var authenticationResponse = await authenticationApiClient.Authenticate(new AuthenticationRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = "email",
                GrantType = "password",
                Scope = "openid",
                Username = "your email or phone number",
                Password = "your code"
            });
            authenticationResponse.Should().NotBeNull();
        }
    }
}