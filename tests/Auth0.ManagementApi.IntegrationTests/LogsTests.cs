using System;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using Xunit;
using FluentAssertions;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class LogsTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient apiClient;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact(Skip = "Log entries seem to be disabled? Need to investigate...")]
        public async Task Can_fetch_single_entry()
        {
            // Get all log entries
            var logEntries = await apiClient.Logs.GetAllAsync();

            // Grab the first one
            var firstLogEntry = logEntries[0];

            // Now fetch just that single entry
            var singleLogEntry = await apiClient.Logs.GetAsync(firstLogEntry.Id);

            // Compare both log entries. They should be the same
            singleLogEntry.ShouldBeEquivalentTo(firstLogEntry);
        }


        [Fact]
        public async Task Test_deserialization_without_totals()
        {
            var logEntries = await apiClient.Logs.GetAllAsync();

            logEntries.Should().NotBeNull();
            logEntries.Paging.Should().BeNull();
        }

        [Fact]
        public async Task Test_deserialization_with_totals()
        {
            var logEntries = await apiClient.Logs.GetAllAsync(includeTotals: true);

            logEntries.Should().NotBeNull();
            logEntries.Paging.Should().NotBeNull();
        }
    }
}