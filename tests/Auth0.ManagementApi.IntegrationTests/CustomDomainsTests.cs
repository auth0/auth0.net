using System;
using System.Linq;
using System.Threading.Tasks;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class CustomDomainsTests : TestBase
{
    // Tests for custom domains are limited. This is available only on the brucke tenant, and also, we cannot test full CRUD sequence because (1) the tenant
    // allow for only one custom domain and (2) others depend on that domain, so we cannot just go and delete it. We are therefore limited in scope to
    // what we can test. For now, this at least allow us to test that the serialization and the GET methods work correctly
    [Fact(Skip = "Run manually")]
    public async Task Test_custom_domains()
    {
        var managementApiUrl = GetVariable("BRUCKE_MANAGEMENT_API_URL");
        var domain = managementApiUrl.Replace("https://", "").TrimEnd('/');

        using (var apiClient = new ManagementClient(new ManagementClientOptions
        {
            Domain = domain,
            TokenProvider = new ClientCredentialsTokenProvider(domain, GetVariable("BRUCKE_MANAGEMENT_API_CLIENT_ID"), GetVariable("BRUCKE_MANAGEMENT_API_CLIENT_SECRET"))
        }))
        {
            // Test getting all custom domains
            var domains = (await apiClient.CustomDomains.ListAsync(new ListCustomDomainsRequestParameters())).ToList();
            domains.Should().HaveCount(1); // There is only one custom domain currently registered on this tenant

            string id = domains[0].CustomDomainId;

            // Test getting a single custom domain
            var customDomain = await apiClient.CustomDomains.GetAsync(id);
            customDomain.Should().NotBeNull();
            customDomain.CustomDomainId.Should().Be(id);

            // Test updating a custom domain
            var updateRequest = new UpdateCustomDomainRequestContent
            {
                TlsPolicy = CustomDomainTlsPolicyEnum.Recommended,
                CustomClientIpHeader = null
            };

            var updatedCustomDomain = await apiClient.CustomDomains.UpdateAsync(id, updateRequest);
            updatedCustomDomain.Should().NotBeNull();
            updatedCustomDomain.CustomClientIpHeader.Should().Be(updateRequest.CustomClientIpHeader);
            updatedCustomDomain.TlsPolicy.Should().Be("recommended");

            string non_existent_id = "cd_XXw4P8C04x1Aa9e5";

            // Test deleting a non-existent domain
            // (this does not throw for a non-existent domain?)
            await apiClient.CustomDomains.DeleteAsync(non_existent_id);

            // Test verifying a non-existing id. This will give 404
            Func<Task> verifyFunc = async () => await apiClient.CustomDomains.VerifyAsync(non_existent_id);
            await verifyFunc.Should().ThrowAsync<NotFoundError>();

            // Test adding a new domain. The BRUCKE tenant only allows one, so this should throw
            Func<Task> createFunc = async () => await apiClient.CustomDomains.CreateAsync(new CreateCustomDomainRequestContent
            {
                Domain = "test.brucke.club",
                Type = CustomDomainProvisioningTypeEnum.Auth0ManagedCerts,
                VerificationMethod = CustomDomainVerificationMethodEnum.Txt
            });
            await createFunc.Should().ThrowAsync<ManagementApiException>();
        }
    }
}