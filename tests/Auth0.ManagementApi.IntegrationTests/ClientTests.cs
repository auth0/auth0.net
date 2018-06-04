using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ClientTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Test_client_crud_sequence()
        {

            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = $"Integration testing {Guid.NewGuid():N}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                IsFirstParty = true,
                ClientMetaData = new
                {
                    Prop1 = "1",
                    Prop2 = "2"
                }
            };
            var newClientResponse = await _apiClient.Clients.CreateAsync(newClientRequest);
            newClientResponse.Should().NotBeNull();
            newClientResponse.Name.Should().Be(newClientRequest.Name);
            newClientResponse.TokenEndpointAuthMethod.Should().Be(TokenEndpointAuthMethod.ClientSecretPost);
            newClientResponse.ApplicationType.Should().Be(ClientApplicationType.Native);
            newClientResponse.IsFirstParty.Should().BeTrue();
            string prop1 = newClientResponse.ClientMetaData.Prop1;
            prop1.Should().Be("1");
            string prop2 = newClientResponse.ClientMetaData.Prop2;
            prop2.Should().Be("2");
            newClientResponse.GrantTypes.Should().HaveCount(i => i > 0);


            // Update the client
            var updateClientRequest = new ClientUpdateRequest
            {
                Name = $"Integration testing {Guid.NewGuid():N}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                ApplicationType = ClientApplicationType.Spa,
                GrantTypes = new string[0]
            };
            var updateClientResponse = await _apiClient.Clients.UpdateAsync(newClientResponse.ClientId, updateClientRequest);
            updateClientResponse.Should().NotBeNull();
            updateClientResponse.Name.Should().Be(updateClientRequest.Name);
            updateClientResponse.TokenEndpointAuthMethod.Should().Be(TokenEndpointAuthMethod.ClientSecretPost);
            updateClientResponse.ApplicationType.Should().Be(ClientApplicationType.Spa);
            updateClientResponse.GrantTypes.Should().HaveCount(0);

            // Get a single client
            var client = await _apiClient.Clients.GetAsync(newClientResponse.ClientId);
            client.Should().NotBeNull();
            client.Name.Should().Be(updateClientResponse.Name);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await _apiClient.Clients.DeleteAsync(client.ClientId);
            Func<Task> getFunc = async () => await _apiClient.Clients.GetAsync(client.ClientId);
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_client");
        }
        
        [Fact]
        public async Task Test_client_rotate_secret()
        {
            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = $"Integration testing {Guid.NewGuid():N}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                IsFirstParty = true,
                ClientMetaData = new
                {
                    Prop1 = "1",
                    Prop2 = "2"
                },
                ApplicationType = ClientApplicationType.Native
            };
            var newClientResponse = await _apiClient.Clients.CreateAsync(newClientRequest);
          
            // Rotate the secret
            var updateClientResponse = await _apiClient.Clients.RotateClientSecret(newClientResponse.ClientId);

            // Assert
            updateClientResponse.ClientSecret.Should().NotBe(newClientResponse.ClientSecret);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await _apiClient.Clients.DeleteAsync(newClientResponse.ClientId);
        }

        [Fact]
        public async Task Test_pagination_totals_deserialize_correctly()
        {
            var connections = await _apiClient.Clients.GetAllAsync(page: 0, perPage: 50, includeTotals: true);

            connections.Should().NotBeNull();
            connections.Paging.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_app_type_works_correctly()
        {
            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = $"Integration testing {Guid.NewGuid():N}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                IsFirstParty = true,
                ClientMetaData = new
                {
                    Prop1 = "1",
                    Prop2 = "2"
                },
                ApplicationType = ClientApplicationType.Native
            };
            var newClientResponse = await _apiClient.Clients.CreateAsync(newClientRequest);
          
            // Rotate the secret
            var connections = await _apiClient.Clients.GetAllAsync(appType: new ClientApplicationType[] { ClientApplicationType.Native });

            // Assert
            connections.Count.Should().BeGreaterThan(0);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await _apiClient.Clients.DeleteAsync(newClientResponse.ClientId);
        }

    }
}
