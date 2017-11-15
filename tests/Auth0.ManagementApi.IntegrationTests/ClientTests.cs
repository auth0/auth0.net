using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ClientTests : TestBase
    {
        [Fact]
        public async Task Test_client_crud_sequence()
        {
            string token = await GenerateManagementApiToken();

            var apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // Get all clients
            var clientsBefore = await apiClient.Clients.GetAllAsync();

            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = $"Integration testing {Guid.NewGuid().ToString("N")}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                IsFirstParty = true,
                ClientMetaData = new
                {
                    Prop1 = "1",
                    Prop2 = "2"
                }
            };
            var newClientResponse = await apiClient.Clients.CreateAsync(newClientRequest);
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
                Name = $"Integration testing {Guid.NewGuid().ToString("N")}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                ApplicationType = ClientApplicationType.Spa,
                GrantTypes = new string[0]
            };
            var updateClientResponse = await apiClient.Clients.UpdateAsync(newClientResponse.ClientId, updateClientRequest);
            updateClientResponse.Should().NotBeNull();
            updateClientResponse.Name.Should().Be(updateClientRequest.Name);
            updateClientResponse.TokenEndpointAuthMethod.Should().Be(TokenEndpointAuthMethod.ClientSecretPost);
            updateClientResponse.ApplicationType.Should().Be(ClientApplicationType.Spa);
            updateClientResponse.GrantTypes.Should().HaveCount(0);

            // Get a single client
            var client = await apiClient.Clients.GetAsync(newClientResponse.ClientId);
            client.Should().NotBeNull();
            client.Name.Should().Be(updateClientResponse.Name);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await apiClient.Clients.DeleteAsync(client.ClientId);
            Func<Task> getFunc = async () => await apiClient.Clients.GetAsync(client.ClientId);
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_client");
        }
    }
}
