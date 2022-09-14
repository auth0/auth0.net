namespace Auth0.ManagementApi.Clients
{
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Models.Actions;
  using Paging;

  public interface IActionsClient
  {
    /// <summary>
    /// Retrieve all actions.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying actions.</param>
    /// <param name="pagination">Specifies pagination info to use.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{Action}"/> containing the actions.</returns>
    Task<IPagedList<Action>> GetAllAsync(GetActionsRequest request, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve an action by its ID.
    /// </summary>
    /// <param name="id">The ID of the action to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The retrieved action.</returns>
    Task<Action> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create an action. 
    /// </summary>
    /// <remarks>
    /// Once an action is created, it must be deployed, and then bound to a trigger before it will be executed as part of a flow.
    /// </remarks>
    /// <param name="request">Specifies criteria to use when creating an action.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The new <see cref="Action"/> that has been created.</returns>
    Task<Action> CreateAsync(CreateActionRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update an existing action.
    /// </summary>
    /// <remarks>
    /// If this action is currently bound to a trigger, updating it will not affect any user flows until the action is deployed.
    /// </remarks>
    /// <param name="id">The id of the action to update.</param>
    /// <param name="request">Specifies criteria to use when updating an action.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Action"/> that was updated.</returns>
    Task<Action> UpdateAsync(string id, UpdateActionRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an action and all of its associated versions.
    /// </summary>
    /// <remarks>
    /// An action must be unbound from all triggers before it can be deleted.
    /// </remarks>
    /// <param name="id">The ID of the action to delete.</param>
    /// <param name="request">Specifies criteria to use when deleting an action.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id, DeleteActionRequest request = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the set of triggers currently available within actions. A trigger is an extensibility point to which actions can be bound
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A list containing the triggers.</returns>
    Task<IList<Trigger>> GetAllTriggersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve information about a specific execution of a trigger.
    /// </summary>
    /// <remarks>
    /// Relevant execution IDs will be included in tenant logs generated as part of that authentication flow.
    /// Executions will only be stored for 10 days after their creation.
    /// </remarks>
    /// <param name="id">The ID of the execution to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The retrieved execution.</returns>
    Task<ActionExecution> GetExecutionAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve all versions of an action.
    /// </summary>
    /// <remarks>
    /// An action version is created whenever an action is deployed. An action version is immutable, once created.
    /// </remarks>
    /// <param name="actionId">The ID of the action.</param>
    /// <param name="pagination">Specifies pagination info to use.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The retrieved versions of the specified action.</returns>
    Task<IPagedList<ActionVersion>> GetAllVersionsAsync(string actionId, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve a specific version of an action.
    /// </summary>
    /// <remarks>
    /// An action version is created whenever an action is deployed. An action version is immutable, once created.
    /// </remarks>
    /// <param name="actionId">The ID of the action.</param>
    /// <param name="versionId">The ID of the action version.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The retrieved version of the specified action.</returns>
    Task<ActionVersion> GetVersionAsync(string actionId, string versionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the actions that are bound to a trigger.
    /// </summary>
    /// <remarks>
    /// Once an action is created and deployed, it must be attached (i.e. bound) to a trigger so that it will be executed as part of a flow.
    /// The list of actions returned reflects the order in which they will be executed during the appropriate flow.
    /// </remarks>
    /// <param name="triggerId">An actions extensibility point.</param>
    /// <param name="pagination">Specifies pagination info to use.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The retrieved trigger bindings.</returns>
    Task<IPagedList<TriggerBinding>> GetAllTriggerBindingsAsync(string triggerId, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the actions that are bound (i.e. attached) to a trigger.
    /// Once an action is created and deployed, it must be attached(i.e.bound) to a trigger so that it will be executed as part of a flow.
    /// The order in which the actions are provided will determine the order in which they are executed.
    /// </summary>
    /// <param name="triggerId">An actions extensibility point.</param>
    /// <param name="request">Specifies criteria to use when updating the trigger bindings.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The trigger bindings.</returns>
    Task<IList<TriggerBinding>> UpdateTriggerBindingsAsync(string triggerId, UpdateTriggerBindingsRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deploy an action.
    /// </summary>
    /// <remarks>
    /// Deploying an action will create a new immutable version of the action. If the action is currently bound to a trigger,
    /// then the system will begin executing the newly deployed version of the action immediately.Otherwise, the action will only be executed as a part of a flow once it is bound to that flow.
    /// </remarks>
    /// <param name="id">The ID of the action to deploy.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The action version that was created.</returns>
    Task<ActionVersion> DeployAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Performs the equivalent of a roll-back of an action to an earlier, specified version.
    /// </summary>
    /// <remarks>
    /// Creates a new, deployed action version that is identical to the specified version.
    /// If this action is currently bound to a trigger, the system will begin executing the newly-created version immediately.
    /// </remarks>
    /// <param name="actionId">The ID of the action.</param>
    /// <param name="versionId">The ID of the version to deploy.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task<ActionVersion> RollbackToVersionAsync(string actionId, string versionId, CancellationToken cancellationToken = default);
  }
}
