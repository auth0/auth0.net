using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.Tests.Shared;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class TestBaseFixture : IAsyncLifetime
{
    public ManagementClient ApiClient { get; private set; }

    public Utils Utils { get; private set; }

    protected IDictionary<CleanUpType, IList<string>> identifiers = new Dictionary<CleanUpType, IList<string>>();

    public virtual async Task InitializeAsync()
    {
        var managementApiUrl = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_URL");
        var domain = managementApiUrl.Replace("https://", "").TrimEnd('/');

        ApiClient = new ManagementClient(new ManagementClientOptions
        {
            Domain = domain,
            TokenProvider = new ClientCredentialsTokenProvider(domain, TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET")),
            MaxRetries = 9
        });

        Utils = new Utils(ApiClient);
        await Task.CompletedTask;
    }

    public virtual async Task DisposeAsync()
    {
        await Task.CompletedTask;
    }

    public void TrackIdentifier(CleanUpType type, string identifier)
    {
        if (!identifiers.ContainsKey(type))
        {
            identifiers[type] = new List<string>();
        }

        identifiers[type].Add(identifier);
    }

    public void UnTrackIdentifier(CleanUpType type, string identifier)
    {
        if (!identifiers.ContainsKey(type))
        {
            return;
        }

        identifiers[type].Remove(identifier);
    }
}