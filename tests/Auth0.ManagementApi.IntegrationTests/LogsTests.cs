using System.Threading.Tasks;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using Xunit;
using FluentAssertions;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class LogsTests : ManagementTestBase, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        [Fact(Skip = "Log entries seem to be disabled? Need to investigate...")]
        public async Task Can_fetch_single_entry()
        {
            // Get all log entries
            var logEntries = await ApiClient.Logs.GetAllAsync(new GetLogsRequest(), new PaginationInfo());

            // Grab the first one
            var firstLogEntry = logEntries[0];

            // Now fetch just that single entry
            var singleLogEntry = await ApiClient.Logs.GetAsync(firstLogEntry.Id);

            // Compare both log entries. They should be the same
            singleLogEntry.Should().BeEquivalentTo(firstLogEntry);
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var logs = await ApiClient.Logs.GetAllAsync(new GetLogsRequest(), new PaginationInfo());
            
            // Assert
            Assert.Null(logs.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var logs = await ApiClient.Logs.GetAllAsync(new GetLogsRequest(), new PaginationInfo(0, 50, false));
            
            // Assert
            Assert.Null(logs.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var logs = await ApiClient.Logs.GetAllAsync(new GetLogsRequest(), new PaginationInfo(0, 50, true));
            
            // Assert
            Assert.NotNull(logs.Paging);
        }

        [Fact]
        public async Task Test_without_paging()
        {
            // Act
            var logs = await ApiClient.Logs.GetAllAsync(new GetLogsRequest());

            // Assert
            logs.Paging.Should().BeNull();
            logs.Count.Should().BeGreaterThan(0);
        }
    }
}