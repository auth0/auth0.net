using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class ResourceServerTestsFixture : TestBaseFixture
{
    public override async Task DisposeAsync()
    {
        foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
        {
            await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
        }

        ApiClient.Dispose();
    }
}

public class ResourceServerTests : IClassFixture<ResourceServerTestsFixture>
{
    private ResourceServerTestsFixture fixture;

    public ResourceServerTests(ResourceServerTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_resource_server_crud_sequence()
    {
        // Add a new resource server
        var identifier = Guid.NewGuid();
        var createResourceServerRequest = new CreateResourceServerRequestContent
        {
            Identifier = identifier.ToString("N"),
            Name = $"{TestingConstants.ResourceServerPrefix} {identifier:N}",
            TokenLifetime = 1,
            SigningAlg = SigningAlgorithmEnum.Hs256,
            SigningSecret = "thisismysecret0123456789",
            Scopes = new List<ResourceServerScope>
            {
                new()
                {
                    Value = "scope1",
                    Description = "Scope number 1"
                }
            },
            AllowOfflineAccess = true,
            SkipConsentForVerifiableFirstPartyClients = true,
            ConsentPolicy = "transactional-authorization-with-mfa",
            AuthorizationDetails = new List<object>
            {
                new { type = "Sample" }
            },
            TokenEncryption = new ResourceServerTokenEncryption
            {
                Format = "compact-nested-jwe",
                EncryptionKey = new ResourceServerTokenEncryptionKey
                {
                    Name = "Sample",
                    Alg = ResourceServerTokenEncryptionAlgorithmEnum.RsaOaep256,
                    Kid = "Sample",
                    Pem = RsaTestUtils.ExportPublicKey(new RSACryptoServiceProvider(2048))
                }
            },
            ProofOfPossession = new ResourceServerProofOfPossession
            {
                Mechanism = ResourceServerProofOfPossessionMechanismEnum.Mtls,
                Required = true
            }
        };

        var newResourceServerResponse = await fixture.ApiClient.ResourceServers.CreateAsync(createResourceServerRequest);

        fixture.TrackIdentifier(CleanUpType.ResourceServers, newResourceServerResponse.Id);

        newResourceServerResponse.Should().NotBeNull();
        newResourceServerResponse.Name.Should().Be(createResourceServerRequest.Name);
        newResourceServerResponse.Identifier.Should().Be(createResourceServerRequest.Identifier);

        // Update the resource server
        var updateResourceServerRequest = new UpdateResourceServerRequestContent
        {
            Name = $"{TestingConstants.ResourceServerPrefix} {Guid.NewGuid():N}",
            TokenLifetime = 2,
            SigningAlg = SigningAlgorithmEnum.Hs256,
            SigningSecret = "thisismysecret0123456789",
            Scopes = new List<ResourceServerScope>
            {
                new()
                {
                    Value = "scope1",
                    Description = "Scope number 1"
                },
                new()
                {
                    Value = "scope2",
                    Description = "Scope number 2"
                }
            },
            AllowOfflineAccess = false,
            EnforcePolicies = false,
            TokenDialect = ResourceServerTokenDialectSchemaEnum.AccessToken,
            SkipConsentForVerifiableFirstPartyClients = false,
            ConsentPolicy = "transactional-authorization-with-mfa",
            AuthorizationDetails = new List<object>
            {
                new { type = "Sample" }
            },
            TokenEncryption = new ResourceServerTokenEncryption
            {
                Format = "compact-nested-jwe",
                EncryptionKey = new ResourceServerTokenEncryptionKey
                {
                    Name = "Sample",
                    Alg = ResourceServerTokenEncryptionAlgorithmEnum.RsaOaep256,
                    Kid = "Sample",
                    Pem = RsaTestUtils.ExportPublicKey(new RSACryptoServiceProvider(2048))
                }
            },
            ProofOfPossession = new ResourceServerProofOfPossession
            {
                Mechanism = ResourceServerProofOfPossessionMechanismEnum.Dpop,
                Required = true
            }
        };
        var updateResourceServerResponse = await fixture.ApiClient.ResourceServers.UpdateAsync(newResourceServerResponse.Id, updateResourceServerRequest);

        updateResourceServerResponse.Should().NotBeNull();
        updateResourceServerResponse.Name.Should().Be(updateResourceServerRequest.Name);
        updateResourceServerResponse.TokenLifetime.Should().Be(updateResourceServerRequest.TokenLifetime);
        updateResourceServerResponse.AuthorizationDetails.Should().NotBeNullOrEmpty();
        updateResourceServerResponse.TokenEncryption.Should().NotBeNull();
        updateResourceServerResponse.ProofOfPossession.Should().NotBeNull();

        // Get a single resource server
        var resourceServer = await fixture.ApiClient.ResourceServers.GetAsync(newResourceServerResponse.Id, new GetResourceServerRequestParameters());
        resourceServer.Should().NotBeNull();
        resourceServer.Name.Should().Be(updateResourceServerRequest.Name);

        // Get all resource servers with pagination
        var resourceServersPager = await fixture.ApiClient.ResourceServers.ListAsync(new ListResourceServerRequestParameters
        {
            Page = 0,
            PerPage = 10,
            IncludeTotals = true,
            Identifiers = new[] { resourceServer.Identifier }
        });
        var resourceServers = resourceServersPager.CurrentPage.Items.ToList();
        resourceServers.Count.Should().Be(1);
        resourceServers.First().Identifier.Should().Be(resourceServer.Identifier);

        // Get all resource servers
        resourceServersPager = await fixture.ApiClient.ResourceServers.ListAsync(new ListResourceServerRequestParameters
        {
            Page = 0,
            PerPage = 10,
            IncludeTotals = true
        });
        resourceServers = resourceServersPager.CurrentPage.Items.ToList();
        resourceServers.Count.Should().BeGreaterThan(1);

        // Delete the resource server
        await fixture.ApiClient.ResourceServers.DeleteAsync(resourceServer.Id);

        // Verify deletion by expecting an error
        Func<Task> getFunc = async () => await fixture.ApiClient.ResourceServers.GetAsync(resourceServer.Id, new GetResourceServerRequestParameters());
        await getFunc.Should().ThrowAsync<NotFoundError>();

        fixture.UnTrackIdentifier(CleanUpType.ResourceServers, newResourceServerResponse.Id);
    }

    [Fact(Skip = "Requires valid AUTH0_MANAGEMENT_API_AUDIENCE resource server")]
    public async Task Test_get_resource_server_by_identifier()
    {
        string identifier = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_AUDIENCE");
        var resourceServer = await fixture.ApiClient.ResourceServers.GetAsync(identifier, new GetResourceServerRequestParameters());

        Assert.Equal(resourceServer.Identifier, identifier);
    }

    [Fact]
    public async Task Test_paging_with_totals()
    {
        // Act
        var resourceServersPager = await fixture.ApiClient.ResourceServers.ListAsync(new ListResourceServerRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert - with IncludeTotals = false, we still get items but no total count
        resourceServersPager.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_paging_includes_totals()
    {
        // Act
        var resourceServersPager = await fixture.ApiClient.ResourceServers.ListAsync(new ListResourceServerRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert
        resourceServersPager.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_without_paging()
    {
        // Act
        var resourceServersPager = await fixture.ApiClient.ResourceServers.ListAsync(new ListResourceServerRequestParameters());

        // Assert
        var items = resourceServersPager.CurrentPage.Items.ToList();
        items.Count.Should().BeGreaterThan(0);
    }
}
