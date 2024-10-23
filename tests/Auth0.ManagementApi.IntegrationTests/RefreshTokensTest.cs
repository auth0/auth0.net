using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.RefreshTokens;

using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class RefreshTokensTestFixture : TestBaseFixture
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

public class RefreshTokensTest: IClassFixture<RefreshTokensTestFixture>
{
    RefreshTokensTestFixture fixture;
    
    public RefreshTokensTest(RefreshTokensTestFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_get_refresh_token_throws_argument_null_exception_when_null_input()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => fixture.ApiClient.RefreshTokens.GetAsync(null));
    }
    
    [Fact]
    public async Task Test_get_refresh_token_throws_argument_exception_when_null_input()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => fixture.ApiClient.RefreshTokens.GetAsync(new RefreshTokenGetRequest()));
    }
    
    [Fact]
    public async Task Test_get_refresh_token_returns_refresh_token()
    {
        var sampleRefreshTokenResponse = await File.ReadAllTextAsync("./Data/GetRefreshTokenResponse.json");
        var httpManagementClientConnection = new HttpClientManagementConnection();
        var refreshToken = httpManagementClientConnection.DeserializeContent<RefreshTokenInformation>(sampleRefreshTokenResponse, null);

        refreshToken.Should().NotBeNull();
        refreshToken.Id.Should().Be("6fsdgrfsU4dh510");
        refreshToken.UserId.Should().Be("auth0|8374f7459j7493u766335");
        refreshToken.CreatedAt.Should().Be(DateTime.Parse("2024-05-10T12:04:22.3452"));
        refreshToken.IdleExpiresAt.Should().Be(DateTime.Parse("2024-05-21T12:29:12.4251"));
        refreshToken.ExpiresAt.Should().Be(DateTime.Parse("2024-06-21T18:29:12.4251"));
        refreshToken.SessionId.Should().Be("2Lw8dT76wJpOl924");
        refreshToken.Rotating.Should().Be(true);
        refreshToken.ResourceServers.Count.Should().Be(1);
        refreshToken.ResourceServers.First().Audience.Should().Be("http://myapi.com");
        refreshToken.ResourceServers.First().Scopes.Should().Be("read:users");
    }
}