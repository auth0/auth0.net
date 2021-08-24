using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using System.Linq;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class StatsTests : TestBase
    {
        [Fact]
        public async Task Daily_Stats_Returns_Values()
        {
            string token = await GenerateManagementApiToken();

            using (var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 })))
            {
                var dailyStats = await apiClient.Stats.GetDailyStatsAsync(DateTime.Now.AddDays(-100), DateTime.Now);
                dailyStats.Should().NotBeNull();
                dailyStats.Count.Should().BeGreaterOrEqualTo(1);
                dailyStats.Max(d => d.Logins).Should().BeGreaterThan(0);
            }
        }

        [Fact(Skip = "Inactivity causes these to fail")]
        public async Task Active_Users_Returns_Values()
        {
            string token = await GenerateManagementApiToken();

            using (var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL")))
            {
                var activeUsers = await apiClient.Stats.GetActiveUsersAsync();
                activeUsers.Should().BeGreaterThan(0);
            }
        }
    }
}