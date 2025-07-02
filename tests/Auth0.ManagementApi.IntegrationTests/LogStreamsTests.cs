using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;

using FluentAssertions;
using Xunit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    private readonly List<LogStream> _createdStreams = new();

    public LogStreamsTests(LogStreamsTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_log_stream_crud_sequence()
    {
        // Create a new entity
        var name = "Auth0.net Test Log Stream";

        var request = new LogStreamCreateRequest
        {
            Name = name,
            Type = LogStreamType.Http,
            Sink = new
            {
                httpEndpoint = "https://my-stream.com",
                httpContentType = "application/json",
                httpContentFormat = "JSONOBJECT",
                httpAuthorization = "http-auth"
            },
            Filters = new List<LogStreamFilter>() {
                new()
                {
                    Type = LogStreamFilterType.Category,
                    Name = LogStreamFilterName.UserNotification
                }
            }
        };

        var createdLogStream = await fixture.ApiClient.LogStreams.CreateAsync(request);
        _createdStreams.Add(createdLogStream);

        fixture.TrackIdentifier(CleanUpType.LogStreams, createdLogStream.Id);

        createdLogStream.Should().NotBeNull();
        createdLogStream.Name.Should().Be(name);

        // Get an entity
        var fetchedLogStream = await fixture.ApiClient.LogStreams.GetAsync(createdLogStream.Id);
        fetchedLogStream.Should().NotBeNull();
        fetchedLogStream.Name.Should().Be(name);
        fetchedLogStream.Id.Should().Be(createdLogStream.Id);
        fetchedLogStream.Filters.Should().HaveCount(1);
        fetchedLogStream.Filters[0].Name.Should().Be(request.Filters[0].Name);
        fetchedLogStream.Filters[0].Type.Should().Be(request.Filters[0].Type);

        // Update the entity
        var updateRequest = new LogStreamUpdateRequest
        {
            Name = "Auth0.net Test Updated Stream",
            Status = LogStreamUpdateStatus.Paused,
            Sink = new
            {
                httpEndpoint = "https://new-stream.com"
            },
            Filters = new List<LogStreamFilter>() {
                new()
                {
                    Type = LogStreamFilterType.Category,
                    Name = LogStreamFilterName.SystemNotification
                }
            }
        };

        var updatedLogStream = await fixture.ApiClient.LogStreams.UpdateAsync(fetchedLogStream.Id, updateRequest);
        updatedLogStream.Name.Should().Be(updateRequest.Name);
        updatedLogStream.Status.Should().Be(LogStreamStatus.Paused);
        updatedLogStream.Id.Should().Be(fetchedLogStream.Id);
        updatedLogStream.Filters.Should().HaveCount(1);
        updatedLogStream.Filters[0].Name.Should().Be(updateRequest.Filters[0].Name);
        updatedLogStream.Filters[0].Type.Should().Be(updateRequest.Filters[0].Type);

        // show that sink properties are merged
        ((string)updatedLogStream.Sink.httpContentType).Should().Be("application/json");
        ((string)updatedLogStream.Sink.httpEndpoint).Should().Be(updateRequest.Sink.httpEndpoint);

        // Delete the entity
        await fixture.ApiClient.LogStreams.DeleteAsync(createdLogStream.Id);
        Func<Task> getFunc = async () => await fixture.ApiClient.LogStreams.GetAsync(createdLogStream.Id);
        getFunc.Should().Throw<ErrorApiException>().And.ApiError.Error.Should().Be("Not Found");

        fixture.UnTrackIdentifier(CleanUpType.LogStreams, createdLogStream.Id);
    }

    [Fact]
    public async Task Test_log_stream_get_all()
    {
        // Arrange
        var requests = new LogStreamCreateRequest[] {
            new()
            {
                Name = "Auth0.net Stream 1",
                Type = LogStreamType.Http,
                Sink = new
                {
                    httpEndpoint = "https://my-stream.com",
                    httpContentType = "application/json",
                    httpContentFormat = "JSONOBJECT",
                    httpAuthorization = "http-auth"
                },
                Filters = new List<LogStreamFilter>() {
                    new()
                    {
                        Type = LogStreamFilterType.Category,
                        Name = LogStreamFilterName.UserNotification
                    }
                }
            },
            new()
            {
                Name = "Auth0.net Stream 2",
                Type = LogStreamType.Http,
                Sink = new
                {
                    httpEndpoint = "https://my-stream.com",
                    httpContentType = "application/json",
                    httpContentFormat = "JSONOBJECT",
                    httpAuthorization = "http-auth"
                },
            }
        };

        foreach (var request in requests)
        {
            var stream = await fixture.ApiClient.LogStreams.CreateAsync(request);

            fixture.TrackIdentifier(CleanUpType.LogStreams, stream.Id);

            _createdStreams.Add(stream);
        }

        // Act
        var streams = await fixture.ApiClient.LogStreams.GetAllAsync();

        // Assert
        streams.Count.Should().Be(2);

        streams.Count(x => x.Filters != null && x.Filters.Any(filter => filter.Name == LogStreamFilterName.UserNotification))
            .Should().Be(1);
            
        streams.Count(x => x.Filters == null).Should().Be(1);
            
        // Remove
        foreach (var stream in streams)
        {
            await fixture.ApiClient.LogStreams.DeleteAsync(stream.Id);
            fixture.UnTrackIdentifier(Auth0.IntegrationTests.Shared.CleanUp.CleanUpType.LogStreams, stream.Id);
        }
    }
}