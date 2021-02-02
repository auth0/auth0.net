using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class HooksTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();
            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
        }

        public Task DisposeAsync()
        {
            _apiClient.Dispose();
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Test_hooks_crud_sequence()
        {
            // Get all hooks
            var hooksBefore = await _apiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo());

            // Add a new hook
            var newHookRequest = new HookCreateRequest()
            {
                Name = $"integration-test-hook-{Guid.NewGuid():N}",
                Script = @"function(client, scope, audience, context, callback) { {
                              // TODO: implement your hook
                              callback(null, context);
                            }",
                TriggerId = "credentials-exchange"
            };
            var newHookResponse = await _apiClient.Hooks.CreateAsync(newHookRequest);
            newHookResponse.Should().NotBeNull();
            newHookResponse.Name.Should().Be(newHookRequest.Name);

            // Get all the hooks again, and check that we now have one more
            var hooksAfter = await _apiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo());
            hooksAfter.Count.Should().Be(hooksBefore.Count + 1);

            // Update the Hook
            var updateHookRequest = new HookUpdateRequest()
            {
                Name = $"integration-test-hook-{Guid.NewGuid():N}"
            };
            var updateHookResponse = await _apiClient.Hooks.UpdateAsync(newHookResponse.Id, updateHookRequest);
            updateHookResponse.Should().NotBeNull();
            updateHookResponse.Name.Should().Be(updateHookRequest.Name);

            // Get a single hook
            var hook = await _apiClient.Hooks.GetAsync(newHookResponse.Id);
            hook.Should().NotBeNull();
            hook.Name.Should().Be(updateHookRequest.Name);

            // Delete the hook, and ensure we get exception when trying to fetch it again
            await _apiClient.Hooks.DeleteAsync(hook.Id);
            Func<Task> getFunc = async () => await _apiClient.Hooks.GetAsync(hook.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_hook");
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var hooks = await _apiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo());

            // Assert
            Assert.Null(hooks.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var hooks = await _apiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(hooks.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var hooks = await _apiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(hooks.Paging);
        }
    }
}