using System;
using System.Threading.Tasks;
using Auth0.Tests.Shared;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    [TestFixture]
    public class MetadataTests : TestBase
    {
        [Test]
        public async Task Can_retrieve_saml_metadata()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // Act
            var response = await authenticationApiClient.GetSamlMetadataAsync(GetVariable("AUTH0_CLIENT_ID"));

            // Assert
            response.Should().NotBeNull();
        }

        [Test]
        public async Task Can_retrieve_wsfed_metadata()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // Act
            var response = await authenticationApiClient.GetWsFedMetadataAsync();

            // Assert
            response.Should().NotBeNull();
        }
    }
}