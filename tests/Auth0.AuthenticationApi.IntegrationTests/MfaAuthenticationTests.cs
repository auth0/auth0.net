using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xunit;
using Moq;
using Moq.Protected;
using FluentAssertions;

using Auth0.AuthenticationApi.Models;
using Auth0.AuthenticationApi.Models.Mfa;
using Auth0.Core.Exceptions;
using Auth0.Tests.Shared;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class MfaAuthenticationTests : TestBase
{
    private readonly string _clientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID");
    private readonly string _clientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET");
    private readonly AuthenticationApiClient _apiClient = new(GetVariable("AUTH0_AUTHENTICATION_API_URL"));
    private readonly string _scope = "openid profile email";
    
    // Fill with actual values
    private readonly string _userName = "";
    private readonly string _password = "";
    private readonly string _realm = "";
    private readonly string _domain = GetVariable("AUTH0_AUTHENTICATION_API_URL");

    [Fact(Skip = "Requires human interaction for tenant settings and OTP")]
    public async void MFA_Enroll_Oob_And_Verify()
    {
        var mfaToken = await LoginWithAnExistingUser();
        
        // Call the associate method using the MFA token
        var resp = await _apiClient.AssociateMfaAuthenticatorAsync(
            new AssociateMfaAuthenticatorRequest()
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                OobChannels = ["sms"],
                AuthenticatorTypes = ["oob"],
                Token = mfaToken,
                PhoneNumber = "+911234567890"
            });

        string sms = "";
        // Enter the 6 digit password 
        // Call the outh2/token endpoint with the MFA token and the 6 digit password
        var token = await _apiClient.GetTokenAsync(new MfaOobTokenRequest()
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                MfaToken = mfaToken,
                OobCode = resp.OobCode,
                BindingCode = sms
            }
        );
        token.AccessToken.Should().NotBeNullOrEmpty();
    }
    
    [Fact(Skip = "Requires human interaction for tenant settings and OTP")]
    public async void MFA_Enroll_Otp_And_Verify()
    {
        // Authenticate an existing user
        var mfaToken = await LoginWithAnExistingUser();
        
        // Call the enroll method using the MFA token
        var response = await _apiClient.AssociateMfaAuthenticatorAsync(
            new AssociateMfaAuthenticatorRequest()
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                OobChannels = ["sms"],
                AuthenticatorTypes = ["otp"],
                Token = mfaToken,
                PhoneNumber = "+911234567890"
            });

        response.Secret.Should().NotBeNullOrEmpty();
        response.BarcodeUri.Should().NotBeNullOrEmpty();
        response.AuthenticatorType.Should().Be("otp");
    }

    [Fact(Skip = "Requires human interaction for tenant settings and OTP")]
    public async void MFA_Challenge_Existing_User()
    {
        var mfaToken = await LoginWithAnExistingUser();
        
        // Challenge user with multi-factor authenticator.
        var response = await _apiClient.MfaChallenge(
            new MfaChallengeRequest()
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                MfaToken = mfaToken,
                ChallengeType = "oob",
                AuthenticatorId = "authenticatorId"
            });
        
        string sms = "";
        // Enter the 6 digit password 
        // Call the outh2/token endpoint with the MFA token and the 6 digit password
        var token = await _apiClient.GetTokenAsync(new MfaOobTokenRequest()
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                MfaToken = mfaToken,
                OobCode = response.OobCode,
                BindingCode = sms
            }
        );
        token.AccessToken.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async void MFA_Enroll_With_Oob_Returns_Success()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var associateMfaMockResponse = new AssociateMfaAuthenticatorResponse()
        {
            OobCode = "OobCode",
            OobChannel = "sms",
            BindingMethod = "prompt",
            AuthenticatorType = "oob"
        };
        
        SetupMockWith(mockHandler,$"https://{_domain}/mfa/associate", 
            "{\n    \"authenticator_type\": \"oob\"," +
            "\n    \"binding_method\": \"prompt\"," +
            "\n    \"oob_channel\": \"sms\"," +
            "\n    \"oob_code\": \"OobCode\"\n}");
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(_domain, new TestHttpClientAuthenticationConnection(httpClient));

        // Act
        var response = await authenticationApiClient.AssociateMfaAuthenticatorAsync(
            new AssociateMfaAuthenticatorRequest()
            {
                ClientId = "ClientId",
                ClientSecret = "ClientSecret",
                AuthenticatorTypes = ["oob"],
                OobChannels = ["sms"],
                PhoneNumber = "+911234567890"
            });
        
        // Assert
        response.Should().BeEquivalentTo(associateMfaMockResponse);
        mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void MFA_Enroll_With_Otp_Returns_Success()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        
        SetupMockWith(
            mockHandler,
            $"https://{_domain}/mfa/associate",
            "{\n    \"authenticator_type\": \"otp\"," +
            "\n    \"secret\": \"OVMHW66KGGVITOQLO\"," +
            "\n    \"barcode_uri\": " +
            "\"otpauth://totp/Auth0.NET%20SDK%20integratist:ta.com?secret=OVMHW&issuer=Auth0.20test&algorithm=S6&period=30\"\n}");
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(_domain, new TestHttpClientAuthenticationConnection(httpClient));
        
        // Act
        var response = await authenticationApiClient.AssociateMfaAuthenticatorAsync(
            new AssociateMfaAuthenticatorRequest()
            {
                ClientId = "clientId",
                ClientSecret = "ClientSecret",
                OobChannels = ["sms"],
                AuthenticatorTypes = ["otp"],
                PhoneNumber = "+911234567890"
            });

        // Assert
        response.AuthenticatorType.Should().Be("otp");
        response.BarcodeUri.Should()
            .Be(
                "otpauth://totp/Auth0.NET%20SDK%20integratist:ta.com?secret=OVMHW&issuer=Auth0.20test&algorithm=S6&period=30");
        response.Secret.Should().Be("OVMHW66KGGVITOQLO");
        mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void MFA_Enroll_Returns_Error_When_User_Is_Already_Enrolled()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        
        SetupMockWith(
            mockHandler,
            $"https://{_domain}/mfa/associate",
            "{\n    \"error\": \"access_denied\",\n    \"error_description\": \"User is already enrolled.\"\n}",
            HttpStatusCode.Forbidden);
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(_domain, new TestHttpClientAuthenticationConnection(httpClient));

        // Act
        var ex = await Assert.ThrowsAsync<ErrorApiException>(() =>
            authenticationApiClient.AssociateMfaAuthenticatorAsync(
                new AssociateMfaAuthenticatorRequest()
                {
                    ClientId = "ClientId",
                    ClientSecret = "ClientSecret",
                    AuthenticatorTypes = ["oob"],
                    OobChannels = ["sms"],
                    PhoneNumber = "+911234567890"
                }));
         
        // Assert
         ex.StatusCode.Should().Be(HttpStatusCode.Forbidden);
         mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void MFA_Enroll_Returns_Error_When_MFA_Token_Is_Invalid()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        
        SetupMockWith(
            mockHandler,
            $"https://{_domain}/mfa/associate",
            "{\n    \"error\": \"invalid_grant\",\n    \"error_description\": \"The mfa_token provided is invalid. Try getting a new token.\"\n}",
            HttpStatusCode.Unauthorized);
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(_domain, new TestHttpClientAuthenticationConnection(httpClient));

        // Act
        var ex = await Assert.ThrowsAsync<ErrorApiException>(() =>
            authenticationApiClient.AssociateMfaAuthenticatorAsync(
                new AssociateMfaAuthenticatorRequest()
                {
                    ClientId = "ClientId",
                    ClientSecret = "ClientSecret",
                    AuthenticatorTypes = ["oob"],
                    OobChannels = ["sms"],
                    PhoneNumber = "+911234567890"
                }));
        
        // Assert
        ex.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void MFA_Confirm_Enrollment()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        
        SetupMockWith(
            mockHandler,
            $"https://{_domain}/oauth/token",
            "{\n    \"access_token\": \"eyJhbGciOiJkaXIiL..2XikmV3Rgh2RP8fp.hwH_fTY_DKmUUmJHi65gQcw.GXvHNdqTKQbX1cnadVJsAw\"," +
            "\n    \"id_token\": \"eyJhbGciOiJSUzI1NiImZxayJ9.eyJuaWNrbmFtZSI6ImthaWxhcwfQ.n-F7KgZOw6_K2m2GrJpT_zldFUcusYu8g7UvbxtfyOk-o0K0tjUL0pajRSrMLyuC6Q\"," +
            "\n    \"scope\": \"openid profile email\",\n    \"expires_in\": 86400,\n    \"token_type\": \"Bearer\"\n}");
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(_domain, new TestHttpClientAuthenticationConnection(httpClient));

        // Act
        var response = await authenticationApiClient.GetTokenAsync(new MfaOobTokenRequest()
        {
            ClientId = "clientId",
            ClientSecret = "ClientSecret",
            BindingCode = "BindingCode",
            MfaToken = "MfaToken",
            OobCode = "OobCode"
        });

        // Assert
        response.AccessToken.Should()
            .Be("eyJhbGciOiJkaXIiL..2XikmV3Rgh2RP8fp.hwH_fTY_DKmUUmJHi65gQcw.GXvHNdqTKQbX1cnadVJsAw");
        response.ExpiresIn.Should().Be(86400);
        response.TokenType.Should().Be("Bearer");
        mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void MFA_Verify_With_Oob()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        
        SetupMockWith(
            mockHandler,
            $"https://{_domain}/oauth/token",
            "{\n    \"access_token\": \"eyJhbGciOiJkaXIiL..2XikmV3Rgh2RP8fp.hwH_fTY_DKmUUmJHi65gQcw.GXvHNdqTKQbX1cnadVJsAw\"," +
            "\n    \"id_token\": \"eyJhbGciOiJSUzI1NiImZxayJ9.eyJuaWNrbmFtZSI6ImthaWxhcwfQ.n-F7KgZOw6_K2m2GrJpT_zldFUcusYu8g7UvbxtfyOk-o0K0tjUL0pajRSrMLyuC6Q\"," +
            "\n    \"scope\": \"openid profile email\",\n    \"expires_in\": 86400,\n    \"token_type\": \"Bearer\"\n}");
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(_domain, new TestHttpClientAuthenticationConnection(httpClient));

        // Act
        var response = await authenticationApiClient.GetTokenAsync(new MfaOobTokenRequest()
        {
            ClientId = "clientId",
            ClientSecret = "ClientSecret",
            BindingCode = "BindingCode",
            MfaToken = "MfaToken",
            OobCode = "OobCode"
        });

        // Assert
        response.AccessToken.Should()
            .Be("eyJhbGciOiJkaXIiL..2XikmV3Rgh2RP8fp.hwH_fTY_DKmUUmJHi65gQcw.GXvHNdqTKQbX1cnadVJsAw");
        response.ExpiresIn.Should().Be(86400);
        response.TokenType.Should().Be("Bearer");
        mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void MFA_Verify_With_Otp()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        
        SetupMockWith(
            mockHandler,
            $"https://{_domain}/oauth/token",
            "{\n    \"access_token\": \"eyJhbGciOiJkaXIiL..2XikmV3Rgh2RP8fp.hwH_fTY_DKmUUmJHi65gQcw.GXvHNdqTKQbX1cnadVJsAw\"," +
            "\n    \"id_token\": \"eyJhbGciOiJSUzI1NiImZxayJ9.eyJuaWNrbmFtZSI6ImthaWxhcwfQ.n-F7KgZOw6_K2m2GrJpT_zldFUcusYu8g7UvbxtfyOk-o0K0tjUL0pajRSrMLyuC6Q\"," +
            "\n    \"scope\": \"openid profile email\",\n    \"expires_in\": 86400,\n    \"token_type\": \"Bearer\"\n}");
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(_domain, new TestHttpClientAuthenticationConnection(httpClient));

        // Act
        var response = await authenticationApiClient.GetTokenAsync(new MfaOtpTokenRequest()
        {
            ClientId = "clientId",
            ClientSecret = "ClientSecret",
            MfaToken = "MfaToken",
            Otp = "123456"
        });

        // Assert
        response.AccessToken.Should()
            .Be("eyJhbGciOiJkaXIiL..2XikmV3Rgh2RP8fp.hwH_fTY_DKmUUmJHi65gQcw.GXvHNdqTKQbX1cnadVJsAw");
        response.ExpiresIn.Should().Be(86400);
        response.TokenType.Should().Be("Bearer");
        mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void MFA_Verify_With_RecoveryCode()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        
        SetupMockWith(
            mockHandler,
            $"https://{_domain}/oauth/token",
            "{\n    \"access_token\": \"eyJhbGciOiJkaXIiL..2XikmV3Rgh2RP8fp.hwH_fTY_DKmUUmJHi65gQcw.GXvHNdqTKQbX1cnadVJsAw\"," +
            "\n    \"id_token\": \"eyJhbGciOiJSUzI1NiImZxayJ9.eyJuaWNrbmFtZSI6ImthaWxhcwfQ.n-F7KgZOw6_K2m2GrJpT_zldFUcusYu8g7UvbxtfyOk-o0K0tjUL0pajRSrMLyuC6Q\"," +
            "\n    \"scope\": \"openid profile email\",\n    \"expires_in\": 86400,\n    \"token_type\": \"Bearer\"\n}");
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(_domain, new TestHttpClientAuthenticationConnection(httpClient));

        // Act
        var response = await authenticationApiClient.GetTokenAsync(new MfaRecoveryCodeRequest()
        {
            ClientId = "clientId",
            ClientSecret = "ClientSecret",
            MfaToken = "MfaToken",
            RecoveryCode = "123456"
        });

        // Assert
        response.AccessToken.Should()
            .Be("eyJhbGciOiJkaXIiL..2XikmV3Rgh2RP8fp.hwH_fTY_DKmUUmJHi65gQcw.GXvHNdqTKQbX1cnadVJsAw");
        response.ExpiresIn.Should().Be(86400);
        response.TokenType.Should().Be("Bearer");
        mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void MFA_List_Enrollments()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        
        SetupMockWith(
            mockHandler,
            $"https://{_domain}/mfa/authenticators",
            "[\n    " +
            "{\n        \"id\": \"sms|dev_JSvnXK5pWhKPPprk\",\n        \"authenticator_type\": \"oob\"," +
            "\n        \"active\": true,\n        \"oob_channel\": \"sms\",\n        \"name\": \"XXXXXXXXX0368\"\n    }\n]");
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(_domain, new TestHttpClientAuthenticationConnection(httpClient));

        // Act
        var response = 
            await authenticationApiClient.ListMfaAuthenticatorsAsync("accessToken-or-mfaToken");

        // Assert
        response.Count.Should().Be(1);
        response.First().AuthenticatorType.Should().Be("oob");
        response.First().Active.Should().Be(true);
        response.First().OobChannel.Should().Be("sms");
        response.First().Name.Should().NotBeNullOrEmpty();
        response.First().Id.Should().NotBeNullOrEmpty();
        
        mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void MFA_Remove_Enrollments()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        
        SetupMockWith(mockHandler, $"https://{_domain}/mfa/authenticators/id-random", "");
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(_domain, new TestHttpClientAuthenticationConnection(httpClient));

        // Assert
        await authenticationApiClient.DeleteMfaAuthenticatorAsync(
            new DeleteMfaAuthenticatorRequest()
            {
                AccessToken = "AccessToken",
                AuthenticatorId = "id-random"
            });
        
        // Act
        mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void MFA_Challenge()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        
        SetupMockWith(mockHandler, $"https://{_domain}/mfa/challenge", "{\n    \"challenge_type\": \"oob\",\n    \"oob_code\": \"random_oob_code\",\n    \"binding_method\": \"prompt\"\n}");
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient =
            new TestAuthenticationApiClient(_domain, new TestHttpClientAuthenticationConnection(httpClient));

        // Assert
        var response = await authenticationApiClient.MfaChallenge( 
            new MfaChallengeRequest()
            {
                AuthenticatorId = "id|auth-id",
                ChallengeType = "oob",
                ClientId = "clientId",
                ClientSecret = "ClientSecret",
                MfaToken = "MfaToken"
            });

        // Act
        response.BindingMethod.Should().Be("prompt");
        response.ChallengeType.Should().Be("oob");
        response.OobCode.Should().Be("random_oob_code");
        mockHandler.VerifyAll();
    }
    
    private static void SetupMockWith(Mock<HttpMessageHandler> mockHandler, string domain, string stringContent, HttpStatusCode code = HttpStatusCode.OK)
    {
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == domain),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = code,
                Content = new StringContent(stringContent, Encoding.UTF8, "application/json"),
            });
    }
    private async Task<string> LoginWithAnExistingUser()
    {
        // Fill with actual values
        var userName = "";
        var password = "";
        var realm = "";
        var scope = "openid profile email";
        string mfaToken = "";
        try
        {
            // Login with an existing user.
            await _apiClient.GetTokenAsync(new ResourceOwnerTokenRequest()
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                Username = userName,
                Password = password,
                Scope = scope,
                Realm = realm
            });
        }
        catch (ErrorApiException ex)
        {
            // Indicates that MFA is required.
            mfaToken = ex.ApiError.ExtraData["mfa_token"];
        }

        return mfaToken;
    }
}