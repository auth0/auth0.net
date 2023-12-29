using System.Linq;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class MfaTests : TestBase
    {
        public MfaTests()
        {
            _authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));
        }

        private readonly AuthenticationApiClient _authenticationApiClient;

        [Fact(Skip = "Run manually")]
        public async Task Invoking_Delete_ShouldNotThrow()
        {
            await _authenticationApiClient.Invoking(
                x => x.DeleteMfaAuthenticatorAsync(
                    new DeleteMfaAuthenticatorRequest()
                    {
                        AccessToken = GetVariable("MFA_ACCESS_TOKEN"),
                        AuthenticatorId = GetVariable("AUTHENTICATOR_ID")
                    })).Should().NotThrowAsync();
        }

        [Fact(Skip = "Run manually")]
        public async Task Should_Return_Authenticators()
        {
            var response = await _authenticationApiClient.ListAuthenticatorsAsync(
                GetVariable("MFA_ACCESS_TOKEN")
            );

            response.Should().NotBeNullOrEmpty();
            response.First().AuthenticatorType.Should().NotBeNullOrEmpty();
            response.First().OobChannel.Should().NotBeNullOrEmpty();
            response.First().Id.Should().NotBeNullOrEmpty();
            response.First().Name.Should().NotBeNullOrEmpty();
        }
    }
}
