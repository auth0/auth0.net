using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class HooksTestsFixture : TestBaseFixture
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

    public class HooksTests : IClassFixture<HooksTestsFixture>
    {
        HooksTestsFixture fixture;

        public HooksTests(HooksTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_hooks_crud_sequence()
        {
            // Get all hooks
            var hooksBefore = await fixture.ApiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo());

            // Add a new hook
            var newHookRequest = new HookCreateRequest()
            {
                Name = $"{TestingConstants.HooksPrefix}-{Guid.NewGuid():N}",
                Script = @"module.exports = function(client, scope, audience, context, callback) { {
                              // TODO: implement your hook
                              callback(null, context);
                            }",
                Dependencies = JObject.Parse("{ \"auth0\": \"2.32.0\"}"),
                TriggerId = "credentials-exchange"
            };
            var newHookResponse = await fixture.ApiClient.Hooks.CreateAsync(newHookRequest);

            fixture.TrackIdentifier(CleanUpType.Hooks, newHookResponse.Id);

            newHookResponse.Should().NotBeNull();
            Assert.True(JObject.DeepEquals(newHookRequest.Dependencies, newHookResponse.Dependencies));

            // Get all the hooks again, and check that we now have one more
            var hooksAfter = await fixture.ApiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo());
            hooksAfter.Count.Should().Be(hooksBefore.Count + 1);

            // Update the Hook
            var updateHookRequest = new HookUpdateRequest
            {
                Name = $"{TestingConstants.HooksPrefix}-2-{Guid.NewGuid():N}",
                Enabled = true
            };
            var updateHookResponse = await fixture.ApiClient.Hooks.UpdateAsync(newHookResponse.Id, updateHookRequest);
            updateHookResponse.Should().NotBeNull();
            // Because the Hooks endpoint changes the name of a Hook when using a Guid in the name, 
            // we can only verify the name starts with the part without the Guid.
            updateHookResponse.Name.StartsWith($"{TestingConstants.HooksPrefix}-2-".ToLower()).Should().BeTrue();
            updateHookResponse.Enabled.Should().BeTrue();

            // Get a single hook
            var hook = await fixture.ApiClient.Hooks.GetAsync(newHookResponse.Id);
            hook.Should().NotBeNull();
            hook.Name.StartsWith($"{TestingConstants.HooksPrefix}-2").Should().BeTrue();
            hook.Enabled.Should().BeTrue();

            // Delete the hook, and ensure we get exception when trying to fetch it again
            await fixture.ApiClient.Hooks.DeleteAsync(hook.Id);
            Func<Task> getFunc = async () => await fixture.ApiClient.Hooks.GetAsync(hook.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("HookDoesNotExist");

            fixture.UnTrackIdentifier(CleanUpType.Hooks, newHookResponse.Id);
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var hooks = await fixture.ApiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo());

            // Assert
            Assert.Null(hooks.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var hooks = await fixture.ApiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(hooks.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var hooks = await fixture.ApiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(hooks.Paging);
        }

        [Fact]
        public async Task Test_without_paging()
        {
            // Add a new hook
            var newHook = await fixture.ApiClient.Hooks.CreateAsync(new HookCreateRequest()
            {
                Name = $"{TestingConstants.HooksPrefix}-{Guid.NewGuid():N}",
                Script = @"module.exports = function(client, scope, audience, context, callback) { {
                              // TODO: implement your hook
                              callback(null, context);
                            }",
                Dependencies = JObject.Parse("{ \"auth0\": \"2.32.0\"}"),
                TriggerId = "credentials-exchange"
            });

            fixture.TrackIdentifier(CleanUpType.Hooks, newHook.Id);

            newHook.Should().NotBeNull();
            
            // Act
            var hooks = await fixture.ApiClient.Hooks.GetAllAsync(new GetHooksRequest());

            hooks.Paging.Should().BeNull();
            hooks.Count.Should().BeGreaterThan(0);

            await fixture.ApiClient.Hooks.DeleteAsync(newHook.Id);

            fixture.UnTrackIdentifier(CleanUpType.Hooks, newHook.Id);
        }
    }
}