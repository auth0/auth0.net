using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using FluentAssertions;
using Auth0.AuthenticationApi.Models;
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

    [Fact]
    public async void Ciba_request_should_send_authorization_details_and_requested_expiry()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var mockResponse = new ClientInitiatedBackchannelAuthorizationResponse()
        {
            AuthRequestId = "Random-Guid",
            ExpiresIn = 300
        };
        var domain = GetVariable("AUTH0_AUTHENTICATION_API_URL");

        var expectedParams = new Dictionary<string, string>
        {
            { "requested_expiry", "120" },
            { "authorization_details", "[{\"type\":\"payment_initiation\"}]" }
        };

        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://{domain}/bc-authorize" && ValidateRequestContent(req, expectedParams)),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(mockResponse), Encoding.UTF8, "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));

        var response = await authenticationApiClient.ClientInitiatedBackchannelAuthorization(
            new ClientInitiatedBackchannelAuthorizationRequest()
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Scope = "openid profile",
                ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                BindingMessage = "BindingMessage",
                RequestExpiry = 120,
                AuthorizationDetailsObjects = new List<AuthorizationDetail>
                {
                    new AuthorizationDetail { Type = "payment_initiation" }
                },
                LoginHint = new LoginHint()
                {
                    Format = "iss_sub",
                    Issuer = "https://dx-sdks-testing.us.auth0.com/",
                    Subject = "auth0|6746de965777c7fc70547a11"
                }
            }
        );

        response.AuthRequestId.Should().Be("Random-Guid");
        mockHandler.VerifyAll();
    }

    [Fact]
    public async void Ciba_token_response_should_expose_typed_authorization_details()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var mockResponse = new ClientInitiatedBackchannelAuthorizationResponse()
        {
            AuthRequestId = "Random-Guid",
            ExpiresIn = 300
        };

        var mockTokenResponse =
            "{\"access_token\":\"mock\",\"token_type\":\"Bearer\",\"expires_in\":300," +
            "\"authorization_details\":[{\"type\":\"payment_initiation\",\"amount\":\"100\"}]}";

        var domain = GetVariable("AUTH0_AUTHENTICATION_API_URL");

        SetupMockWith(mockHandler, $"https://{domain}/bc-authorize", JsonConvert.SerializeObject(mockResponse));
        SetupMockWith(mockHandler, $"https://{domain}/oauth/token", mockTokenResponse);

        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));

        await authenticationApiClient.ClientInitiatedBackchannelAuthorization(
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

        var cibaTokenResponse = await authenticationApiClient.GetTokenAsync(
            new ClientInitiatedBackchannelAuthorizationTokenRequest()
            {
                AuthRequestId = "Random-Guid",
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            }
        );

        cibaTokenResponse.AuthorizationDetails.Should().NotBeNull();
        cibaTokenResponse.AuthorizationDetails.Should().HaveCount(1);
        cibaTokenResponse.AuthorizationDetails[0].Type.Should().Be("payment_initiation");
        cibaTokenResponse.AuthorizationDetails[0].AdditionalData["amount"].GetString().Should().Be("100");
        mockHandler.VerifyAll();
    }

    [Fact]
    public async void Ciba_token_response_typed_authorization_details_should_handle_type_only_entry()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var mockResponse = new ClientInitiatedBackchannelAuthorizationResponse()
        {
            AuthRequestId = "Random-Guid",
            ExpiresIn = 300
        };

        var mockTokenResponse =
            "{\"access_token\":\"mock\",\"token_type\":\"Bearer\",\"expires_in\":300," +
            "\"authorization_details\":[{\"type\":\"payment_initiation\"}]}";

        var domain = GetVariable("AUTH0_AUTHENTICATION_API_URL");

        SetupMockWith(mockHandler, $"https://{domain}/bc-authorize", JsonConvert.SerializeObject(mockResponse));
        SetupMockWith(mockHandler, $"https://{domain}/oauth/token", mockTokenResponse);

        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));

        await authenticationApiClient.ClientInitiatedBackchannelAuthorization(
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

        var cibaTokenResponse = await authenticationApiClient.GetTokenAsync(
            new ClientInitiatedBackchannelAuthorizationTokenRequest()
            {
                AuthRequestId = "Random-Guid",
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            }
        );

        cibaTokenResponse.AuthorizationDetails.Should().NotBeNull();
        cibaTokenResponse.AuthorizationDetails.Should().HaveCount(1);
        cibaTokenResponse.AuthorizationDetails[0].Type.Should().Be("payment_initiation");
        cibaTokenResponse.AuthorizationDetails[0].AdditionalData.Should().NotBeNull();
        cibaTokenResponse.AuthorizationDetails[0].AdditionalData.Should().BeEmpty();
        mockHandler.VerifyAll();
    }

    private static bool ValidateRequestContent(HttpRequestMessage content, Dictionary<string, string> contentParams)
    {
        string jsonContent = content.Content.ReadAsStringAsync().Result;
        var result = jsonContent.Split('&').ToDictionary(keyValue => keyValue.Split('=')[0], keyValue => HttpUtility.UrlDecode(keyValue.Split('=')[1]));

        return contentParams.Aggregate(true, (acc, keyValue) => acc && result.GetValueOrDefault(keyValue.Key) == keyValue.Value);
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