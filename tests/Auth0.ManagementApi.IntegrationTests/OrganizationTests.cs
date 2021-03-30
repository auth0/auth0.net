using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class OrganizationTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new TestManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Test_organizations_crud_sequence()
        {
            var initialOrganizations = await _apiClient.Organizations.GetAllAsync(new Paging.PaginationInfo());

            var createRequest = new OrganizationCreateRequest
            {
                Name = $"test-org",
                DisplayName = "Test Org",
                Branding = new OrganizationBranding
                {
                    LogoUrl = "https://cdn.auth0.com/manhattan/versions/1.2800.0/assets/./badge.png"
                }
                
            };
            var createResponse = await _apiClient.Organizations.CreateAsync(createRequest);
            createResponse.Should().NotBeNull();
            createResponse.Name.Should().Be(createRequest.Name);
            createResponse.Branding.LogoUrl.Should().Be(createRequest.Branding.LogoUrl);

            var updateRequest = new OrganizationUpdateRequest
            {
                DisplayName = $"Test Org 123",
            };
            var updateResponse = await _apiClient.Organizations.UpdateAsync(createResponse.Id, updateRequest);
            updateResponse.Should().NotBeNull();
            updateResponse.DisplayName.Should().Be(updateRequest.DisplayName);

            var organization = await _apiClient.Organizations.GetAsync(createResponse.Id);
            organization.Should().NotBeNull();
            organization.DisplayName.Should().Be(updateResponse.DisplayName);

            var organizations = await _apiClient.Organizations.GetAllAsync(new Paging.PaginationInfo());
            organizations.Count.Should().Be(initialOrganizations.Count + 1);

            await _apiClient.Organizations.DeleteAsync(updateResponse.Id);
            Func<Task> getFunc = async () => await _apiClient.Organizations.GetAsync(organization.Id);
            getFunc.Should().Throw<ErrorApiException>().And.Message.Should().Be("No organization found by that id or name");
        }

        [Fact]
        public async Task Test_organization_connections_crud_sequence()
        {
            var createRequest = new OrganizationCreateRequest
            {
                Name = $"test-org",
                DisplayName = "Test Org"

            };
            var createResponse = await _apiClient.Organizations.CreateAsync(createRequest);
            var initialConnections = await _apiClient.Organizations.GetAllConnectionsAsync(createResponse.Id, new Paging.PaginationInfo());

            var createConnectionResponse = await _apiClient.Organizations.CreateConnectionAsync(createResponse.Id, new OrganizationConnectionCreateRequest
            {
                ConnectionId = "con_vKey1CGOPTJClWrB",
                AssignMembershipOnLogin = true
            });

            createConnectionResponse.Should().NotBeNull();
            createConnectionResponse.AssignMembershipOnLogin.Should().Be(true);

            var updateConnectionResponse = await _apiClient.Organizations.UpdateConnectionAsync(createResponse.Id, "con_vKey1CGOPTJClWrB", new OrganizationConnectionUpdateRequest
            {
                AssignMembershipOnLogin = false
            });

            updateConnectionResponse.Should().NotBeNull();
            updateConnectionResponse.AssignMembershipOnLogin.Should().Be(false);

            var connection = await _apiClient.Organizations.GetConnectionAsync(createResponse.Id, "con_vKey1CGOPTJClWrB");

            connection.Should().NotBeNull();
            connection.AssignMembershipOnLogin.Should().Be(false);

            var connections = await _apiClient.Organizations.GetAllConnectionsAsync(createResponse.Id, new Paging.PaginationInfo());
            connections.Count.Should().Be(initialConnections.Count + 1);

            await _apiClient.Organizations.DeleteConnectionAsync(createResponse.Id, "con_vKey1CGOPTJClWrB");

            Func<Task> getFunc = async () => await _apiClient.Organizations.GetConnectionAsync(createResponse.Id, "con_vKey1CGOPTJClWrB");
            getFunc.Should().Throw<ErrorApiException>().And.Message.Should().Be("No connection found by that id");

            await _apiClient.Organizations.DeleteAsync(createResponse.Id);
        }

        [Fact]
        public async Task Test_organization_members_crud_sequence()
        {
            var organization = await _apiClient.Organizations.CreateAsync(new OrganizationCreateRequest
            {
                Name = $"test-org",
                DisplayName = "Test Org"

            });
            var user = await _apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = "Username-Password-Authentication",
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });

            var user2 = await _apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = "Username-Password-Authentication",
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });

            await _apiClient.Organizations.AddMembersAsync(organization.Id, new OrganizationAddMembersRequest
            {
                Members = new List<string> { user.UserId, user2.UserId }
            });


            var members = await _apiClient.Organizations.GetAllMembersAsync(organization.Id, new Paging.PaginationInfo());

            members.Count.Should().Be(2);

            await _apiClient.Organizations.DeleteMemberAsync(organization.Id, new OrganizationDeleteMembersRequest
            {
                Members = new List<string> { user2.UserId }
            });

            var updatedMembers = await _apiClient.Organizations.GetAllMembersAsync(organization.Id, new Paging.PaginationInfo());

            updatedMembers.Count.Should().Be(1);

            await _apiClient.Organizations.DeleteAsync(organization.Id);
            await _apiClient.Users.DeleteAsync(user.UserId);
            await _apiClient.Users.DeleteAsync(user2.UserId);

        }
    }
}
