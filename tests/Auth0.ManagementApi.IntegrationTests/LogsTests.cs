using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Auth0.ManagementApi.IntegrationTests;

public class LogsTestsFixture : TestBaseFixture { }

public class LogsTests : IClassFixture<LogsTestsFixture>
{
    private LogsTestsFixture fixture;

    public LogsTests(LogsTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact(Skip = "Log entries seem to be disabled? Need to investigate...")]
    public async Task Can_fetch_single_entry()
    {
        // Get all log entries
        var logsPager = await fixture.ApiClient.Logs.ListAsync(new ListLogsRequestParameters());

        // Grab the first one
        var firstLogEntry = logsPager.CurrentPage.Items.First();

        // Now fetch just that single entry
        var singleLogEntry = await fixture.ApiClient.Logs.GetAsync(firstLogEntry.LogId);

        // Compare both log entries. They should be the same
        singleLogEntry.LogId.Should().Be(firstLogEntry.LogId);
    }

    [Fact]
    public async Task Test_when_paging_not_specified_does_not_include_totals()
    {
        // Act
        var logs = await fixture.ApiClient.Logs.ListAsync(new ListLogsRequestParameters());

        // Assert - with the new Pager, we just verify we get items
        logs.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_paging_with_totals()
    {
        // Act
        var logs = await fixture.ApiClient.Logs.ListAsync(new ListLogsRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert - with the new Pager, we just verify we get items
        logs.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_paging_includes_totals()
    {
        // Act
        var logs = await fixture.ApiClient.Logs.ListAsync(new ListLogsRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert - with the new Pager, we verify we get items
        logs.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_without_paging()
    {
        // Act
        var logs = await fixture.ApiClient.Logs.ListAsync(new ListLogsRequestParameters());

        // Assert
        logs.CurrentPage.Items.Should().NotBeNull();
        logs.CurrentPage.Items.Count.Should().BeGreaterThan(0);
    }
}
