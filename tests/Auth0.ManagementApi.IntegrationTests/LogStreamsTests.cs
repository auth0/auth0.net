using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class LogStreamsTests : ManagementTestBase, IAsyncLifetime
    {
        private readonly List<LogStream> _createdStreams = new List<LogStream>();

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();
            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        public override Task DisposeAsync()
        {
            // Clean up any log stream entities on the tenant after every test executes
            var deleteTasks = _createdStreams.Select(stream => ApiClient.LogStreams.DeleteAsync(stream.Id));

            return Task.WhenAll(deleteTasks.ToArray()).ContinueWith(_ => base.DisposeAsync());
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

            var createdLogStream = await ApiClient.LogStreams.CreateAsync(request);
            _createdStreams.Add(createdLogStream);

            createdLogStream.Should().NotBeNull();
            createdLogStream.Name.Should().Be(name);

            // Get an entity
            var fetchedLogStream = await ApiClient.LogStreams.GetAsync(createdLogStream.Id);
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

            var updatedLogStream = await ApiClient.LogStreams.UpdateAsync(fetchedLogStream.Id, updateRequest);
            updatedLogStream.Name.Should().Be(updateRequest.Name);
            updatedLogStream.Status.Should().Be(LogStreamStatus.Paused);
            updatedLogStream.Id.Should().Be(fetchedLogStream.Id);
            
            // show that sink properties are merged
            ((string)updatedLogStream.Sink.httpContentType).Should().Be("application/json");             
            ((string)updatedLogStream.Sink.httpEndpoint).Should().Be(updateRequest.Sink.httpEndpoint);

            // Delete the entity
            await ApiClient.LogStreams.DeleteAsync(createdLogStream.Id);
            Func<Task> getFunc = async () => await ApiClient.LogStreams.GetAsync(createdLogStream.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.Error.Should().Be("Not Found");
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
                _createdStreams.Add(await ApiClient.LogStreams.CreateAsync(request));
            }

            // Act
            var streams = await ApiClient.LogStreams.GetAllAsync();

            // Assert
            streams.Count.Should().Be(2);
        }
    }
}
