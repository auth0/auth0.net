using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
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
        LogStreamsTestsFixture fixture;
        private readonly List<LogStream> _createdStreams = new List<LogStream>();

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
                }
            };

            var createdLogStream = await fixture.ApiClient.LogStreams.CreateAsync(request);
            _createdStreams.Add(createdLogStream);

            fixture.TrackIdentifier(Auth0.IntegrationTests.Shared.CleanUp.CleanUpType.LogStreams, createdLogStream.Id);

            createdLogStream.Should().NotBeNull();
            createdLogStream.Name.Should().Be(name);

            // Get an entity
            var fetchedLogStream = await fixture.ApiClient.LogStreams.GetAsync(createdLogStream.Id);
            fetchedLogStream.Should().NotBeNull();
            fetchedLogStream.Name.Should().Be(name);
            fetchedLogStream.Id.Should().Be(createdLogStream.Id);

            // Update the entity
            var updateRequest = new LogStreamUpdateRequest
            {
                Name = "Auth0.net Test Updated Stream",
                Status = LogStreamUpdateStatus.Paused,
                Sink = new
                {
                    httpEndpoint = "https://new-stream.com"
                }
            };

            var updatedLogStream = await fixture.ApiClient.LogStreams.UpdateAsync(fetchedLogStream.Id, updateRequest);
            updatedLogStream.Name.Should().Be(updateRequest.Name);
            updatedLogStream.Status.Should().Be(LogStreamStatus.Paused);
            updatedLogStream.Id.Should().Be(fetchedLogStream.Id);
            
            // show that sink properties are merged
            ((string)updatedLogStream.Sink.httpContentType).Should().Be("application/json");             
            ((string)updatedLogStream.Sink.httpEndpoint).Should().Be(updateRequest.Sink.httpEndpoint);

            // Delete the entity
            await fixture.ApiClient.LogStreams.DeleteAsync(createdLogStream.Id);
            Func<Task> getFunc = async () => await fixture.ApiClient.LogStreams.GetAsync(createdLogStream.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.Error.Should().Be("Not Found");

            fixture.UnTrackIdentifier(Auth0.IntegrationTests.Shared.CleanUp.CleanUpType.LogStreams, createdLogStream.Id);
        }

        [Fact]
        public async Task Test_log_stream_get_all()
        {
            // Arrange
            var requests = new LogStreamCreateRequest[] {
                new LogStreamCreateRequest
                {
                    Name = "Auth0.net Stream 1",
                    Type = LogStreamType.Http,
                    Sink = new
                    {
                        httpEndpoint = "https://my-stream.com",
                        httpContentType = "application/json",
                        httpContentFormat = "JSONOBJECT",
                        httpAuthorization = "http-auth"
                    }
                },
                new LogStreamCreateRequest
                {
                    Name = "Auth0.net Stream 2",
                    Type = LogStreamType.Http,
                    Sink = new
                    {
                        httpEndpoint = "https://my-stream.com",
                        httpContentType = "application/json",
                        httpContentFormat = "JSONOBJECT",
                        httpAuthorization = "http-auth"
                    }
                }
            };

            foreach(var request in requests)
            {
                var stream = await fixture.ApiClient.LogStreams.CreateAsync(request);

                fixture.TrackIdentifier(Auth0.IntegrationTests.Shared.CleanUp.CleanUpType.LogStreams, stream.Id);

                _createdStreams.Add(stream);
            }

            // Act
            var streams = await fixture.ApiClient.LogStreams.GetAllAsync();

            // Assert
            streams.Count.Should().Be(2);

            // Remove
            foreach (var stream in streams)
            {
                await fixture.ApiClient.LogStreams.DeleteAsync(stream.Id);
                fixture.UnTrackIdentifier(Auth0.IntegrationTests.Shared.CleanUp.CleanUpType.LogStreams, stream.Id);
            }
        }
    }
}
