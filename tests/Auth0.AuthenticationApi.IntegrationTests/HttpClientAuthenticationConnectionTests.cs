using Auth0.Tests.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using Auth0.AuthenticationApi.Models.Ciba;
using FluentAssertions;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class HttpClientAuthenticationConnectionTests : TestBase
    {
        [Fact]
        public async Task Disposes_HttpClient_it_creates_on_dispose()
        {
            var connection = new HttpClientAuthenticationConnection();
            connection.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException >(() => connection.GetAsync<string>(new Uri("https://www.auth0.com")));
        }

        [Fact]
        public async Task Does_not_dispose_HttpClient_it_was_given_on_dispose()
        {
            var httpClient = new HttpClient();
            var apiConnection = new HttpClientAuthenticationConnection(httpClient);
            apiConnection.Dispose();
            await httpClient.GetAsync(new Uri("https://www.auth0.com"));
        }
        
        [Fact]
        public void AddResponseHeaders_Should_Set_Headers_When_Parsed_Response_Has_Headers()
        {
            // Arrange
            var parsedResponse = new AccessTokenResponse();
            var httpResponse = new HttpResponseMessage
            {
                Headers = { { "Test-Header", ["Value1", "Value2"] } }
            };

            // Act
            HttpClientAuthenticationConnection.AddResponseHeaders(parsedResponse, httpResponse);

            // Assert
            Assert.NotNull(parsedResponse.Headers);
            Assert.True(parsedResponse.Headers.ContainsKey("Test-Header"));
            Assert.Equal(["Value1", "Value2"], parsedResponse.Headers["Test-Header"]);
        }

        [Fact]
        public void AddResponseHeaders_Should_Not_Throw_When_Parsed_Response_Is_Null()
        {
            // Arrange
            var httpResponse = new HttpResponseMessage();

            // Act & Assert
            HttpClientAuthenticationConnection.AddResponseHeaders<object>(null, httpResponse);
        }

        [Fact]
        public void AddResponseHeaders_Should_Not_Throw_When_HttpResponse_Is_Null()
        {
            // Arrange
            var parsedResponse = new AccessTokenResponse();
        
            // Act & Assert
            HttpClientAuthenticationConnection.AddResponseHeaders(parsedResponse, null);
        }
        
        [Fact]
        public void AddResponseHeaders_Should_Not_Set_Headers_When_Parsed_Response_Does_Not_Have_Headers()
        {
            // Arrange
            var parsedResponse = new AccessTokenResponse();
            var httpResponse = new HttpResponseMessage();
            
            // Act
            HttpClientAuthenticationConnection.AddResponseHeaders(parsedResponse, httpResponse);
        
            // Assert
            // No exception should be thrown, and no headers should be set
            parsedResponse.Headers.Should().BeEmpty();
        }
        
        [Fact]
        public void AddResponseHeaders_Should_Not_Throw_When_Response_Has_No_Headers_Property()
        {
            // Arrange
            var parsedResponse = new ClientInitiatedBackchannelAuthorizationResponse();
        
            // Act & Assert
            HttpClientAuthenticationConnection.AddResponseHeaders(parsedResponse, null);
        }
    }
}
