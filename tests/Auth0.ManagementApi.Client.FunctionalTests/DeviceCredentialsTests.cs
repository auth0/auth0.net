using System;
using System.Threading.Tasks;
using Auth0.Core.Models;
using NUnit.Framework;

namespace Auth0.ManagementApi.Client.FunctionalTests
{
    [TestFixture]
    public class DeviceCredentialsTests : TestBase
    {
        private Core.Models.Client client;
        private Connection connection;

        [SetUp]
        public async Task Initialize()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), new Uri(GetVariable("AUTH0_API_URL")));

            // Set up the correct Client, Connection and User
            client = await apiClient.Clients.Create(new ClientCreateRequest
            {
                Name = "Integration testing client"
            });
            connection = await apiClient.Connections.Create(new ConnectionCreateRequest
            {
                Name = "integration-new-connection",
                Strategy = "github"
            });
        }

        [TearDown]
        public async Task Cleanup()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), new Uri(GetVariable("AUTH0_API_URL")));

            await apiClient.Clients.Delete(client.ClientId);
            await apiClient.Connections.Delete(connection.Id);
        }

        [Test]
        public void Test_device_credentials_crud_sequence()
        {
            //var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_DEVICE_CREDENTIALS"), new Uri(GetVariable("AUTH0_API_URL")));


            ////Get all the device credentials
            //var credentials = await apiClient.DeviceCredentials.GetAll();

            ////Create a new device credential
            //var newCredentialRequest = new DeviceCredentialCreateRequest
            //{
            //    DeviceName = "Jerrie's Phone",
            //    DeviceId = "ABCDEF",
            //    ClientId = "XACGwwyX820Fso9gspzV7a90WxOPcYEm",
            //    UserId = "YXV0aDB8NTYzYWZlZmViZWFlOTVmMDAxMmI1NzY5",
            //    Type = "public_key",
            //    Value = "new-key-value"
            //};
            //var credential = await apiClient.DeviceCredentials.Create(newCredentialRequest);
        }
    }
}