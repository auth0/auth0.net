using System.Threading.Tasks;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class MetadataTests : TestBase
    {
        [Fact(Skip = "Need to fix!!!")]
        public async Task Can_retrieve_saml_metadata()
        {
            // Arrange
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // Act
            var response = await authenticationApiClient.GetSamlMetadataAsync(GetVariable("AUTH0_CLIENT_ID"));

            // Assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async Task Can_retrieve_wsfed_metadata()
        {
            // Arrange
            using (var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL")))
            {
                // Act
                var response = await authenticationApiClient.GetWsFedMetadataAsync();

                // Assert
                response.Should().NotBeNull();
            }
        }
    }
}