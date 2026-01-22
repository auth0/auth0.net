using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
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
        var createResourceServerRequest = new ResourceServerCreateRequest()
        {
            Identifier = identifier.ToString("N"),
            Name = $"{TestingConstants.ResourceServerPrefix} {identifier:N}",
            TokenLifetime = 1,
            TokenLifetimeForWeb = 1,
            SigningAlgorithm = SigningAlgorithm.HS256,
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
            VerificationLocation = "https://abc.auth0.com/def",
            SkipConsentForVerifiableFirstPartyClients = true,
            ConsentPolicy = ConsentPolicy.TransactionalAuthorizationWithMfa,
            AuthorizationDetails = new List<ResourceServerAuthorizationDetail>()
            {
                new()
                {
                    Type = "Sample"
                }
            },
            TokenEncryption = new TokenEncryption()
            {
                Format = TokenFormat.CompactNestedJwe,
                EncryptionKey = new TokenEncryptionKey()
                {
                    Name = "Sample",
                    Algorithm = "RSA-OAEP-256",
                    Kid = "Sample",
                    Pem = RsaTestUtils.ExportPublicKey(new RSACryptoServiceProvider(2048))
                }
            },
            ProofOfPossession = new ProofOfPossession()
            {
                Mechanism = Mechanism.Mtls,
                Required = true
            },
            SubjectTypeAuthorization =  new SubjectTypeAuthorization
            {
                User = new SubjectTypeAuthorizationUser
                {
                    Policy = SubjectTypeAuthorizationUserPolicy.RequireClientGrant
                },
                Client = new SubjectTypeAuthorizationClient()
                {
                    Policy = SubjectTypeAuthorizationClientPolicy.DenyAll
                }
            }
        };

        var newResourceServerResponse = await fixture.ApiClient.ResourceServers.CreateAsync(createResourceServerRequest);

        fixture.TrackIdentifier(CleanUpType.ResourceServers, newResourceServerResponse.Id);

        // CreateResourceServerResponse will always have Pem as NULL
        createResourceServerRequest.TokenEncryption.EncryptionKey.Pem = null;
        newResourceServerResponse.Should().BeEquivalentTo(createResourceServerRequest, options => options.Excluding(rs => rs.Id));

        // Update the resource server
        var updateResourceServerRequest = new ResourceServerUpdateRequest()
        {
            Name = $"{TestingConstants.ResourceServerPrefix} {Guid.NewGuid():N}",
            TokenLifetime = 2,
            TokenLifetimeForWeb = 1,
            SigningAlgorithm = SigningAlgorithm.HS256,
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
            TokenDialect = TokenDialect.AccessToken,
            VerificationLocation = "",
            SkipConsentForVerifiableFirstPartyClients = false,
            ConsentPolicy = ConsentPolicy.TransactionalAuthorizationWithMfa,
            AuthorizationDetails = new List<ResourceServerAuthorizationDetail>()
            {
                new()
                {
                    Type = "Sample"
                }
            },
            TokenEncryption = new TokenEncryption()
            {
                Format = TokenFormat.CompactNestedJwe,
                EncryptionKey = new TokenEncryptionKey()
                {
                    Name = "Sample",
                    Algorithm = "RSA-OAEP-256",
                    Kid = "Sample",
                    Pem = RsaTestUtils.ExportPublicKey(new RSACryptoServiceProvider(2048))
                }
            },
            ProofOfPossession = new ProofOfPossession()
            {
                Mechanism = Mechanism.DPoP,
                Required = true
            },
            SubjectTypeAuthorization = new SubjectTypeAuthorization()
            {
                User = new SubjectTypeAuthorizationUser
                {
                    Policy = SubjectTypeAuthorizationUserPolicy.DenyAll
                },
                Client = new SubjectTypeAuthorizationClient()
                {
                    Policy = SubjectTypeAuthorizationClientPolicy.DenyAll
                }
            }
        };
        var updateResourceServerResponse = await fixture.ApiClient.ResourceServers.UpdateAsync(newResourceServerResponse.Id, updateResourceServerRequest);
            
        // Update Resource Server response will always have Pem as NULL
        updateResourceServerRequest.TokenEncryption.EncryptionKey.Pem = null;
        updateResourceServerResponse.Should().BeEquivalentTo(updateResourceServerRequest, options => options.ExcludingMissingMembers());
        updateResourceServerResponse.AuthorizationDetails.Should().NotBeNullOrEmpty();
        updateResourceServerResponse.TokenEncryption.Should().NotBeNull();
        updateResourceServerResponse.ProofOfPossession.Should().NotBeNull();
        updateResourceServerResponse.ProofOfPossession.Mechanism.Should().Be(Mechanism.DPoP);

        // Get a single resource server
        var resourceServer = await fixture.ApiClient.ResourceServers.GetAsync(newResourceServerResponse.Id);
        resourceServer.Should().BeEquivalentTo(updateResourceServerRequest, options => options.ExcludingMissingMembers());
            
        // Get all resource servers with pagination
        var pagination = new PaginationInfo(0, 10, true);
        var request = new ResourceServerGetRequest()
        {
            Identifiers = new List<string>() { resourceServer.Identifier, resourceServer.Identifier }
        };
        var resourceServers = await fixture.ApiClient.ResourceServers.GetAllAsync(request, pagination);
        resourceServers.Count.Should().Be(1);
        resourceServers.First().Identifier.Should().BeEquivalentTo(resourceServer.Identifier);
            
        // Get all resource servers with pagination
        pagination = new PaginationInfo(0, 10, true);
        resourceServers = await fixture.ApiClient.ResourceServers.GetAllAsync(null, pagination);
        resourceServers.Count.Should().BeGreaterThan(1);
            
        // Delete the client, and ensure we get exception when trying to fetch client again
        await fixture.ApiClient.ResourceServers.DeleteAsync(resourceServer.Id);
        Func<Task> getFunc = async () => await fixture.ApiClient.ResourceServers.GetAsync(resourceServer.Id);
        getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_resource_server");

        fixture.UnTrackIdentifier(CleanUpType.ResourceServers, newResourceServerResponse.Id);
    }

    [Fact]
    public async Task Test_get_resource_server_by_identifier()
    {
        string identifier = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_AUDIENCE");
        var resourceServers = await fixture.ApiClient.ResourceServers.GetAsync(identifier);

        Assert.Equal(resourceServers.Identifier, identifier);
    }

    [Fact]
    public async Task Test_paging_does_not_include_totals()
    {
        // Act
        var resourceServers = await fixture.ApiClient.ResourceServers.GetAllAsync(new PaginationInfo(0, 50, false));

        // Assert
        Assert.Null(resourceServers.Paging);
    }

    [Fact]
    public async Task Test_paging_includes_totals()
    {
        // Act
        var resourceServers = await fixture.ApiClient.ResourceServers.GetAllAsync(new PaginationInfo(0, 50, true));

        // Assert
        Assert.NotNull(resourceServers.Paging);
    }

    [Fact]
    public async Task Test_without_paging()
    {
        // Act
        var resourceServers = await fixture.ApiClient.ResourceServers.GetAllAsync();

        // Assert
        resourceServers.Paging.Should().BeNull();
        resourceServers.Count.Should().BeGreaterThan(0);
    }
}