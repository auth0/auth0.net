using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.ManagementApi.Client.IntegrationTests
{
    [TestFixture]
    public class StatsTests : TestBase
    {
        [Test]
        public async Task Test_stats_sequence()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_STATS"), new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // Get stats for the past 10 days
            var dailyStats = await apiClient.Stats.GetDailyStats(DateTime.Now.AddDays(-10), DateTime.Now);
            dailyStats.Should().NotBeNull();

            // Get the active users
            var activeUsers = await apiClient.Stats.GetActiveUsers();
            activeUsers.Should().BeGreaterOrEqualTo(0);
        }
    }
}