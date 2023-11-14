using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class PushedAuthorizationRequestTests
{
    [Fact]
    public async void Should_Call_OAuth_Par_With_Client_Secret()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var requestUri = new Uri("https://www.request.uri");
        var response = new PushedAuthorizationRequestResponse() { RequestUri = requestUri, ExpiresIn = 500};
        var domain = TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL");
        var expectedParams = new Dictionary<string, string>
        {
            { "client_id", TestBaseUtils.GetVariable("AUTH0_CLIENT_ID") },
            { "client_secret", TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET") }
        };

        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://{domain}/oauth/par" && ValidateRequestContent(req, expectedParams)),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));

        var tokenReponse = await authenticationApiClient.PushedAuthorizationRequestAsync(new PushedAuthorizationRequest()
        {
            ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
            ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
        });

        tokenReponse.Should().NotBeNull();
        tokenReponse.RequestUri.Should().Equals(requestUri);
    }
    
    [Fact]
    public async void Should_Call_OAuth_Par_With_Client_Assertion()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var requestUri = new Uri("https://www.request.uri");
        var response = new PushedAuthorizationRequestResponse() { RequestUri = requestUri, ExpiresIn = 500};
        var domain = TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL");
        var expectedParams = new Dictionary<string, string>
        {
            { "client_id", TestBaseUtils.GetVariable("AUTH0_CLIENT_ID") },
            { "client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer" },
        };

        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://{domain}/oauth/par" && ValidateRequestContent(req, expectedParams)),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));
        
        var provider = new RSACryptoServiceProvider(2048);
        var tokenReponse = await authenticationApiClient.PushedAuthorizationRequestAsync(new PushedAuthorizationRequest()
        {
            ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
            ClientAssertionSecurityKey = new RsaSecurityKey(provider),
            ClientAssertionSecurityKeyAlgorithm = SecurityAlgorithms.RsaSha256
        });

        tokenReponse.Should().NotBeNull();
        tokenReponse.RequestUri.Should().Equals(requestUri);
    }
    
    [Fact]
    public async void Should_Throw_When_No_Secret_Set()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var domain = TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL");

        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => authenticationApiClient.PushedAuthorizationRequestAsync(
            new PushedAuthorizationRequest()
            {
                ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
            }));

        exception.Message.Should().Be("Both Client Secret and Client Assertion can not be null.");
    }

    [Fact]
    public async void Should_Throw_When_Both_Secrets_Set()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var domain = TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL");
        
        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));
        
        var provider = new RSACryptoServiceProvider();

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => authenticationApiClient.PushedAuthorizationRequestAsync(
            new PushedAuthorizationRequest()
            {
                ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                ClientAssertionSecurityKey = new RsaSecurityKey(provider),
                ClientAssertionSecurityKeyAlgorithm = SecurityAlgorithms.RsaSha256
            }));

        exception.Message.Should().Be("Both Client Secret and Client Assertion can not be set at the same time.");

    }
  
    [Fact]
    public async void Should_Call_OAuth_Par_With_Arguments()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var requestUri = new Uri("https://www.request.uri");
        var response = new PushedAuthorizationRequestResponse() { RequestUri = requestUri, ExpiresIn = 500};
        var domain = TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL");
        var expectedParams = new Dictionary<string, string>
        {
            { "client_id", TestBaseUtils.GetVariable("AUTH0_CLIENT_ID") },
            { "client_secret", TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET") },
            { "connection", "TEST_CONNECTION" },
            { "audience", "TEST_AUDIENCE" },
            { "state", "TEST_STATE" },
            { "nonce", "TEST_NONCE" },
            { "organization", "TEST_ORGANIZATION" },
            { "invitation", "TEST_INVITATION" },
            { "scope", "TEST_SCOPE" },
        };

        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://{domain}/oauth/par" && ValidateRequestContent(req, expectedParams)),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));

        var tokenReponse = await authenticationApiClient.PushedAuthorizationRequestAsync(new PushedAuthorizationRequest()
        {
            ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
            ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
            Connection = "TEST_CONNECTION",
            Audience = "TEST_AUDIENCE",
            State = "TEST_STATE",
            Nonce = "TEST_NONCE",
            Organization = "TEST_ORGANIZATION",
            Invitation = "TEST_INVITATION",
            Scope = "TEST_SCOPE"
        });

        tokenReponse.Should().NotBeNull();
        tokenReponse.RequestUri.Should().Equals(requestUri);
    }

    [Fact]
    public async void Should_Call_OAuth_Par_With_AdditionalProperties()
    {
        var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var requestUri = new Uri("https://www.request.uri");
        var response = new PushedAuthorizationRequestResponse() { RequestUri = requestUri, ExpiresIn = 500};
        var domain = TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL");
        var expectedParams = new Dictionary<string, string>
        {
            { "client_id", TestBaseUtils.GetVariable("AUTH0_CLIENT_ID") },
            { "client_secret", TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET") },
            { "foo", "bar" },
        };

        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://{domain}/oauth/par" && ValidateRequestContent(req, expectedParams)),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json"),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));

        var tokenReponse = await authenticationApiClient.PushedAuthorizationRequestAsync(new PushedAuthorizationRequest()
        {
            ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
            ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
            AdditionalProperties = new Dictionary<string, string>
            {
                { "foo", "bar" }
            }
        });

        tokenReponse.Should().NotBeNull();
        tokenReponse.RequestUri.Should().Equals(requestUri);
    }

    
    private bool ValidateRequestContent(HttpRequestMessage content, Dictionary<string, string> contentParams)
    {
        string jsonContent = content.Content.ReadAsStringAsync().Result;
        var result = jsonContent.Split("&").ToDictionary(keyValue => keyValue.Split("=")[0], keyValue => HttpUtility.UrlDecode(keyValue.Split("=")[1]));

        return contentParams.Aggregate(true, (acc, keyValue) => acc && result.GetValueOrDefault(keyValue.Key) == keyValue.Value);
    }
}