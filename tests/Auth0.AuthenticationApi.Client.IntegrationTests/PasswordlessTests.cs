﻿using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Client.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.AuthenticationApi.Client.IntegrationTests
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
                Email = "your email here",
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
                Email = "your email here",
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
                PhoneNumber = "your number here"
            };
            var response = await authenticationApiClient.StartPasswordlessSmsFlow(request);
            response.Should().NotBeNull();
            response.PhoneNumber.Should().Be(request.PhoneNumber);
        }
    }
}