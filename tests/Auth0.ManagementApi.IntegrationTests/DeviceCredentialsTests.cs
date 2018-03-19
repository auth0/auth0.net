using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class DeviceCredentialsTests : TestBase, IAsyncLifetime
    {
        private Client client;
        private Connection connection;
        private User user;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // Set up the correct Client, Connection and User
            client = await apiClient.Clients.CreateAsync(new ClientCreateRequest
            {
                Name = Guid.NewGuid().ToString("N")
            });
            connection = await apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0"
            });
            user = await apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });
        }

        public async Task DisposeAsync()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), GetVariable("AUTH0_MANAGEMENT_API_URL"));

            await apiClient.Clients.DeleteAsync(client.ClientId);
            await apiClient.Connections.DeleteAsync(connection.Id);
            await apiClient.Users.DeleteAsync(user.UserId);
        }

        [Fact(Skip = "Damn, how difficult is it to get the correct token combinations for this...?")]
        public async Task Test_device_credentials_crud_sequence()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), GetVariable("AUTH0_MANAGEMENT_API_URL"));

            //Get all the device credentials
            var credentialsBefore = await apiClient.DeviceCredentials.GetAllAsync();

            //Create a new device credential
            var newCredentialRequest = new DeviceCredentialCreateRequest
            {
                DeviceName = Guid.NewGuid().ToString("N"),
                DeviceId = Guid.NewGuid().ToString("N"),
                ClientId = client.ClientId,
                Type = "public_key",
                Value = "new-key-value"
            };
            var newCredentialResponse = await apiClient.DeviceCredentials.CreateAsync(newCredentialRequest);
            newCredentialResponse.Should().NotBeNull();
            newCredentialResponse.DeviceId.Should().Be(newCredentialRequest.DeviceId);
            newCredentialResponse.DeviceName.Should().Be(newCredentialRequest.DeviceName);

            // Check that we now have one more device credential
            var credentialsAfterCreate = await apiClient.DeviceCredentials.GetAllAsync();
            credentialsAfterCreate.Count.Should().Be(credentialsBefore.Count + 1);

            // Delete the device credential
            await apiClient.DeviceCredentials.DeleteAsync(newCredentialResponse.Id);

            // Check that we now have one less device credential
            var credentialsAfterDelete = await apiClient.DeviceCredentials.GetAllAsync();
            credentialsAfterDelete.Count.Should().Be(credentialsAfterCreate.Count - 1);
        }
    }
}