using System;
using System.Dynamic;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class RolesTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        private Connection _connection;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // We will need a connection to add the roles to...
            _connection = await _apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });
        }

        public async Task DisposeAsync()
        {
            await _apiClient.Connections.DeleteAsync(_connection.Id);
        }

        [Fact]
        public async Task Test_roles_crud_sequence()
        {
            // Add a new role
            var newRoleRequest = new RoleCreateRequest
            {
                Name = $"{Guid.NewGuid():N}role",
                Description = $"{Guid.NewGuid():N}description",
            };
            var newRoleResponse = await _apiClient.Roles.CreateAsync(newRoleRequest);
            newRoleResponse.Should().NotBeNull();
            newRoleResponse.Name.Should().Be(newRoleRequest.Name);
            newRoleResponse.Description.Should().Be(newRoleRequest.Description);

            // Update the role
            var updateRoleRequest = new RoleUpdateRequest
            {
                Name = $"{Guid.NewGuid():N}role",
            };
            var updateRoleResponse = await _apiClient.Roles.UpdateAsync(newRoleResponse.Id, updateRoleRequest);
            updateRoleResponse.Should().NotBeNull();
            updateRoleResponse.Name.Should().Be(updateRoleRequest.Name);

            // Get a single role
            var role = await _apiClient.Roles.GetAsync(newRoleResponse.Id);
            role.Should().NotBeNull();
            role.Name.Should().Be(updateRoleResponse.Name);

            // Delete the user and ensure we get an exception when trying to fetch them again
            await _apiClient.Roles.DeleteAsync(role.Id);
            Func<Task> getFunc = async () => await _apiClient.Roles.GetAsync(role.Id);
            getFunc.Should().Throw<ApiException>().And.ApiError.Error.Should().Be("Not Found");
        }
    }
}
