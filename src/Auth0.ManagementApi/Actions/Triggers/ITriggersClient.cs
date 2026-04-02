using Auth0.ManagementApi;
using Auth0.ManagementApi.Actions.Triggers;

namespace Auth0.ManagementApi.Actions;

public partial interface ITriggersClient
{
    public IBindingsClient Bindings { get; }

    /// <summary>
    /// Retrieve the set of triggers currently available within actions. A trigger is an extensibility point to which actions can be bound.
    /// </summary>
    WithRawResponseTask<ListActionTriggersResponseContent> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
