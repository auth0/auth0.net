using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class CustomDomainsTests : TestBase
    {
        // Tests for custom domains are limited. This is available only on the brucke tenant, and also, we cannot test full CRUD sequence because (1) the tenant
        // allow for only one custom domain and (2) others depend on that domain, so we cannot just go and delete it. We are therefore limited in scope to
        // what we can test. For now, this at least allow us to test that the serialization and the GET methods work correctly
        [Fact(Skip = "Run manually")]
        public async Task Test_custom_domains()
        {
            string token = await GenerateBruckeManagementApiToken();

            using (var apiClient = new ManagementApiClient(token, GetVariable("BRUCKE_MANAGEMENT_API_URL")))
            {
                // Test getting all custom domains
                var domains = await apiClient.CustomDomains.GetAllAsync();
                domains.Should().HaveCount(1); // There is only one custom domain currently registered on this tenant

                string id = domains[0].CustomDomainId;

                // Test getting a single custom domain
                var domain = await apiClient.CustomDomains.GetAsync(id);
                domain.Should().NotBeNull();
                domain.CustomDomainId.Should().Be(id);

                string non_existent_id = "cd_XXw4P8C04x1Aa9e5";

                // Test deleting a non-existent domain
                // (this does not throw for a non-existent domain?)
                await apiClient.CustomDomains.DeleteAsync(non_existent_id);

                // Test verifying a non-existing id. This will give 404
                Func<Task<CustomDomainVerificationResponse>> verifyFunc = async () => await apiClient.CustomDomains.VerifyAsync(non_existent_id);
                verifyFunc.Should().Throw<ApiException>()
                    .WithMessage($"The custom domain {non_existent_id} does not exist");

                // Test adding a new domain. The BRUCKE tenant only allows one, so this should throw
                Func<Task<CustomDomain>> createFunc = async () => await apiClient.CustomDomains.CreateAsync(new CustomDomainCreateRequest
                {
                    Domain = "test.brucke.club",
                    Type = CustomDomainCertificateProvisioning.Auth0ManagedCertificate,
                    VerificationMethod = "txt"
                });
                createFunc.Should().Throw<ApiException>()
                    .WithMessage("You reached the maximum number of custom domains for your account (MAX ALLOWED: 1)");
            }
        }
    }
}