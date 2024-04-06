using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class MfaTests : TestBase
    {
        private readonly AuthenticationApiClient _authenticationApiClient;

        public MfaTests()
        {
            _authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));
        }

        [Fact(Skip = "Run manually")]
        public async Task Should_Receive_Associate_Response_For_Sms_Mfa_Enrollment()
        {
            var request =
                new AssociateMfaAuthenticatorRequest()
                {
                    Token = TestBaseUtils.GetVariable("AUTH0_AUTHENTICATOR_ENROLL_TOKEN"),
                    ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                    ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                    AuthenticatorTypes = new List<string>() { "oob" },
                    OobChannels = new List<string>() { "sms" },
                    PhoneNumber = TestBaseUtils.GetVariable("MFA_PHONE_NUMBER")
                };
            var response = await _authenticationApiClient.AssociateMfaAuthenticatorAsync(request);
            response.Should().NotBeNull();
            response.AuthenticatorType.Should().Be("oob");
            response.BindingMethod.Should().Be("prompt");
            response.OobChannel.Should().Be("sms");

            response.OobCode.Should().NotBeNullOrEmpty().And.StartWith("Fe26.");
        }

        [Fact(Skip = "Run manually")]
        public async Task Should_Receive_MfaOobTokenResponse_For_Oob_Mfa_Verification()
        {
            var request = new MfaOobTokenRequest()
            {
                ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                MfaToken = TestBaseUtils.GetVariable("MFA_TOKEN"),
                OobCode = TestBaseUtils.GetVariable("MFA_OOB_CODE"),
                BindingCode = TestBaseUtils.GetVariable("MFA_BINDING_CODE")
            };

            var response = await _authenticationApiClient.GetTokenAsync(request);
            response.Should().NotBeNull();
            response.AccessToken.Should().StartWith("ey");
            response.ExpiresIn.Should().BeGreaterThan(0);
            response.TokenType.Should().Be("Bearer");
        }
    }
}
