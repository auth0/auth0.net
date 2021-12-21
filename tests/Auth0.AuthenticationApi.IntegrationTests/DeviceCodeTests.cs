using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Xunit;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class DeviceCodeTests : TestBase
    {

        [Fact(Skip = "Run manual")]
        public async Task Can_start_device_flow_and_request_token_using_device_code()
        {
            // Replace domain and clientId with the correct values.
            // Ensure Device Code Grant is enabled.
            var domain = "";
            var clientId = "";

            var request = new DeviceCodeRequest
            {
                ClientId = clientId,
                Scope = "openid profile"
            };
            var authenticationApiClient = new AuthenticationApiClient(domain);
            var response = await authenticationApiClient.StartDeviceFlowAsync(request);

            response.Should().NotBeNull();

            // Visit response.VerificationUriComplete and confirm the code before continuing.
            Debugger.Break();

            var tokenReponse = await authenticationApiClient.GetTokenAsync(new DeviceCodeTokenRequest
            {
                ClientId = clientId,
                DeviceCode = response.DeviceCode
            });

            tokenReponse.Should().NotBeNull();
        }

        [SkippableFact]
        public async Task Can_start_device_flow()
        {
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var deviceCode = "TEST_CODE";
            var response = new DeviceCodeResponse { DeviceCode = deviceCode };
            var domain = GetVariable("AUTH0_AUTHENTICATION_API_URL");
            var expectedParams = new Dictionary<string, string>
            {
                { "audience", "Test" },
                { "scope", "openid profile" },
                { "client_id", GetVariable("AUTH0_CLIENT_ID") }
            };

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://{domain}/oauth/device/code" && ValidateRequestContent(req, expectedParams)),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json"),
                });

            var httpClient = new HttpClient(mockHandler.Object);
            var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));

            var tokenReponse = await authenticationApiClient.StartDeviceFlowAsync(new DeviceCodeRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Scope = "openid profile",
                Audience = "Test"
            });

            tokenReponse.Should().NotBeNull();
            tokenReponse.DeviceCode.Should().Equals(deviceCode);
        }

        [SkippableFact]
        public async Task Can_request_token_using_device_code()
        {
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var accessToken = "TEST_ACCESSTOKEN";
            var response = new AccessTokenResponse { AccessToken = accessToken };
            var domain = GetVariable("AUTH0_AUTHENTICATION_API_URL");
            var deviceCode = "TEST_CODE";
            var expectedParams = new Dictionary<string, string>
            {
                { "grant_type", "urn:ietf:params:oauth:grant-type:device_code" },
                { "device_code", deviceCode },
                { "client_id", GetVariable("AUTH0_CLIENT_ID") }
            };

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == $"https://{domain}/oauth/token" && ValidateRequestContent(req, expectedParams)),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json"),
                });

            var httpClient = new HttpClient(mockHandler.Object);
            var authenticationApiClient = new TestAuthenticationApiClient(domain, new TestHttpClientAuthenticationConnection(httpClient));

            var tokenReponse = await authenticationApiClient.GetTokenAsync(new DeviceCodeTokenRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                DeviceCode = deviceCode
            });

            tokenReponse.Should().NotBeNull();
            tokenReponse.AccessToken.Should().Equals(accessToken);
        }

        private bool ValidateRequestContent(HttpRequestMessage content, Dictionary<string, string> contentParams)
        {
            string jsonContent = content.Content.ReadAsStringAsync().Result;
            var result = jsonContent.Split("&").ToDictionary(keyValue => keyValue.Split("=")[0], keyValue => HttpUtility.UrlDecode(keyValue.Split("=")[1]));

            return contentParams.Aggregate(true, (acc, keyValue) => acc && result.GetValueOrDefault(keyValue.Key) == keyValue.Value);
        }
    }
}