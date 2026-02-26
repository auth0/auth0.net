using System;
using System.Linq;
using System.Threading.Tasks;
using Auth0.Tests.Shared;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
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
    private readonly Mock<IManagementConnection> _mockConnection;
    private readonly CustomDomainsClient _client;
    private readonly CustomDomainsTestsFixture fixture;

    public CustomDomainsTests(CustomDomainsTestsFixture fixture)
    {
        this.fixture = fixture;
        _mockConnection = new Mock<IManagementConnection>();
        _client = new CustomDomainsClient(
            _mockConnection.Object,
            new Uri("https://test.auth0.com/api/v2/"),
            new Dictionary<string, string>());
    }
    [Fact]
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
                TlsPolicy = "recommended",
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
                VerificationMethod = "txt"
            });
            await createFunc.Should().ThrowAsync<ManagementApiException>();
        }
    }
}
