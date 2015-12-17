using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    [TestFixture]
    public class StatsTests : TestBase
    {
        [Test]
        public async Task Test_stats_sequence()
        {
            var scopes = new
            {
                stats = new
                {
                    actions = new string[] { "read" }
                }
            };
            string token = GenerateToken(scopes);

            var apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // Get stats for the past 10 days
            var dailyStats = await apiClient.Stats.GetDailyStats(DateTime.Now.AddDays(-10), DateTime.Now);
            dailyStats.Should().NotBeNull();

            // Get the active users
            var activeUsers = await apiClient.Stats.GetActiveUsers();
            activeUsers.Should().BeGreaterOrEqualTo(0);
        }
    }
}