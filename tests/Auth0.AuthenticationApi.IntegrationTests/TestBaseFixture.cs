using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi;
using Auth0.Tests.Shared;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class TestBaseFixture : IAsyncLifetime
{
    public ManagementClient ApiClient { get; private set; }
    protected IDictionary<CleanUpType, IList<string>> identifiers = new Dictionary<CleanUpType, IList<string>>();

    public virtual async Task InitializeAsync()
    {
        ApiClient = new ManagementClient(new ManagementClientOptions
        {
            Domain = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_URL"),
            ClientId = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"),
            ClientSecret = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"),
            Audience = TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_AUDIENCE"),
            MaxRetries = 9
        });
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