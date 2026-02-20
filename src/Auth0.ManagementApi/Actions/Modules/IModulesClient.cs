using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Actions;

public partial interface IModulesClient
{
    public Auth0.ManagementApi.Actions.Modules.IVersionsClient Versions { get; }

    /// <summary>
    /// Retrieve a paginated list of all Actions Modules with optional filtering and totals.
    /// </summary>
    Task<Pager<ActionModuleListItem>> ListAsync(
        GetActionModulesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new Actions Module for reusable code across actions.
    /// </summary>
    WithRawResponseTask<CreateActionModuleResponseContent> CreateAsync(
        CreateActionModuleRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of a specific Actions Module by its unique identifier.
    /// </summary>
    WithRawResponseTask<GetActionModuleResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete an Actions Module. This will fail if the module is still in use by any actions.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update properties of an existing Actions Module, such as code, dependencies, or secrets.
    /// </summary>
    WithRawResponseTask<UpdateActionModuleResponseContent> UpdateAsync(
        string id,
        UpdateActionModuleRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all actions that are using a specific Actions Module, showing which deployed action versions reference this Actions Module.
    /// </summary>
    Task<Pager<ActionModuleAction>> ListActionsAsync(
        string id,
        GetActionModuleActionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Rolls back an Actions Module's draft to a previously created version. This action copies the code, dependencies, and secrets from the specified version into the current draft.
    /// </summary>
    WithRawResponseTask<RollbackActionModuleResponseContent> RollbackAsync(
        string id,
        RollbackActionModuleRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
