using Auth0.ManagementApi.Actions;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IActionsClient
{
    public Auth0.ManagementApi.Actions.IVersionsClient Versions { get; }
    public Auth0.ManagementApi.Actions.IExecutionsClient Executions { get; }
    public IModulesClient Modules { get; }
    public ITriggersClient Triggers { get; }

    /// <summary>
    /// Retrieve all actions.
    /// </summary>
    Task<Pager<Action>> ListAsync(
        ListActionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create an action. Once an action is created, it must be deployed, and then bound to a trigger before it will be executed as part of a flow.
    /// </summary>
    WithRawResponseTask<CreateActionResponseContent> CreateAsync(
        CreateActionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an action by its ID.
    /// </summary>
    WithRawResponseTask<GetActionResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes an action and all of its associated versions. An action must be unbound from all triggers before it can be deleted.
    /// </summary>
    Task DeleteAsync(
        string id,
        DeleteActionRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing action. If this action is currently bound to a trigger, updating it will <b>not</b> affect any user flows until the action is deployed.
    /// </summary>
    WithRawResponseTask<UpdateActionResponseContent> UpdateAsync(
        string id,
        UpdateActionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deploy an action. Deploying an action will create a new immutable version of the action. If the action is currently bound to a trigger, then the system will begin executing the newly deployed version of the action immediately. Otherwise, the action will only be executed as a part of a flow once it is bound to that flow.
    /// </summary>
    WithRawResponseTask<DeployActionResponseContent> DeployAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Test an action. After updating an action, it can be tested prior to being deployed to ensure it behaves as expected.
    /// </summary>
    WithRawResponseTask<TestActionResponseContent> TestAsync(
        string id,
        TestActionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
