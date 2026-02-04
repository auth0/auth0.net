using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using System.Linq;

namespace Auth0.ManagementApi.IntegrationTests;

public class StatsTests : TestBase
{
    [Fact]
    public async Task Daily_Stats_Returns_Values()
    {
        var managementApiUrl = GetVariable("AUTH0_MANAGEMENT_API_URL");
        var domain = managementApiUrl.Replace("https://", "").TrimEnd('/');

        using (var apiClient = new ManagementClient(new ManagementClientOptions
        {
            Domain = domain,
            ClientId = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"),
            ClientSecret = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"),
            MaxRetries = 9
        }))
        {
            var dailyStats = await apiClient.Stats.GetDailyAsync(new GetDailyStatsRequestParameters
            {
                From = DateTime.Now.AddDays(-100).ToString("yyyyMMdd"),
                To = DateTime.Now.ToString("yyyyMMdd")
            });
            dailyStats.Should().NotBeNull();
            dailyStats.Count().Should().BeGreaterOrEqualTo(1);
            dailyStats.Max(d => d.Logins ?? 0).Should().BeGreaterThan(0);
        }
    }

    [Fact(Skip = "Inactivity causes these to fail")]
    public async Task Active_Users_Returns_Values()
    {
        var managementApiUrl = GetVariable("AUTH0_MANAGEMENT_API_URL");
        var domain = managementApiUrl.Replace("https://", "").TrimEnd('/');

        using (var apiClient = new ManagementClient(new ManagementClientOptions
        {
            Domain = domain,
            ClientId = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"),
            ClientSecret = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET")
        }))
        {
            var activeUsers = await apiClient.Stats.GetActiveUsersCountAsync();
            activeUsers.Should().BeGreaterThan(0);
        }
    }
}
