using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth0.Core.Models;
using Auth0.ManagementApi.Client;
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
            var apiClient = new ManagementApiClient(ConfigurationManager.AppSettings["ApiToken"], new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]));

            // Test client methods
            //await TestClientMethods(apiClient);

            // Test connection methods
            //await TestConnectionMethods(apiClient);

            // Test device credentials
            //await TestDeviceCredentialsMethods(apiClient);

            // Test rules
            //await TestRuleMethods(apiClient);

            // Test users
            //await TestUserMethods(apiClient);

            // Test user account linking
            //await TestUserAccountLinkMethods(apiClient);

            // Test emails
            //await TestEmailsMethods(apiClient);

            // Test jobs
            //await TestJobsMethods(apiClient);

            // Test stats
            //await TestStatsMethods(apiClient);

            // Test tickets
            //await TestTicketsMethods(apiClient);
        }

        private static async Task TestClientMethods(IManagementApiClient apiClient)
        {
            // Get all clients
            var clients = await apiClient.Clients.GetAll();

            //// Create a new client
            //var newClientRequest = new ClientCreateRequest
            //{
            //    Name = "New test client"
            //};
            //var newClientResponse = await apiClient.Clients.Create(newClientRequest);

            //// Get a single client
            //var client = await apiClient.Clients.Get(newClientResponse.ClientId);

            //// Update the client
            //var updateClientRequest = new ClientUpdateRequest
            //{
            //    Name = "This is an updated name"
            //};
            //var updateClientResponse = await apiClient.Clients.Update(newClientResponse.ClientId, updateClientRequest);

            //// Delete the client
            //await apiClient.Clients.Delete(newClientResponse.ClientId);
        }

        private static async Task TestConnectionMethods(IManagementApiClient apiClient)
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

        private static async Task TestDeviceCredentialsMethods(ManagementApiClient apiClient)
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

        private static async Task TestEmailsMethods(ManagementApiClient apiClient)
        {
            // Get the email provider
            var provider = await apiClient.EmailProvider.Get("name,enabled,credentials,settings");

            // Delete the email provider
            await apiClient.EmailProvider.Delete();

            // Configure the email provider
            var configureRequest = new EmailProviderConfigureRequest
            {
                Name = "mandrill",
                IsEnabled = true,
                Credentials = new EmailProviderCredentials
                {
                    ApiKey = "ABC"
                }
            };
            var configureResponse = await apiClient.EmailProvider.Configure(configureRequest);

            // Update the email provider
            var updateRequest = new EmailProviderUpdateRequest
            {
                Name = "mandrill",
                IsEnabled = true,
                Credentials = new EmailProviderCredentials
                {
                    ApiKey = "XYZ"
                }
            };
            var updateResponse = await apiClient.EmailProvider.Update(updateRequest);
        }

        private static async Task TestJobsMethods(ManagementApiClient apiClient)
        {
            // Send an email verification request
            var emailRequest = new VerifyEmailJobRequest
            {
                UserId = "auth0|56443c91950b505a3399c3b3"
            };
            var emailRequestResponse = await apiClient.Jobs.SendVerificationEmail(emailRequest);

            // Get the job status
            var job = await apiClient.Jobs.Get(emailRequestResponse.Id);

            // Send a user import request
            //using (FileStream fs = new FileStream("user-import-test.json", FileMode.Open))
            //{
            //    var importUsersResponse = await apiClient.Jobs.ImportUsers("con_lQKQee7ZnEGc6OYH", "user-import-test.json", fs);
            //}
        }

        private static async Task TestRuleMethods(ManagementApiClient apiClient)
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

        private static async Task TestStatsMethods(ManagementApiClient apiClient)
        {
            // Get active users
            var users = await apiClient.Stats.GetActiveUsers();

            // Get daily stats
            var dailyStats = await apiClient.Stats.GetDailyStats(new DateTime(2015, 11, 1), new DateTime(2015, 11, 30));
        }

        private static async Task TestTicketsMethods(ManagementApiClient apiClient)
        {
            // Send email verification ticket
            var ticket = await apiClient.Tickets.CreateEmailVerificationTicket(new EmailVerificationTicketRequest
            {
                UserId = "auth0|56443c91950b505a3399c3b3",
                ResultUrl = "http://www.test.com/success"
            });

            // Send password change ticket
            ticket = await apiClient.Tickets.CreatePasswordChangeTicket(new PasswordChangeTicketRequest
            {
                UserId = "auth0|56443c91950b505a3399c3b3",
                ResultUrl = "http://www.test.com/success",
                NewPassword = "password"
            });
        }

        private static async Task TestUserMethods(ManagementApiClient apiClient)
        {
            // Create a new user
            //var newUserRequest = new UserCreateRequest
            //{
            //    Connection = "Username-Password-Authentication",
            //    Email = "test123@test.com",
            //    EmailVerified = true,
            //    Password = "password"
            //};
            //var newUser = await apiClient.Users.Create(newUserRequest);

            // Get a single user
            //var user = await apiClient.Users.Get(newUser.UserId);

            // Get all users
            //var users = await apiClient.Users.GetAll();

            // Update the user
            //var updateUserRequest = new UserUpdateRequest
            //{
            //    Email = "test456@test.com",
            //    VerifyEmail = false
            //};
            //var updatedUser = await apiClient.Users.Update(newUser.UserId, updateUserRequest);

            // Delete the user
            //await apiClient.Users.Delete(newUser.UserId);

            // Delete all users
            //await apiClient.Users.DeleteAll();
        }

        private static async Task TestUserAccountLinkMethods(ManagementApiClient apiClient)
        {
            // Link user
            //var userLinkRequest = new UserAccountLinkRequest
            //{
            //    UserId = "56443cae950b505a3399c3bd",
            //    Provider = "auth0"
            //};
            //var linkResponse = await apiClient.Users.LinkAccount("auth0|56443c91950b505a3399c3b3", userLinkRequest);

            // Link user with JWT
            //var linkResponse = await apiClient.Users.LinkAccount(
            //    "auth0|56443c91950b505a3399c3b3",
            //    "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczovL2plcnJpZS5hdXRoMC5jb20vIiwic3ViIjoiYXV0aDB8NTY0NDNjOTE5NTBiNTA1YTMzOTljM2IzIiwiYXVkIjoiWEFDR3d3eVg4MjBGc285Z3NwelY3YTkwV3hPUGNZRW0iLCJleHAiOjE0NDc2OTU5NjEsImlhdCI6MTQ0NzY0Nzk2MX0.EipV2WM-bhSakqIOwL31UtCBAwCKhMVnAu8uNjnINqg",
            //    "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczovL2plcnJpZS5hdXRoMC5jb20vIiwic3ViIjoiYXV0aDB8NTY0NDNjYWU5NTBiNTA1YTMzOTljM2JkIiwiYXVkIjoiWEFDR3d3eVg4MjBGc285Z3NwelY3YTkwV3hPUGNZRW0iLCJleHAiOjE0NDc2OTU5ODAsImlhdCI6MTQ0NzY0Nzk4MH0.0u1VKZrqymSQTk7HyrJ2ACcwfohkJASMfdGL9Cp9uD0"
            //    );

            //var unlinkResponse = await apiClient.Users.UnlinkAccount("auth0|56443c91950b505a3399c3b3", "auth0", "56443cae950b505a3399c3bd");
        }
    }
}
