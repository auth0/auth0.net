using System;
using System.Threading.Tasks;
using Auth0.Core.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.ManagementApi.Client.IntegrationTests
{
    [TestFixture, Ignore("Damn, how difficult is it to get the correct token combinations for this...?")]
    public class DeviceCredentialsTests : TestBase
    {
        private Core.Models.Client client;
        private Connection connection;
        private User user;

        [SetUp]
        public async Task Initialize()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), new Uri(GetVariable("AUTH0_API_URL")));

            // Set up the correct Client, Connection and User
            client = await apiClient.Clients.Create(new ClientCreateRequest
            {
                Name = Guid.NewGuid().ToString("N")
            });
            connection = await apiClient.Connections.Create(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0"
            });
            user = await apiClient.Users.Create(new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid().ToString("N")}@test.com",
                EmailVerified = true,
                Password = "password"
            });
        }

        [TearDown]
        public async Task Cleanup()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), new Uri(GetVariable("AUTH0_API_URL")));

            await apiClient.Clients.Delete(client.ClientId);
            await apiClient.Connections.Delete(connection.Id);
            await apiClient.Users.Delete(user.UserId);
        }

        [Test]
        public async Task Test_device_credentials_crud_sequence()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), new Uri(GetVariable("AUTH0_API_URL")));

            //Get all the device credentials
            var credentialsBefore = await apiClient.DeviceCredentials.GetAll();

            //Create a new device credential
            var newCredentialRequest = new DeviceCredentialCreateRequest
            {
                DeviceName = Guid.NewGuid().ToString("N"),
                DeviceId = Guid.NewGuid().ToString("N"),
                ClientId = client.ClientId,
                UserId = user.UserId,
                Type = "public_key",
                Value = "new-key-value"
            };
            var newCredentialResponse = await apiClient.DeviceCredentials.Create(newCredentialRequest);
            newCredentialResponse.Should().NotBeNull();
            newCredentialResponse.DeviceId.Should().Be(newCredentialRequest.DeviceId);
            newCredentialResponse.DeviceName.Should().Be(newCredentialRequest.DeviceName);

            // Check that we now have one more device credential
            var credentialsAfterCreate = await apiClient.DeviceCredentials.GetAll();
            credentialsAfterCreate.Count.Should().Be(credentialsBefore.Count + 1);

            // Delete the device credential
            await apiClient.DeviceCredentials.Delete(newCredentialResponse.Id);

            // Check that we now have one less device credential
            var credentialsAfterDelete = await apiClient.DeviceCredentials.GetAll();
            credentialsAfterDelete.Count.Should().Be(credentialsAfterCreate.Count - 1);
        }
    }
}