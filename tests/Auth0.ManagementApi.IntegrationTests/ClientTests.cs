using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Auth0.Tests.Shared;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ClientTestsFixture : TestBaseFixture
    {
        public override async Task DisposeAsync()
        {
            await ManagementTestBaseUtils.CleanupAndDisposeAsync(ApiClient, new List<CleanUpType> { CleanUpType.Clients });
        }
    }

    public class ClientTests : IClassFixture<ClientTestsFixture>
    {
        ClientTestsFixture fixture;

        public ClientTests(ClientTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_client_crud_sequence()
        {
            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = $"{TestingConstants.ClientPrefix} {TestBaseUtils.MakeRandomName()}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                IsFirstParty = true,
                ClientMetaData = new
                {
                    Prop1 = "1",
                    Prop2 = "2"
                },
                InitiateLoginUri = "https://create.com/login",
                RefreshToken = new RefreshToken
                {
                    ExpirationType = RefreshTokenExpirationType.NonExpiring,
                    RotationType = RefreshTokenRotationType.NonRotating
                },
                OidcConformant = true,
                GrantTypes = new[] { "refresh_token" },
                OrganizationUsage = OrganizationUsage.Require,
                OrganizationRequireBehavior = OrganizationRequireBehavior.PreLoginPrompt
            };
            var newClientResponse = await fixture.ApiClient.Clients.CreateAsync(newClientRequest);
            newClientResponse.Should().NotBeNull();
            newClientResponse.Name.Should().Be(newClientRequest.Name);
            newClientResponse.TokenEndpointAuthMethod.Should().Be(TokenEndpointAuthMethod.ClientSecretPost);
            newClientResponse.ApplicationType.Should().Be(ClientApplicationType.Native);
            newClientResponse.IsFirstParty.Should().BeTrue();
            newClientResponse.RefreshToken.Should().NotBeNull();
            newClientResponse.RefreshToken.ExpirationType.Should().Be(newClientRequest.RefreshToken.ExpirationType);
            newClientResponse.RefreshToken.RotationType.Should().Be(newClientRequest.RefreshToken.RotationType);
            newClientResponse.OrganizationUsage.Should().Be(OrganizationUsage.Require);
            newClientResponse.OrganizationRequireBehavior.Should().Be(OrganizationRequireBehavior.PreLoginPrompt);

            string prop1 = newClientResponse.ClientMetaData.Prop1;
            prop1.Should().Be("1");
            string prop2 = newClientResponse.ClientMetaData.Prop2;
            prop2.Should().Be("2");
            newClientResponse.GrantTypes.Should().HaveCount(1);
            newClientResponse.InitiateLoginUri.Should().Be("https://create.com/login");

            // Update the client
            var updateClientRequest = new ClientUpdateRequest
            {
                Name = $"{TestingConstants.ClientPrefix} {TestBaseUtils.MakeRandomName()}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                ApplicationType = ClientApplicationType.Spa,
                GrantTypes = new[] { "refresh_token", "authorization_code" },
                InitiateLoginUri = "https://update.com/login",
                RefreshToken = new RefreshToken
                {
                    ExpirationType = RefreshTokenExpirationType.Expiring,
                    RotationType = RefreshTokenRotationType.Rotating,
                    TokenLifetime = 3600,
                    Leeway = 1800
                },
                OrganizationRequireBehavior = OrganizationRequireBehavior.NoPrompt
            };
            var updateClientResponse = await fixture.ApiClient.Clients.UpdateAsync(newClientResponse.ClientId, updateClientRequest);
            updateClientResponse.Should().NotBeNull();
            updateClientResponse.Name.Should().Be(updateClientRequest.Name);
            updateClientResponse.TokenEndpointAuthMethod.Should().Be(TokenEndpointAuthMethod.ClientSecretPost);
            updateClientResponse.ApplicationType.Should().Be(ClientApplicationType.Spa);
            updateClientResponse.GrantTypes.Should().HaveCount(2);
            updateClientResponse.InitiateLoginUri.Should().Be("https://update.com/login");
            updateClientResponse.RefreshToken.Should().NotBeNull();
            updateClientResponse.RefreshToken.RotationType.Should().Be(updateClientRequest.RefreshToken.RotationType);
            updateClientResponse.RefreshToken.ExpirationType.Should().Be(updateClientRequest.RefreshToken.ExpirationType);
            updateClientResponse.RefreshToken.TokenLifetime.Should().Be(updateClientRequest.RefreshToken.TokenLifetime);
            updateClientResponse.RefreshToken.Leeway.Should().Be(updateClientRequest.RefreshToken.Leeway);
            updateClientResponse.OrganizationRequireBehavior.Should().Be(OrganizationRequireBehavior.NoPrompt);

            // Get a single client
            var client = await fixture.ApiClient.Clients.GetAsync(newClientResponse.ClientId);
            client.Should().NotBeNull();
            client.Name.Should().Be(updateClientResponse.Name);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await fixture.ApiClient.Clients.DeleteAsync(client.ClientId);
            Func<Task> getFunc = async () => await fixture.ApiClient.Clients.GetAsync(client.ClientId);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_client");
        }

        [Fact]
        public async Task Test_client_rotate_secret()
        {
            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = $"{TestingConstants.ClientPrefix} {TestBaseUtils.MakeRandomName()}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                IsFirstParty = true,
                ClientMetaData = new
                {
                    Prop1 = "1",
                    Prop2 = "2"
                },
                ApplicationType = ClientApplicationType.Native
            };
            var newClientResponse = await fixture.ApiClient.Clients.CreateAsync(newClientRequest);

            // Rotate the secret
            var updateClientResponse = await fixture.ApiClient.Clients.RotateClientSecret(newClientResponse.ClientId);

            // Assert
            updateClientResponse.ClientSecret.Should().NotBe(newClientResponse.ClientSecret);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await fixture.ApiClient.Clients.DeleteAsync(newClientResponse.ClientId);
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var clients = await fixture.ApiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo());

            // Assert
            Assert.Null(clients.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var clients = await fixture.ApiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(clients.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var clients = await fixture.ApiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(clients.Paging);
        }

        [Fact]
        public async Task Test_without_paging()
        {
            // Act
            var clients = await fixture.ApiClient.Clients.GetAllAsync(new GetClientsRequest());

            // Assert
            Assert.Null(clients.Paging);
            Assert.True(clients.Count > 0);
        }

        [Fact]
        public async Task Test_app_type_works_correctly()
        {
            // Add a new client
            var newClientRequest = new ClientCreateRequest
            {
                Name = $"{TestingConstants.ClientPrefix} {TestBaseUtils.MakeRandomName()}",
                TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
                IsFirstParty = true,
                ClientMetaData = new
                {
                    Prop1 = "1",
                    Prop2 = "2"
                },
                ApplicationType = ClientApplicationType.Native
            };
            var newClientResponse = await fixture.ApiClient.Clients.CreateAsync(newClientRequest);

            // Rotate the secret
            var connections = await fixture.ApiClient.Clients.GetAllAsync(new GetClientsRequest
            {
                AppType = new[] {ClientApplicationType.Native}
            }, new PaginationInfo());

            // Assert
            connections.Count.Should().BeGreaterThan(0);

            // Delete the client, and ensure we get exception when trying to fetch client again
            await fixture.ApiClient.Clients.DeleteAsync(newClientResponse.ClientId);
        }


        [Fact]
        public async Task Test_retrieve_credentials()
        {
            var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjFQbng2Ri1PRXE2WGYyX1ZZbWllYiJ9.eyJpc3MiOiJodHRwczovL3Rlc3QtcHJpdmF0ZS1rZXktand0LXNka3MudXMuYXV0aDAuY29tLyIsInN1YiI6IlZVV1BXVW5FeEY2bWkyZGU5OE00emxXMVZpZm5jbW1OQGNsaWVudHMiLCJhdWQiOiJodHRwczovL3Rlc3QtcHJpdmF0ZS1rZXktand0LXNka3MudXMuYXV0aDAuY29tL2FwaS92Mi8iLCJpYXQiOjE2NzM5NjUyNjgsImV4cCI6MTY3NDA1MTY2OCwiYXpwIjoiVlVXUFdVbkV4RjZtaTJkZTk4TTR6bFcxVmlmbmNtbU4iLCJzY29wZSI6InJlYWQ6Y2xpZW50X2dyYW50cyBjcmVhdGU6Y2xpZW50X2dyYW50cyBkZWxldGU6Y2xpZW50X2dyYW50cyB1cGRhdGU6Y2xpZW50X2dyYW50cyByZWFkOnVzZXJzIHVwZGF0ZTp1c2VycyBkZWxldGU6dXNlcnMgY3JlYXRlOnVzZXJzIHJlYWQ6dXNlcnNfYXBwX21ldGFkYXRhIHVwZGF0ZTp1c2Vyc19hcHBfbWV0YWRhdGEgZGVsZXRlOnVzZXJzX2FwcF9tZXRhZGF0YSBjcmVhdGU6dXNlcnNfYXBwX21ldGFkYXRhIHJlYWQ6dXNlcl9jdXN0b21fYmxvY2tzIGNyZWF0ZTp1c2VyX2N1c3RvbV9ibG9ja3MgZGVsZXRlOnVzZXJfY3VzdG9tX2Jsb2NrcyBjcmVhdGU6dXNlcl90aWNrZXRzIHJlYWQ6Y2xpZW50cyB1cGRhdGU6Y2xpZW50cyBkZWxldGU6Y2xpZW50cyBjcmVhdGU6Y2xpZW50cyByZWFkOmNsaWVudF9rZXlzIHVwZGF0ZTpjbGllbnRfa2V5cyBkZWxldGU6Y2xpZW50X2tleXMgY3JlYXRlOmNsaWVudF9rZXlzIHJlYWQ6Y29ubmVjdGlvbnMgdXBkYXRlOmNvbm5lY3Rpb25zIGRlbGV0ZTpjb25uZWN0aW9ucyBjcmVhdGU6Y29ubmVjdGlvbnMgcmVhZDpyZXNvdXJjZV9zZXJ2ZXJzIHVwZGF0ZTpyZXNvdXJjZV9zZXJ2ZXJzIGRlbGV0ZTpyZXNvdXJjZV9zZXJ2ZXJzIGNyZWF0ZTpyZXNvdXJjZV9zZXJ2ZXJzIHJlYWQ6ZGV2aWNlX2NyZWRlbnRpYWxzIHVwZGF0ZTpkZXZpY2VfY3JlZGVudGlhbHMgZGVsZXRlOmRldmljZV9jcmVkZW50aWFscyBjcmVhdGU6ZGV2aWNlX2NyZWRlbnRpYWxzIHJlYWQ6cnVsZXMgdXBkYXRlOnJ1bGVzIGRlbGV0ZTpydWxlcyBjcmVhdGU6cnVsZXMgcmVhZDpydWxlc19jb25maWdzIHVwZGF0ZTpydWxlc19jb25maWdzIGRlbGV0ZTpydWxlc19jb25maWdzIHJlYWQ6aG9va3MgdXBkYXRlOmhvb2tzIGRlbGV0ZTpob29rcyBjcmVhdGU6aG9va3MgcmVhZDphY3Rpb25zIHVwZGF0ZTphY3Rpb25zIGRlbGV0ZTphY3Rpb25zIGNyZWF0ZTphY3Rpb25zIHJlYWQ6ZW1haWxfcHJvdmlkZXIgdXBkYXRlOmVtYWlsX3Byb3ZpZGVyIGRlbGV0ZTplbWFpbF9wcm92aWRlciBjcmVhdGU6ZW1haWxfcHJvdmlkZXIgYmxhY2tsaXN0OnRva2VucyByZWFkOnN0YXRzIHJlYWQ6aW5zaWdodHMgcmVhZDp0ZW5hbnRfc2V0dGluZ3MgdXBkYXRlOnRlbmFudF9zZXR0aW5ncyByZWFkOmxvZ3MgcmVhZDpsb2dzX3VzZXJzIHJlYWQ6c2hpZWxkcyBjcmVhdGU6c2hpZWxkcyB1cGRhdGU6c2hpZWxkcyBkZWxldGU6c2hpZWxkcyByZWFkOmFub21hbHlfYmxvY2tzIGRlbGV0ZTphbm9tYWx5X2Jsb2NrcyB1cGRhdGU6dHJpZ2dlcnMgcmVhZDp0cmlnZ2VycyByZWFkOmdyYW50cyBkZWxldGU6Z3JhbnRzIHJlYWQ6Z3VhcmRpYW5fZmFjdG9ycyB1cGRhdGU6Z3VhcmRpYW5fZmFjdG9ycyByZWFkOmd1YXJkaWFuX2Vucm9sbG1lbnRzIGRlbGV0ZTpndWFyZGlhbl9lbnJvbGxtZW50cyBjcmVhdGU6Z3VhcmRpYW5fZW5yb2xsbWVudF90aWNrZXRzIHJlYWQ6dXNlcl9pZHBfdG9rZW5zIGNyZWF0ZTpwYXNzd29yZHNfY2hlY2tpbmdfam9iIGRlbGV0ZTpwYXNzd29yZHNfY2hlY2tpbmdfam9iIHJlYWQ6Y3VzdG9tX2RvbWFpbnMgZGVsZXRlOmN1c3RvbV9kb21haW5zIGNyZWF0ZTpjdXN0b21fZG9tYWlucyB1cGRhdGU6Y3VzdG9tX2RvbWFpbnMgcmVhZDplbWFpbF90ZW1wbGF0ZXMgY3JlYXRlOmVtYWlsX3RlbXBsYXRlcyB1cGRhdGU6ZW1haWxfdGVtcGxhdGVzIHJlYWQ6bWZhX3BvbGljaWVzIHVwZGF0ZTptZmFfcG9saWNpZXMgcmVhZDpyb2xlcyBjcmVhdGU6cm9sZXMgZGVsZXRlOnJvbGVzIHVwZGF0ZTpyb2xlcyByZWFkOnByb21wdHMgdXBkYXRlOnByb21wdHMgcmVhZDpicmFuZGluZyB1cGRhdGU6YnJhbmRpbmcgZGVsZXRlOmJyYW5kaW5nIHJlYWQ6bG9nX3N0cmVhbXMgY3JlYXRlOmxvZ19zdHJlYW1zIGRlbGV0ZTpsb2dfc3RyZWFtcyB1cGRhdGU6bG9nX3N0cmVhbXMgY3JlYXRlOnNpZ25pbmdfa2V5cyByZWFkOnNpZ25pbmdfa2V5cyB1cGRhdGU6c2lnbmluZ19rZXlzIHJlYWQ6bGltaXRzIHVwZGF0ZTpsaW1pdHMgY3JlYXRlOnJvbGVfbWVtYmVycyByZWFkOnJvbGVfbWVtYmVycyBkZWxldGU6cm9sZV9tZW1iZXJzIHJlYWQ6ZW50aXRsZW1lbnRzIHJlYWQ6YXR0YWNrX3Byb3RlY3Rpb24gdXBkYXRlOmF0dGFja19wcm90ZWN0aW9uIHJlYWQ6b3JnYW5pemF0aW9ucyB1cGRhdGU6b3JnYW5pemF0aW9ucyBjcmVhdGU6b3JnYW5pemF0aW9ucyBkZWxldGU6b3JnYW5pemF0aW9ucyBjcmVhdGU6b3JnYW5pemF0aW9uX21lbWJlcnMgcmVhZDpvcmdhbml6YXRpb25fbWVtYmVycyBkZWxldGU6b3JnYW5pemF0aW9uX21lbWJlcnMgY3JlYXRlOm9yZ2FuaXphdGlvbl9jb25uZWN0aW9ucyByZWFkOm9yZ2FuaXphdGlvbl9jb25uZWN0aW9ucyB1cGRhdGU6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIGRlbGV0ZTpvcmdhbml6YXRpb25fY29ubmVjdGlvbnMgY3JlYXRlOm9yZ2FuaXphdGlvbl9tZW1iZXJfcm9sZXMgcmVhZDpvcmdhbml6YXRpb25fbWVtYmVyX3JvbGVzIGRlbGV0ZTpvcmdhbml6YXRpb25fbWVtYmVyX3JvbGVzIGNyZWF0ZTpvcmdhbml6YXRpb25faW52aXRhdGlvbnMgcmVhZDpvcmdhbml6YXRpb25faW52aXRhdGlvbnMgZGVsZXRlOm9yZ2FuaXphdGlvbl9pbnZpdGF0aW9ucyByZWFkOm9yZ2FuaXphdGlvbnNfc3VtbWFyeSBjcmVhdGU6YWN0aW9uc19sb2dfc2Vzc2lvbnMgY3JlYXRlOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMgcmVhZDphdXRoZW50aWNhdGlvbl9tZXRob2RzIHVwZGF0ZTphdXRoZW50aWNhdGlvbl9tZXRob2RzIGRlbGV0ZTphdXRoZW50aWNhdGlvbl9tZXRob2RzIHJlYWQ6Y2xpZW50X2NyZWRlbnRpYWxzIGNyZWF0ZTpjbGllbnRfY3JlZGVudGlhbHMgdXBkYXRlOmNsaWVudF9jcmVkZW50aWFscyBkZWxldGU6Y2xpZW50X2NyZWRlbnRpYWxzIiwiZ3R5IjoiY2xpZW50LWNyZWRlbnRpYWxzIn0.NUzaejQbYfYl4X70_-IKhZlbmowYKcdJ8KB2BPYhVIgk3VU0D6_uy5OaS9GeUJdOeH6OTg37BS7-dxKIb4_mYBgOlg78EWbUM28eJVphwVXl8DC-51vyoZXEL6Rbf2MmxHktVCdN3ZKXSKVqn2Fr51DyvtvAz4vQVbNOv9-zLq2-jGGCOOgMAppZEBvB_aOM-BShfWYY4xjyXvrp5IUdTvpk9WOovzC9l4V2xVlq5DvoBhYbDMg7HPi2ChOpmYrGWYLeSXrhlIKt3pK2z1bubNkFUzHqBeR2dxPVA0MRycevkitsznEG4ik5tZxsbOuy7FrwexSP8j7k-e75St7ekw";
            var domain = "test-private-key-jwt-sdks.us.auth0.com";

            var apiClient = new ManagementApiClient(token, domain, new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));

            // Act
            var client = await apiClient.Clients.GetAsync("vrLAc1VpgCqeSfjKWqw9Hwb7xF0mQtyS");
            var credentials = await apiClient.Clients.GetAllCredentialsAsync("vrLAc1VpgCqeSfjKWqw9Hwb7xF0mQtyS");
            var credential  = await apiClient.Clients.GetCredentialAsync("vrLAc1VpgCqeSfjKWqw9Hwb7xF0mQtyS", credentials[0].Id);

            // Assert
            Assert.NotNull(credentials);
        }
    }
}
