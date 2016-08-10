using System;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using NUnit.Framework;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    [TestFixture]
    public class ClientTests : TestBase
    {
        [Test]
        public async Task Test_client_crud_sequence()
        {
            var scopes = new
            {
                clients = new
                {
                    actions = new string[] { "read", "create", "delete", "update" }
                },
                client_keys = new
                {
                    actions = new string[] { "read", "update" }
                }
            };
            string token = GenerateToken(scopes);

            var apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // Get all clients
            var clientsBefore = await apiClient.Clients.GetAllAsync();

            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = $"Integration testing {Guid.NewGuid().ToString("N")}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
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
            newClientResponse.IsFirstParty = null;
            string prop1 = newClientResponse.ClientMetaData.Prop1;
            prop1.Should().Be("1");
            string prop2 = newClientResponse.ClientMetaData.Prop2;
            prop2.Should().Be("2");

            // Get all clients again, and ensure we have one client more
            var clientsAfter = await apiClient.Clients.GetAllAsync();
            clientsAfter.Count.Should().Be(clientsBefore.Count + 1);

            // Update the client
            var updateClientRequest = new ClientUpdateRequest
            {
                Name = $"Integration testing {Guid.NewGuid().ToString("N")}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                ApplicationType = ClientApplicationType.Spa,
                IsFirstParty = false
            };
            var updateClientResponse = await apiClient.Clients.UpdateAsync(newClientResponse.ClientId, updateClientRequest);
            updateClientResponse.Should().NotBeNull();
            updateClientResponse.Name.Should().Be(updateClientRequest.Name);
            updateClientResponse.TokenEndpointAuthMethod.Should().Be(TokenEndpointAuthMethod.ClientSecretPost);
            updateClientResponse.ApplicationType.Should().Be(ClientApplicationType.Spa);
            updateClientResponse.IsFirstParty = false;

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
