using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ClientGrantTestsFixture : TestBaseFixture
    {
        public Client TestClient;
        public ResourceServer TestResourceServer;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            TestClient = await ApiClient.Clients.CreateAsync(new ClientCreateRequest
            {
                Name = $"{TestingConstants.ClientPrefix} {TestBaseUtils.MakeRandomName()}",
            });

            TrackIdentifier(CleanUpType.Clients, TestClient.ClientId);

            var identifier = Guid.NewGuid();
            TestResourceServer = await ApiClient.ResourceServers.CreateAsync(new ResourceServerCreateRequest
            {
                Identifier = "urn:" + identifier,
                Name = $"{TestingConstants.ResourceServerPrefix} {identifier:N}",
                TokenLifetime = 1,
                SigningAlgorithm = SigningAlgorithm.RS256,
                Scopes = new List<ResourceServerScope>
                {
                    new ResourceServerScope
                    {
                        Value = "scope1",
                        Description = "Scope number 1"
                    },
                    new ResourceServerScope
                    {
                        Value = "scope2",
                        Description = "Scope number 2"
                    },
                    new ResourceServerScope
                    {
                        Value = "scope3",
                        Description = "Scope number 3"
                    }
                }
            });

            TrackIdentifier(CleanUpType.ResourceServers, TestResourceServer.Id);
        }

        public override async Task DisposeAsync()
        {
            foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
            {
                await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
            }

            ApiClient.Dispose();
        }

    }

    public class ClientGrantTests : IClassFixture<ClientGrantTestsFixture>
    {
        ClientGrantTestsFixture fixture;

        public ClientGrantTests(ClientGrantTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_client_credentials_crud_sequence()
        {
            // Get all the current client grants
            var clientGrantsBefore = await fixture.ApiClient.ClientGrants.GetAllAsync(new GetClientGrantsRequest(), new PaginationInfo());

            // Add a new client grant
            var newClientGrantRequest = new ClientGrantCreateRequest
            {
                ClientId = fixture.TestClient.ClientId,
                Audience = fixture.TestResourceServer.Identifier,
                Scope = new List<string>
                {
                    "scope1",
                    "scope2"
                }
            };

            var newClientGrantResponse = await fixture.ApiClient.ClientGrants.CreateAsync(newClientGrantRequest);
            newClientGrantResponse.Should().NotBeNull();
            newClientGrantResponse.Should().BeEquivalentTo(newClientGrantRequest,
                options => options.Excluding(cg => cg.ClientId));


            fixture.TrackIdentifier(CleanUpType.ClientGrants, newClientGrantResponse.Id);

            // Get all the client grants again, and verify we have one more
            var clientGrantsAfter = await fixture.ApiClient.ClientGrants.GetAllAsync(new GetClientGrantsRequest(), new PaginationInfo());
            clientGrantsAfter.Count.Should().Be(clientGrantsBefore.Count + 1);

            // Update the client grant
            var updateClientGrantRequest = new ClientGrantUpdateRequest
            {
                Scope = new List<string>
                {
                    "scope3"
                }
            };
            var updateClientGrantResponse =
                await fixture.ApiClient.ClientGrants.UpdateAsync(newClientGrantResponse.Id, updateClientGrantRequest);
            updateClientGrantResponse.Should().NotBeNull();
            updateClientGrantResponse.Scope.Count.Should().Be(1);
            updateClientGrantResponse.Scope[0].Should().Be("scope3");

            // Delete the client grant
            await fixture.ApiClient.ClientGrants.DeleteAsync(newClientGrantResponse.Id);

            fixture.UnTrackIdentifier(CleanUpType.ClientGrants, newClientGrantResponse.Id);
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var grants = await fixture.ApiClient.ClientGrants.GetAllAsync(new GetClientGrantsRequest(), new PaginationInfo());
            
            // Assert
            Assert.Null(grants.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var grants = await fixture.ApiClient.ClientGrants.GetAllAsync(new GetClientGrantsRequest(), new PaginationInfo(0, 50, false));
            
            // Assert
            Assert.Null(grants.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var grants = await fixture.ApiClient.ClientGrants.GetAllAsync(new GetClientGrantsRequest(), new PaginationInfo(0, 50, true));
            
            // Assert
            Assert.NotNull(grants.Paging);
        }

        [Fact]
        public async Task Test_without_paging()
        {
            // Act
            var grants = await fixture.ApiClient.ClientGrants.GetAllAsync(new GetClientGrantsRequest());

            // Assert
            Assert.True(grants.Count > 0);
            Assert.Null(grants.Paging);
        }

        [Fact]
        public async Task Organization_Client_Grants()
        {
            var apiId = "dotnet-testing";
            var clientId = fixture.TestClient.ClientId;
            var existingOrgId = "org_V6ojENVd1ERs5YY1";
            
            await fixture.ApiClient.Clients.UpdateAsync(clientId, new ClientUpdateRequest
            {
                ApplicationType = ClientApplicationType.NonInteractive,
                OrganizationUsage = OrganizationUsage.Allow,
                GrantTypes = new[] { "client_credentials" }
            });
            
            var newGrant = await fixture.ApiClient.ClientGrants.CreateAsync(new ClientGrantCreateRequest
            {
                ClientId = clientId,
                Audience = apiId,
                Scope = new List<string> { "dotnet:testing" },
                OrganizationUsage = OrganizationUsage.Allow,
                AllowAnyOrganization = true
            });
            
            fixture.TrackIdentifier(CleanUpType.ClientGrants, newGrant.Id);

            var orgsBefore = await fixture.ApiClient.ClientGrants.GetAllOrganizationsAsync(newGrant.Id);

            var orgGrantsBefore = await fixture.ApiClient.Organizations.GetAllClientGrantsAsync(existingOrgId,
                new OrganizationGetClientGrantsRequest()
                {
                    ClientId = clientId,
                    Audience = apiId,
                });

            orgsBefore.Count.Should().Be(0);
            orgGrantsBefore.Count.Should().Be(0);

            await fixture.ApiClient.Organizations.CreateClientGrantAsync(existingOrgId, new OrganizationCreateClientGrantRequest()
            {
                GrantId = newGrant.Id
            });
            
            var orgsAfter = await fixture.ApiClient.ClientGrants.GetAllOrganizationsAsync(newGrant.Id);

            var orgGrantsAfter = await fixture.ApiClient.Organizations.GetAllClientGrantsAsync(existingOrgId,
                new OrganizationGetClientGrantsRequest()
                {
                    ClientId = clientId,
                    Audience = apiId,
                });
            
            
            orgsAfter.Count.Should().Be(1);
            orgGrantsAfter.Count.Should().Be(1);

            await fixture.ApiClient.ClientGrants.DeleteAsync(newGrant.Id);
            fixture.UnTrackIdentifier(CleanUpType.ClientGrants, newGrant.Id);
        }

    }
}