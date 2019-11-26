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
                },
                InitiateLoginUri = "https://create.com/login"
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
            newClientResponse.InitiateLoginUri.Should().Be("https://create.com/login");

            // Update the client
            var updateClientRequest = new ClientUpdateRequest
            {
                Name = $"Integration testing {Guid.NewGuid():N}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                ApplicationType = ClientApplicationType.Spa,
                GrantTypes = Array.Empty<string>(),
                InitiateLoginUri = "https://update.com/login"
            };
            var updateClientResponse = await _apiClient.Clients.UpdateAsync(newClientResponse.ClientId, updateClientRequest);
            updateClientResponse.Should().NotBeNull();
            updateClientResponse.Name.Should().Be(updateClientRequest.Name);
            updateClientResponse.TokenEndpointAuthMethod.Should().Be(TokenEndpointAuthMethod.ClientSecretPost);
            updateClientResponse.ApplicationType.Should().Be(ClientApplicationType.Spa);
            updateClientResponse.GrantTypes.Should().HaveCount(0);
            updateClientResponse.InitiateLoginUri.Should().Be("https://update.com/login");

            // Get a single client
            var client = await _apiClient.Clients.GetAsync(newClientResponse.ClientId);
            client.Should().NotBeNull();
            client.Name.Should().Be(updateClientResponse.Name);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await _apiClient.Clients.DeleteAsync(client.ClientId);
            Func<Task> getFunc = async () => await _apiClient.Clients.GetAsync(client.ClientId);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_client");
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
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var clients = await _apiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo());

            // Assert
            Assert.Null(clients.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var clients = await _apiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(clients.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var clients = await _apiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(clients.Paging);
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
            var connections = await _apiClient.Clients.GetAllAsync(new GetClientsRequest
            {
                AppType = new[] {ClientApplicationType.Native}
            }, new PaginationInfo());

            // Assert
            connections.Count.Should().BeGreaterThan(0);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await _apiClient.Clients.DeleteAsync(newClientResponse.ClientId);
        }

    }
}
