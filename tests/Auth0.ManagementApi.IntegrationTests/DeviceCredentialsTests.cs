using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Auth0.Tests.Shared;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class DeviceCredentialsTests : TestBase
    {
        /*private Client _client;
        private Connection _connection;
        private User _user;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";*/

        /*public async Task InitializeAsync()
        {
            using (var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), GetVariable("AUTH0_MANAGEMENT_API_URL")))
            {
                // Set up the correct Client, Connection and User
                _client = await apiClient.Clients.CreateAsync(new ClientCreateRequest
                {
                Name = $"{TestingConstants.ClientPrefix} {MakeRandomName()}",
                });
                _connection = await apiClient.Connections.CreateAsync(new ConnectionCreateRequest
                {
                    Name = $"{TestingConstants.ConnectionPrefix}-{MakeRandomName()}",
                    Strategy = "auth0",
                    EnabledClients = new[] { _client.ClientId }
                });
                _user = await apiClient.Users.CreateAsync(new UserCreateRequest
                {
                    Connection = _connection.Name,
                    Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                    EmailVerified = true,
                    Password = Password
                });
            }
        }

        public async Task DisposeAsync()
        {
            using (var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), GetVariable("AUTH0_MANAGEMENT_API_URL")))
            {
                await apiClient.Clients.DeleteAsync(_client.ClientId);
                await apiClient.Connections.DeleteAsync(_connection.Id);
                await apiClient.Users.DeleteAsync(_user.UserId);
            }
        }

        [Fact(Skip = "Can't create device credentials using management API v2 token")]
        public async Task Test_device_credentials_crud_sequence()
        {
            using (var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), GetVariable("AUTH0_MANAGEMENT_API_URL")))
            {
                //Get all the device credentials
                var credentialsBefore = await apiClient.DeviceCredentials.GetAllAsync();

                //Create a new device credential
                var newCredentialRequest = new DeviceCredentialCreateRequest
                {
                    DeviceName = Guid.NewGuid().ToString("N"),
                    DeviceId = Guid.NewGuid().ToString("N"),
                    ClientId = _client.ClientId,
                    Type = "public_key",
                    Value = "new-key-value"
                };
                var newCredentialResponse = await apiClient.DeviceCredentials.CreateAsync(newCredentialRequest);
                newCredentialResponse.Should().NotBeNull();
                newCredentialResponse.DeviceId.Should().Be(newCredentialRequest.DeviceId);
                newCredentialResponse.DeviceName.Should().Be(newCredentialRequest.DeviceName);
                newCredentialResponse.ClientId.Should().Be(newCredentialRequest.ClientId);

                // Check that we now have one more device credential
                var credentialsAfterCreate = await apiClient.DeviceCredentials.GetAllAsync();
                credentialsAfterCreate.Count.Should().Be(credentialsBefore.Count + 1);

                // Delete the device credential
                await apiClient.DeviceCredentials.DeleteAsync(newCredentialResponse.Id);

                // Check that we now have one less device credential
                var credentialsAfterDelete = await apiClient.DeviceCredentials.GetAllAsync();
                credentialsAfterDelete.Count.Should().Be(credentialsAfterCreate.Count - 1);
            }
        }*/

        [Fact]
        public async Task Can_request_device_credentials_using_pagination()
        {
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var response = new PagedList<DeviceCredential> { new DeviceCredential { DeviceName = "Test" } };
            var token = "AUTH0_TOKEN_DEVICE_CREDENTIALS";
            var domain = GetVariable("AUTH0_MANAGEMENT_API_URL");

            var request = new GetDeviceCredentialsRequest
            {
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Type = "rotating_refresh_token",
                UserId = "google-oauth2|109627300720782495235",
                Fields = "name,email",
            };
            var paginationInfo = new PaginationInfo(0, 25, true);

            var expectedParams = new Dictionary<string, string>
            {
                {"fields", request.Fields},
                {"include_fields", request.IncludeFields.ToString().ToLower()},
                {"user_id", request.UserId},
                {"client_id", request.ClientId},
                {"type", request.Type},
                {"page", paginationInfo.PageNo.ToString()},
                {"per_page", paginationInfo.PerPage.ToString()},
                {"include_totals", paginationInfo.IncludeTotals.ToString().ToLower()}
            };

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString().StartsWith($"https://{domain}/api/v2/device-credentials") && ValidateRequestContent(req, expectedParams)),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json"),
                });

            var httpClient = new HttpClient(mockHandler.Object);
            var managementApiClient = new ManagementApiClient(token, new Uri($"https://{domain}/api/v2"), new HttpClientManagementConnection(httpClient));

            var deviceCredentials = await managementApiClient.DeviceCredentials.GetAllAsync(request, paginationInfo);

            response.Should().NotBeNull();
            response[0].DeviceName.Should().Equals("Test");
        }

        private bool ValidateRequestContent(HttpRequestMessage content, Dictionary<string, string> contentParams)
        {
            var result = content.RequestUri.Query.TrimStart('?').Split("&").ToDictionary(keyValue => keyValue.Split("=")[0], keyValue => HttpUtility.UrlDecode(keyValue.Split("=")[1]));

            return contentParams.Aggregate(true, (acc, keyValue) => acc && result.GetValueOrDefault(keyValue.Key) == keyValue.Value);
        }
    }
}