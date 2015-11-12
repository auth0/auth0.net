using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth0.Api.Management;
using Auth0.Core.Models;
using Nito.AsyncEx;

namespace ConsoleTestWorkbench
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        private static async void MainAsync(string[] args)
        {
            var apiClient = new ManagementClient(ConfigurationManager.AppSettings["ApiToken"], new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]));

            // Test client methods
            //await TestClientMethods(apiClient);

            // Test connection methods
            //await TestConnectionMethods(apiClient);

            // Test device credentials
            //await TestDeviceCredentialsMethods(apiClient);

            // Test rules
            //await TestRuleMethods(apiClient);

            // Test users
            await TestUserMethods(apiClient);
        }

        private static async Task TestClientMethods(IManagementClient apiClient)
        {
            // Get all clients
            var clients = await apiClient.Clients.GetAll();

            // Create a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = "New test client"
            };
            var newClientResponse = await apiClient.Clients.Create(newClientRequest);

            // Get a single client
            var client = await apiClient.Clients.Get(newClientResponse.ClientId);

            // Update the client
            var updateClientRequest = new ClientUpdateRequest
            {
                Name = "This is an updated name"
            };
            var updateClientResponse = await apiClient.Clients.Update(newClientResponse.ClientId, updateClientRequest);

            // Delete the client
            await apiClient.Clients.Delete(newClientResponse.ClientId);
        }

        private static async Task TestConnectionMethods(IManagementClient apiClient)
        {
            // Create a new connection
            var newConnectionRequest = new ConnectionCreateRequest
            {
                Name = "jerrie-new-connection",
                Strategy = "github"
            };
            var newConnection = await apiClient.Connections.Create(newConnectionRequest);

            // Get a single connection
            var connection = await apiClient.Connections.Get(newConnection.Id);

            // Get all GitHub connections
            var connections = await apiClient.Connections.GetAll("github");

            // Update a connection
            var updateConnectionRequest = new ConnectionUpdateRequest
            {
                Name = "jerrie-updated-connection"
            };
            connection = await apiClient.Connections.Update(newConnection.Id, updateConnectionRequest);

            // Delete the connection
            await apiClient.Connections.Delete(newConnection.Id);
        }

        private static async Task TestDeviceCredentialsMethods(ManagementClient apiClient)
        {
            // Get all the device credentials
            //var credentials = await apiClient.DeviceCredentials.GetAll();

            // Create a new device credential
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

            // Delete a device credential
            // ...
        }

        private static async Task TestRuleMethods(ManagementClient apiClient)
        {
            // Create a new rule
            var newRuleRequest = new RuleCreateRequest
            {
                Name = "New rule",
                Script = @"function (user, context, callback) {
                              // TODO: implement your rule
                              callback(null, user, context);
                            }"
            };
            var newRule = await apiClient.Rules.Create(newRuleRequest);

            // Get a single rule
            var rule = await apiClient.Rules.Get(newRule.Id);

            // Get all rules
            var rules = await apiClient.Rules.GetAll();

            // Update a rule
            var updateRuleRequest = new RuleUpdateRequest
            {
                Name = "Updated rule"
            };
            var updatedRule = await apiClient.Rules.Update(newRule.Id, updateRuleRequest);

            // Delete a rule
            await apiClient.Rules.Delete(newRule.Id);
        }

        private static async Task TestUserMethods(ManagementClient apiClient)
        {
            // Create a new user
            var newUserRequest = new UserCreateRequest
            {
                Connection = "Username-Password-Authentication",
                Email = "test123@test.com",
                EmailVerified = true,
                Password = "password"
            };
            var newUser = await apiClient.Users.Create(newUserRequest);

            // Get a single user
            var user = await apiClient.Users.Get(newUser.UserId);

            // Get all users
            var users = await apiClient.Users.GetAll();

            // Update the user
            var updateUserRequest = new UserUpdateRequest
            {
                Email = "test456@test.com",
                VerifyEmail = false
            };
            var updatedUser = await apiClient.Users.Update(newUser.UserId, updateUserRequest);

            // Delete the user
            //await apiClient.Users.Delete(newUser.UserId);

            // Delete all users
            await apiClient.Users.DeleteAll();
        }

    }
}
