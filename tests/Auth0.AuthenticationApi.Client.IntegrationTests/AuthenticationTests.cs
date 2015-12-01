using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Client.Models;
using Auth0.Core;
using Auth0.ManagementApi.Client;
using Auth0.ManagementApi.Client.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.AuthenticationApi.Client.IntegrationTests
{
    [TestFixture]
    public class AuthenticationTests : TestBase
    {
        private ManagementApiClient managementApiClient;
        private Connection connection;
        private User user;

        [SetUp]
        public async Task SetUp()
        {
            managementApiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_AUTHENTICATION"), new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // We will need a connection to add the users to...
            connection = await managementApiClient.Connections.Create(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0"
            });

            // And add a dummy user to test agains
            user = await managementApiClient.Users.Create(new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "password"
            });

        }

        [TearDown]
        public async Task TearDown()
        {
            await managementApiClient.Users.Delete(user.UserId);
            await managementApiClient.Connections.Delete(connection.Id);
        }

        [Test]
        public async Task Can_authenticate_against_Auth0()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // Act
            var authenticationResponse = authenticationApiClient.Authenticate(new AuthenticationRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Connection = connection.Name,
                GrantType = "password",
                Scope = "openid",
                Username = user.UserName,
                Password = "password"
            });

            // Assert
            authenticationResponse.Should().NotBeNull();
        }    
    }
}