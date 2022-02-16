using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ClientTests : ManagementTestBase, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        public override Task DisposeAsync()
        {
            return CleanupAndDisposeAsync(CleanUpType.Clients);
        }

        [Fact]
        public async Task Test_client_crud_sequence()
        {
            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = $"{TestingConstants.ClientPrefix} {MakeRandomName()}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                IsFirstParty = true,
                ClientMetaData = new
                {
                    Prop1 = "1",
                    Prop2 = "2"
                },
                InitiateLoginUri = "https://create.com/login",
                RefreshToken = new RefreshToken
                {
                    ExpirationType = RefreshTokenExpirationType.NonExpiring,
                    RotationType = RefreshTokenRotationType.NonRotating
                },
                OidcConformant = true,
                GrantTypes = new[] { "refresh_token" },
                OrganizationUsage = OrganizationUsage.Require,
                OrganizationRequireBehavior = OrganizationRequireBehavior.PreLoginPrompt
            };
            var newClientResponse = await ApiClient.Clients.CreateAsync(newClientRequest);
            newClientResponse.Should().NotBeNull();
            newClientResponse.Name.Should().Be(newClientRequest.Name);
            newClientResponse.TokenEndpointAuthMethod.Should().Be(TokenEndpointAuthMethod.ClientSecretPost);
            newClientResponse.ApplicationType.Should().Be(ClientApplicationType.Native);
            newClientResponse.IsFirstParty.Should().BeTrue();
            newClientResponse.RefreshToken.Should().NotBeNull();
            newClientResponse.RefreshToken.ExpirationType.Should().Be(newClientRequest.RefreshToken.ExpirationType);
            newClientResponse.RefreshToken.RotationType.Should().Be(newClientRequest.RefreshToken.RotationType);
            newClientResponse.OrganizationUsage.Should().Be(OrganizationUsage.Require);
            newClientResponse.OrganizationRequireBehavior.Should().Be(OrganizationRequireBehavior.PreLoginPrompt);

            string prop1 = newClientResponse.ClientMetaData.Prop1;
            prop1.Should().Be("1");
            string prop2 = newClientResponse.ClientMetaData.Prop2;
            prop2.Should().Be("2");
            newClientResponse.GrantTypes.Should().HaveCount(1);
            newClientResponse.InitiateLoginUri.Should().Be("https://create.com/login");

            // Update the client
            var updateClientRequest = new ClientUpdateRequest
            {
                Name = $"{TestingConstants.ClientPrefix} {MakeRandomName()}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                ApplicationType = ClientApplicationType.Spa,
                GrantTypes = new[] { "refresh_token", "authorization_code" },
                InitiateLoginUri = "https://update.com/login",
                RefreshToken = new RefreshToken
                {
                    ExpirationType = RefreshTokenExpirationType.Expiring,
                    RotationType = RefreshTokenRotationType.Rotating,
                    TokenLifetime = 3600,
                    Leeway = 1800
                },
                OrganizationRequireBehavior = OrganizationRequireBehavior.NoPrompt
            };
            var updateClientResponse = await ApiClient.Clients.UpdateAsync(newClientResponse.ClientId, updateClientRequest);
            updateClientResponse.Should().NotBeNull();
            updateClientResponse.Name.Should().Be(updateClientRequest.Name);
            updateClientResponse.TokenEndpointAuthMethod.Should().Be(TokenEndpointAuthMethod.ClientSecretPost);
            updateClientResponse.ApplicationType.Should().Be(ClientApplicationType.Spa);
            updateClientResponse.GrantTypes.Should().HaveCount(2);
            updateClientResponse.InitiateLoginUri.Should().Be("https://update.com/login");
            updateClientResponse.RefreshToken.Should().NotBeNull();
            updateClientResponse.RefreshToken.RotationType.Should().Be(updateClientRequest.RefreshToken.RotationType);
            updateClientResponse.RefreshToken.ExpirationType.Should().Be(updateClientRequest.RefreshToken.ExpirationType);
            updateClientResponse.RefreshToken.TokenLifetime.Should().Be(updateClientRequest.RefreshToken.TokenLifetime);
            updateClientResponse.RefreshToken.Leeway.Should().Be(updateClientRequest.RefreshToken.Leeway);
            updateClientResponse.OrganizationRequireBehavior.Should().Be(OrganizationRequireBehavior.NoPrompt);

            // Get a single client
            var client = await ApiClient.Clients.GetAsync(newClientResponse.ClientId);
            client.Should().NotBeNull();
            client.Name.Should().Be(updateClientResponse.Name);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await ApiClient.Clients.DeleteAsync(client.ClientId);
            Func<Task> getFunc = async () => await ApiClient.Clients.GetAsync(client.ClientId);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_client");
        }

        [Fact]
        public async Task Test_client_rotate_secret()
        {
            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = $"{TestingConstants.ClientPrefix} {MakeRandomName()}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                IsFirstParty = true,
                ClientMetaData = new
                {
                    Prop1 = "1",
                    Prop2 = "2"
                },
                ApplicationType = ClientApplicationType.Native
            };
            var newClientResponse = await ApiClient.Clients.CreateAsync(newClientRequest);

            // Rotate the secret
            var updateClientResponse = await ApiClient.Clients.RotateClientSecret(newClientResponse.ClientId);

            // Assert
            updateClientResponse.ClientSecret.Should().NotBe(newClientResponse.ClientSecret);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await ApiClient.Clients.DeleteAsync(newClientResponse.ClientId);
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var clients = await ApiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo());

            // Assert
            Assert.Null(clients.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var clients = await ApiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(clients.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var clients = await ApiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(clients.Paging);
        }

        [Fact]
        public async Task Test_without_paging()
        {
            // Act
            var clients = await ApiClient.Clients.GetAllAsync(new GetClientsRequest());

            // Assert
            Assert.Null(clients.Paging);
            Assert.True(clients.Count > 0);
        }

        [Fact]
        public async Task Test_app_type_works_correctly()
        {
            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = $"{TestingConstants.ClientPrefix} {MakeRandomName()}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                IsFirstParty = true,
                ClientMetaData = new
                {
                    Prop1 = "1",
                    Prop2 = "2"
                },
                ApplicationType = ClientApplicationType.Native
            };
            var newClientResponse = await ApiClient.Clients.CreateAsync(newClientRequest);

            // Rotate the secret
            var connections = await ApiClient.Clients.GetAllAsync(new GetClientsRequest
            {
                AppType = new[] {ClientApplicationType.Native}
            }, new PaginationInfo());

            // Assert
            connections.Count.Should().BeGreaterThan(0);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await ApiClient.Clients.DeleteAsync(newClientResponse.ClientId);
        }
    }
}
