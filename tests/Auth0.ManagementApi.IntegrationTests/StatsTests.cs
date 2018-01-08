using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class StatsTests : TestBase
    {
        [Fact]
        public async Task Test_stats_sequence()
        {
            string token = await GenerateManagementApiToken();

            var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // Get stats for the past 10 days
            var dailyStats = await apiClient.Stats.GetDailyStatsAsync(DateTime.Now.AddDays(-10), DateTime.Now);
            dailyStats.Should().NotBeNull();

            // Get the active users
            var activeUsers = await apiClient.Stats.GetActiveUsersAsync();
            activeUsers.Should().BeGreaterOrEqualTo(0);
        }
    }
}