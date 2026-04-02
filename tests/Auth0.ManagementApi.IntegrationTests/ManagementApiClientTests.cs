using System.Threading.Tasks;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class ManagementApiClientTestsFixture : TestBaseFixture
{
}

public class ManagementApiClientTests : IClassFixture<ManagementApiClientTestsFixture>
{
    private ManagementApiClientTestsFixture fixture;

    public ManagementApiClientTests(ManagementApiClientTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void Test_management_client_creation_with_credentials()
    {
        var domain = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_URL").Replace("https://", "").TrimEnd('/');
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = domain,
            TokenProvider = new ClientCredentialsTokenProvider(domain, TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"))
        });

        client.Should().NotBeNull();
        client.Users.Should().NotBeNull();
        client.Connections.Should().NotBeNull();
        client.Clients.Should().NotBeNull();
    }

    [Fact]
    public void Test_management_client_creation_with_max_retries()
    {
        var domain = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_URL").Replace("https://", "").TrimEnd('/');
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = domain,
            TokenProvider = new ClientCredentialsTokenProvider(domain, TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET")),
            MaxRetries = 5
        });

        client.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_management_client_can_make_requests()
    {
        // Verify the client can make actual API calls
        var usersPager = await fixture.ApiClient.Users.ListAsync(new ListUsersRequestParameters
        {
            PerPage = 1
        });

        usersPager.Should().NotBeNull();
    }

    [Fact]
    public void Test_management_client_dispose()
    {
        var domain = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_URL").Replace("https://", "").TrimEnd('/');
        var client = new ManagementClient(new ManagementClientOptions
        {
            Domain = domain,
            TokenProvider = new ClientCredentialsTokenProvider(domain, TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"))
        });

        // Should not throw
        client.Dispose();
    }

    [Fact]
    public void Test_nested_clients_accessible()
    {
        // Verify nested clients are accessible
        fixture.ApiClient.Keys.Signing.Should().NotBeNull();
        fixture.ApiClient.Keys.Encryption.Should().NotBeNull();
        fixture.ApiClient.Actions.Triggers.Should().NotBeNull();
        fixture.ApiClient.Jobs.UsersImports.Should().NotBeNull();
        fixture.ApiClient.Jobs.UsersExports.Should().NotBeNull();
        fixture.ApiClient.Organizations.Members.Should().NotBeNull();
        fixture.ApiClient.Organizations.Invitations.Should().NotBeNull();
    }
}
