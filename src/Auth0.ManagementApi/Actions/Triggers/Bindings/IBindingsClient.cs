using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Actions.Triggers;

public partial interface IBindingsClient
{
    /// <summary>
    /// Retrieve the actions that are bound to a trigger. Once an action is created and deployed, it must be attached (i.e. bound) to a trigger so that it will be executed as part of a flow. The list of actions returned reflects the order in which they will be executed during the appropriate flow.
    /// </summary>
    Task<Pager<ActionBinding>> ListAsync(
        string triggerId,
        ListActionTriggerBindingsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the actions that are bound (i.e. attached) to a trigger. Once an action is created and deployed, it must be attached (i.e. bound) to a trigger so that it will be executed as part of a flow. The order in which the actions are provided will determine the order in which they are executed.
    /// </summary>
    WithRawResponseTask<UpdateActionBindingsResponseContent> UpdateManyAsync(
        string triggerId,
        UpdateActionBindingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
