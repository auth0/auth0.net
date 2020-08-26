using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class LogStreamsTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;

        public async Task InitializeAsync()
        {
            string token = await GenerateBruckeManagementApiToken();
            _apiClient = new ManagementApiClient(token, GetVariable("BRUCKE_MANAGEMENT_API_URL"));
        }

        public Task DisposeAsync()
        {
            _apiClient.Dispose();
            return Task.CompletedTask;
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

            var createdLogStream = await _apiClient.LogStreams.CreateAsync(request);
            createdLogStream.Should().NotBeNull();
            createdLogStream.Name.Should().Be(name);

            // Get an entity
            var fetchedLogStream = await _apiClient.LogStreams.GetAsync(createdLogStream.Id);
            fetchedLogStream.Should().NotBeNull();
            fetchedLogStream.Name.Should().Be(name);
            fetchedLogStream.Id.Should().Be(createdLogStream.Id);

            // Update the entity
            var updateRequest = new LogStreamUpdateRequest
            {
                Name = "Auth0.net Test Updated Stream",
                Sink = new
                {
                    httpEndpoint = "https://new-stream.com"
                }
            };

            var updatedLogStream = await _apiClient.LogStreams.UpdateAsync(fetchedLogStream.Id, updateRequest);
            updatedLogStream.Name.Should().Be(updateRequest.Name);
            updatedLogStream.Status.Should().Be(LogStreamStatus.Active);
            updatedLogStream.Id.Should().Be(fetchedLogStream.Id);
            
            // show that sink properties are merged
            ((string)updatedLogStream.Sink.httpContentType).Should().Be("application/json");             
            ((string)updatedLogStream.Sink.httpEndpoint).Should().Be(updateRequest.Sink.httpEndpoint);

            // Delete the entity
            await _apiClient.LogStreams.DeleteAsync(createdLogStream.Id);
            Func<Task> getFunc = async () => await _apiClient.LogStreams.GetAsync(createdLogStream.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.Error.Should().Be("Not Found");
        }
    }
}
