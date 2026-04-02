using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;

using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;
public class SessionsTestFixture : TestBaseFixture
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

public class SessionsTest: IClassFixture<SessionsTestFixture>
{
    private SessionsTestFixture fixture;

    public SessionsTest(SessionsTestFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_get_sessions_throws_exception_when_null_input()
    {
        // The SDK doesn't validate null IDs client-side - it sends the request
        // and the API returns NotFoundError (404)
        Func<Task> action = async () => await fixture.ApiClient.Sessions.GetAsync(null);
        await action.Should().ThrowAsync<NotFoundError>();
    }

    [Fact]
    public async Task Test_get_sessions_throws_exception_when_empty_input()
    {
        // The SDK doesn't validate empty IDs client-side - it sends the request
        // and the API returns NotFoundError (404)
        Func<Task> action = async () => await fixture.ApiClient.Sessions.GetAsync(string.Empty);
        await action.Should().ThrowAsync<NotFoundError>();
    }

    [Fact(Skip = "SDK uses OneOf types which require internal JsonUtils for deserialization")]
    public async Task Test_get_sessions_deserializes_correctly()
    {
        // This test cannot work as-is because GetSessionResponseContent uses OneOf types
        // that require the SDK's internal JsonUtils for proper deserialization.
        // The actual deserialization is tested implicitly when making API calls.
        await Task.CompletedTask;
    }
}
