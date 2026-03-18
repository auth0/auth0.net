using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class CustomDomainsTestsFixture : TestBaseFixture
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

public class CustomDomainsTests : IClassFixture<CustomDomainsTestsFixture>
{
    private readonly CustomDomainsTestsFixture fixture;

    public CustomDomainsTests(CustomDomainsTestsFixture fixture)
    {
        this.fixture = fixture;
    }
    [Fact]
    public async Task Test_custom_domains()
    {
        // Test getting all custom domains
        var domains = await fixture.ApiClient.CustomDomains.GetAllAsync();
        domains.Should().HaveCountGreaterThan(0); 
        
        var customDomain = await fixture.ApiClient.CustomDomains.CreateAsync(
            new CustomDomainCreateRequest
            {
                Domain = "test.dx-sdks.club", 
                Type = CustomDomainCertificateProvisioning.Auth0ManagedCertificate,
                VerificationMethod = "txt"
            });
        
        var id = customDomain.CustomDomainId;
        fixture.TrackIdentifier(CleanUpType.CustomDomains, id);
        
        // Test getting a single custom domain
        var domain = await fixture.ApiClient.CustomDomains.GetAsync(id);
        domain.Should().NotBeNull();
        domain.CustomDomainId.Should().Be(id);
        
        // Test updating a custom domain
        var updateRequest = new CustomDomainUpdateRequest()
        {
            TlsPolicy = "recommended",
            CustomClientIpHeader = null
        };

        var updatedCustomDomain = await fixture.ApiClient.CustomDomains.UpdateAsync(id, updateRequest);
        updatedCustomDomain.Should().NotBeNull();
        updatedCustomDomain.CustomClientIpHeader.Should().Be(updateRequest.CustomClientIpHeader);
        updatedCustomDomain.TlsPolicy.Should().Be(updateRequest.TlsPolicy);
        
        var nonExistentId = "cd_XXw4P8C04x1Aa9e5";
        await fixture.ApiClient.CustomDomains.DeleteAsync(nonExistentId);

        // Test verifying a non-existing id. This will give 404
        var verifyFunc = async () => await fixture.ApiClient.CustomDomains.VerifyAsync(nonExistentId);
        
        verifyFunc.Should().Throw<ApiException>()
            .WithMessage($"The custom domain {nonExistentId} does not exist");

        await fixture.ApiClient.CustomDomains.DeleteAsync(id);
        
        var afterRunCustomDomains = await fixture.ApiClient.CustomDomains.GetAllAsync();
        afterRunCustomDomains.Should().NotContain(x => x.CustomDomainId == id);
        fixture.UnTrackIdentifier(CleanUpType.CustomDomains, id);
    }
}