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
            await TestConnectionMethods(apiClient);
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
    }
}
