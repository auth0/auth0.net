using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using FluentAssertions;
using Auth0.AuthenticationApi.Models.Ciba;
using Auth0.Core.Exceptions;
using Auth0.Tests.Shared;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class ClientInitiatedBackchannelAuthorizationTests : TestBase
{
    [Fact]
    public async void Ciba_request_should_succeed()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var mockResponse = new ClientInitiatedBackchannelAuthorizationResponse()
        {
            AuthRequestId = "Random-Guid",
            ExpiresIn = 300
        };
        
        var mockTokenResponse = new ClientInitiatedBackchannelAuthorizationTokenResponse()
        {
            AccessToken = "This is a mock access_token",
            IdToken = "This is a mock ID token",
            ExpiresIn = 300,
            Scope = "openid"
        };
        var domain = GetVariable("AUTH0_AUTHENTICATION_API_URL");
        
        SetupMockWith(mockHandler,$"https://{domain}/bc-authorize", JsonConvert.SerializeObject(mockResponse));
        SetupMockWith(mockHandler,$"https://{domain}/oauth/token", JsonConvert.SerializeObject(mockTokenResponse));
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));

        var response = await authenticationApiClient.ClientInitiatedBackchannelAuthorization(
            new ClientInitiatedBackchannelAuthorizationRequest()
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Scope = "openid profile",
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                BindingMessage = "BindingMessage",
                LoginHint = new LoginHint()
                {
                    Format = "iss_sub",
                    Issuer = "https://dx-sdks-testing.us.auth0.com/",
                    Subject = "auth0|6746de965777c7fc70547a11"
                }
            }
        );

        response.ExpiresIn.Should().Be(300);
        response.AuthRequestId.Should().Be("Random-Guid");

        var cibaTokenResponse = await authenticationApiClient.GetTokenAsync(
            new ClientInitiatedBackchannelAuthorizationTokenRequest()
            {
                AuthRequestId = "Random-Guid",
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            }
        );
        cibaTokenResponse.Should().BeEquivalentTo(cibaTokenResponse);
        mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void Ciba_request_in_pending_state()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var mockResponse = new ClientInitiatedBackchannelAuthorizationResponse()
        {
            AuthRequestId = "Random-Guid",
            ExpiresIn = 300
        };

        var mockTokenResponse =
            "{\"error\": \"authorization_pending\",\n\"error_description\": \"The end-user authorization is pending\"\n}";
        
        var domain = GetVariable("AUTH0_AUTHENTICATION_API_URL");
        
        SetupMockWith(mockHandler,$"https://{domain}/bc-authorize", JsonConvert.SerializeObject(mockResponse));
        SetupMockWith(mockHandler,$"https://{domain}/oauth/token", JsonConvert.SerializeObject(mockTokenResponse), HttpStatusCode.BadRequest);
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));

        var response = await authenticationApiClient.ClientInitiatedBackchannelAuthorization(
            new ClientInitiatedBackchannelAuthorizationRequest()
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Scope = "openid profile",
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                BindingMessage = "BindingMessage",
                LoginHint = new LoginHint()
                {
                    Format = "iss_sub",
                    Issuer = "https://dx-sdks-testing.us.auth0.com/",
                    Subject = "auth0|6746de965777c7fc70547a11"
                }
            }
        );

        response.ExpiresIn.Should().Be(300);
        response.AuthRequestId.Should().Be("Random-Guid");

        var ex = await Assert.ThrowsAsync<ErrorApiException>(() => authenticationApiClient.GetTokenAsync(
            new ClientInitiatedBackchannelAuthorizationTokenRequest()
            {
                AuthRequestId = "Random-Guid",
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            }
        ));
        mockHandler.VerifyAll();
    }
    
    [Fact]
    public async void Ciba_request_in_expired_or_rejected_state()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var mockResponse = new ClientInitiatedBackchannelAuthorizationResponse()
        {
            AuthRequestId = "Random-Guid",
            ExpiresIn = 300
        };

        var mockTokenResponse =
            "{\n\"error\": \"access_denied\",\n\"error_description\": \"The end-user denied the authorization request or it\nhas been expired\"\n}";
        
        var domain = GetVariable("AUTH0_AUTHENTICATION_API_URL");
        
        SetupMockWith(mockHandler,$"https://{domain}/bc-authorize", JsonConvert.SerializeObject(mockResponse));
        SetupMockWith(mockHandler,$"https://{domain}/oauth/token", JsonConvert.SerializeObject(mockTokenResponse), HttpStatusCode.BadRequest);
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));

        var response = await authenticationApiClient.ClientInitiatedBackchannelAuthorization(
            new ClientInitiatedBackchannelAuthorizationRequest()
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Scope = "openid profile",
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                BindingMessage = "BindingMessage",
                LoginHint = new LoginHint()
                {
                    Format = "iss_sub",
                    Issuer = "https://dx-sdks-testing.us.auth0.com/",
                    Subject = "auth0|6746de965777c7fc70547a11"
                }
            }
        );

        response.ExpiresIn.Should().Be(300);
        response.AuthRequestId.Should().Be("Random-Guid");

        var ex = await Assert.ThrowsAsync<ErrorApiException>(() => authenticationApiClient.GetTokenAsync(
            new ClientInitiatedBackchannelAuthorizationTokenRequest()
            {
                AuthRequestId = "Random-Guid",
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            }
        ));
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
}