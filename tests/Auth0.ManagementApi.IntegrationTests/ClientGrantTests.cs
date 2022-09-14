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
        }

        public override async Task DisposeAsync()
        {
            await ManagementTestBaseUtils.CleanupAndDisposeAsync(ApiClient, new List<CleanUpType> { CleanUpType.Clients, CleanUpType.ResourceServers });
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

    }
}