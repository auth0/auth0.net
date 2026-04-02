using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class LogStreamsTestsFixture : TestBaseFixture
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

public class LogStreamsTests : IClassFixture<LogStreamsTestsFixture>
{
    private LogStreamsTestsFixture fixture;

    public LogStreamsTests(LogStreamsTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_log_streams_crud_sequence()
    {
        // Get all log streams before
        var logStreamsBefore = (await fixture.ApiClient.LogStreams.ListAsync()).ToList();

        // Create a new HTTP log stream
        var newLogStream = await fixture.ApiClient.LogStreams.CreateAsync(new CreateLogStreamHttpRequestBody
        {
            Name = $"{TestingConstants.EntityPrefix}-LogStream-{Guid.NewGuid():N}",
            Sink = new LogStreamHttpSink
            {
                HttpEndpoint = "https://example.com/logs",
                HttpContentType = "application/json",
                HttpContentFormat = LogStreamHttpContentFormatEnum.Jsonlines,
                HttpAuthorization = "Bearer test-token"
            },
            Type = LogStreamHttpEnum.Http
        });

        var createdLogStream = newLogStream.AsLogStreamHttpResponseSchema(); // HTTP log stream
        createdLogStream.Should().NotBeNull();
        createdLogStream.Id.Should().NotBeNullOrEmpty();

        fixture.TrackIdentifier(CleanUpType.LogStreams, createdLogStream.Id);

        try
        {
            // Get all log streams after creation
            var logStreamsAfter = (await fixture.ApiClient.LogStreams.ListAsync()).ToList();
            logStreamsAfter.Count.Should().Be(logStreamsBefore.Count + 1);

            // Get the specific log stream
            var fetchedLogStream = await fixture.ApiClient.LogStreams.GetAsync(createdLogStream.Id);
            fetchedLogStream.Should().NotBeNull();
            var fetchedHttp = fetchedLogStream.AsLogStreamHttpResponseSchema();
            fetchedHttp.Id.Should().Be(createdLogStream.Id);

            // Update the log stream
            var updatedLogStream = await fixture.ApiClient.LogStreams.UpdateAsync(createdLogStream.Id, new UpdateLogStreamRequestContent
            {
                Name = $"{TestingConstants.EntityPrefix}-LogStream-Updated-{Guid.NewGuid():N}"
            });
            updatedLogStream.Should().NotBeNull();
        }
        finally
        {
            // Delete the log stream
            await fixture.ApiClient.LogStreams.DeleteAsync(createdLogStream.Id);
            fixture.UnTrackIdentifier(CleanUpType.LogStreams, createdLogStream.Id);
        }
    }

    [Fact]
    public async Task Test_log_streams_list()
    {
        var logStreams = await fixture.ApiClient.LogStreams.ListAsync();
        logStreams.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_log_stream_pause_and_resume()
    {
        // Create a new HTTP log stream
        var newLogStream = await fixture.ApiClient.LogStreams.CreateAsync(new CreateLogStreamHttpRequestBody
        {
            Type =  LogStreamHttpEnum.Http,
            Name = $"{TestingConstants.EntityPrefix}-LogStream-{Guid.NewGuid():N}",
            Sink = new LogStreamHttpSink
            {
                HttpEndpoint = "https://example.com/logs",
                HttpContentType = "application/json",
                HttpContentFormat = LogStreamHttpContentFormatEnum.Jsonlines
            }
        });

        var createdLogStream = newLogStream.AsLogStreamHttpResponseSchema();
        fixture.TrackIdentifier(CleanUpType.LogStreams, createdLogStream.Id);

        try
        {
            // Pause the log stream
            var pausedLogStream = await fixture.ApiClient.LogStreams.UpdateAsync(createdLogStream.Id, new UpdateLogStreamRequestContent
            {
                Status = LogStreamStatusEnum.Paused
            });
            var pausedHttp = pausedLogStream.AsLogStreamHttpResponseSchema();
            pausedHttp.Status.Should().Be(LogStreamStatusEnum.Paused);

            // Resume the log stream
            var resumedLogStream = await fixture.ApiClient.LogStreams.UpdateAsync(createdLogStream.Id, new UpdateLogStreamRequestContent
            {
                Status = LogStreamStatusEnum.Active
            });
            var resumedHttp = resumedLogStream.AsLogStreamHttpResponseSchema();
            resumedHttp.Status.Should().Be(LogStreamStatusEnum.Active);
        }
        finally
        {
            await fixture.ApiClient.LogStreams.DeleteAsync(createdLogStream.Id);
            fixture.UnTrackIdentifier(CleanUpType.LogStreams, createdLogStream.Id);
        }
    }
}
