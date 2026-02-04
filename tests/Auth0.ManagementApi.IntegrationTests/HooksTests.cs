using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

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
    private HooksTestsFixture fixture;

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
        var hooksPager = await fixture.ApiClient.Hooks.ListAsync(new ListHooksRequestParameters());
        var existingHook = hooksPager.CurrentPage.Items.FirstOrDefault();

        existingHook.Should().NotBeNull();

        // Update the Hook - Disable the hook
        var updateHookRequest = new UpdateHookRequestContent
        {
            Enabled = false
        };

        var updateHookResponse = await fixture.ApiClient.Hooks.UpdateAsync(existingHook.Id, updateHookRequest);
        updateHookResponse.Should().NotBeNull();
        updateHookResponse.Enabled.Should().BeFalse();
        updateHookResponse.Id.Should().Be(existingHook.Id);

        // Get a single hook
        var hook = await fixture.ApiClient.Hooks.GetAsync(existingHook.Id, new GetHookRequestParameters());
        hook.Should().NotBeNull();
        hook.Enabled.Should().BeFalse();
    }

    [Fact(Skip = "Hooks are deprecated")]
    public async Task Test_when_paging_not_specified_does_not_include_totals()
    {
        // Act
        var hooksPager = await fixture.ApiClient.Hooks.ListAsync(new ListHooksRequestParameters());

        // Assert - Pager always exists, check items instead
        hooksPager.Should().NotBeNull();
    }

    [Fact(Skip = "Hooks are deprecated")]
    public async Task Test_paging_with_totals()
    {
        // Act
        var hooksPager = await fixture.ApiClient.Hooks.ListAsync(new ListHooksRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert
        hooksPager.Should().NotBeNull();
    }

    [Fact(Skip = "Hooks are deprecated")]
    public async Task Test_paging_includes_totals()
    {
        // Act
        var hooksPager = await fixture.ApiClient.Hooks.ListAsync(new ListHooksRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert
        hooksPager.Should().NotBeNull();
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
        var hooksPager = await fixture.ApiClient.Hooks.ListAsync(new ListHooksRequestParameters());
        var hooks = hooksPager.CurrentPage.Items.ToList();

        hooks.Should().NotBeNull();
    }
}
