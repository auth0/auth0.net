using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.Sessions;

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
    SessionsTestFixture fixture;
    
    public SessionsTest(SessionsTestFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_get_sessions_throws_argument_null_exception_when_null_input()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => fixture.ApiClient.Sessions.GetAsync(null));
    }
    
    [Fact]
    public async Task Test_get_sessions_throws_argument_exception_when_null_input()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => fixture.ApiClient.Sessions.GetAsync(new SessionsGetRequest()));
    }
    
    [Fact]
    public async Task Test_get_sessions_returns_sessions()
    {
        var sampleSessionsResponse = await File.ReadAllTextAsync("./Data/GetSessionsResponse.json");
        var httpManagementClientConnection = new HttpClientManagementConnection();
        var sessions = httpManagementClientConnection.DeserializeContent<Sessions>(sampleSessionsResponse, null);
        sessions.Id.Should().Be("2Lw8dT76wJpOl924");
        sessions.UserId.Should().Be("auth0|8374f7459j7493u84335");
        sessions.CreatedAt.Should().Be(DateTime.Parse("2024-05-10T12:04:22.3452"));
        sessions.Authentication.Methods.Count.Should().Be(1);
        sessions.Authentication.Methods.First().Name.Should().Be("pwd");
        sessions.Authentication.Methods.First().Timestamp.Should().Be(DateTime.Parse("2024-05-21T11:29:12.4251"));
        sessions.Device.InitialIp.Should().Be("142.250.184.206");
        sessions.Device.LastIp.Should().Be("142.250.184.206");
        sessions.Device.InitialUserAgent.Should().Be("Mozilla/5.0...");
        sessions.Device.InitialAsn.Should().Be("8612");
        sessions.Device.LastAsn.Should().Be("8612");
    }
}