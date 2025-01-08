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
using System.Linq;

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

        /// <summary>
        /// Hooks are deprecated as on 18th November 2024.
        /// All the existing hooks can still be accessed in a read-only mode.
        /// The users can delete an existing hook OR update an existing hook to
        /// only enable/disable it (None of the other properties can be updated).
        /// Modifying the below test case to work with the existing hooks. 
        /// </summary>
        [Fact(Skip = "Hooks are deprecated")]
        public async Task Test_hooks_crud_sequence()
        {
            // Get all hooks
            var existingHook = (await fixture.ApiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo())).FirstOrDefault();

            existingHook.Should().NotBeNull();

            // Update the Hook - Disable the hook
            var updateHookRequest = new HookUpdateRequest
            {
                Enabled = false
            };

            var updateHookResponse = await fixture.ApiClient.Hooks.UpdateAsync(existingHook.Id, updateHookRequest);
            updateHookResponse.Should().NotBeNull();
            updateHookResponse.Enabled.Should().BeFalse();
            updateHookResponse.Id.Should().Be(existingHook.Id);

            // Get a single hook
            var hook = await fixture.ApiClient.Hooks.GetAsync(existingHook.Id);
            hook.Should().NotBeNull();
            hook.Enabled.Should().BeFalse();
        }

        [Fact(Skip = "Hooks are deprecated")]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var hooks = await fixture.ApiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo());

            // Assert
            Assert.Null(hooks.Paging);
        }

        [Fact(Skip = "Hooks are deprecated")]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var hooks = await fixture.ApiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(hooks.Paging);
        }

        [Fact(Skip = "Hooks are deprecated")]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var hooks = await fixture.ApiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(hooks.Paging);
        }

        /// <summary>
        /// Hooks are deprecated as on 18th November 2024.
        /// All the existing hooks can still be accessed in a read-only mode.
        /// The users can delete an existing hook OR update an existing hook to
        /// only enable/disable it (None of the other properties can be updated).
        /// Modifying the below test case to work with the existing hooks. 
        /// </summary>
        [Fact(Skip = "Hooks are deprecated")]
        public async Task Test_without_paging()
        {
            // Act
            var hooks = await fixture.ApiClient.Hooks.GetAllAsync(new GetHooksRequest());

            hooks.Paging.Should().BeNull();
            hooks.Count.Should().BeGreaterThan(0);
        }
    }
}